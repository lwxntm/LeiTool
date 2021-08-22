using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TodoListRepository;
using TodoListRepository.Models;
using Xamarin.Essentials;

namespace LeiTool.ViewModels
{
    class TodoListViewModel : BindableBase
    {


        public ObservableCollection<TodoListItem> TodoListData { get; }

        private TodoListItem selectedItem;

        public TodoListItem SelectedItem
        {
            get { return selectedItem; }
            set => SetProperty(ref selectedItem, value);
        }


        private TodoListStore _store;

        private static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
        public TodoListViewModel()
        {
            TodoListData = new ObservableCollection<TodoListItem>();
            _store = new TodoListStore(GetLocalFilePath("todolist.db"));
            AddCommand = new DelegateCommand(AddEntryStrToDb);
            LoadDataCommand = new DelegateCommand(ExecuteLoadTodoListItemCommand);
            DelCommand = new DelegateCommand(Del);
            FinishSomeOneCommand=new DelegateCommand(FinishSomeOne);
            if (TodoListData.Count == 0)
            {
                LoadDataCommand.Execute();
            }
        }

        private string entryStr;

        public string EntryStr
        {
            get { return entryStr; }
            set => SetProperty(ref entryStr, value);
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DelCommand { get; }

        public DelegateCommand LoadDataCommand { get; }
        private async void AddEntryStrToDb()
        {
            await _store.AddTodoListItem(EntryStr);
            LoadDataCommand.Execute();
        }

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        async void ExecuteLoadTodoListItemCommand()
        {
            IsBusy = true;
            try
            {
                TodoListData.Clear();
                var items = await _store.GetAllTodoListItem();
                foreach (var item in items)
                {
                    TodoListData.Add(item);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async void Del()
        {
            if (selectedItem != null)
            {
                await _store.DeleteItemById(selectedItem.Id);
                LoadDataCommand.Execute();
            }

        }

        public DelegateCommand FinishSomeOneCommand {  get; }

        private async void FinishSomeOne()
        {
            if (SelectedItem != null)
            {
                SelectedItem.IsFinished = true;
                await _store.UpdateItem(selectedItem);
                LoadDataCommand.Execute();
            }
        }
    }
}
