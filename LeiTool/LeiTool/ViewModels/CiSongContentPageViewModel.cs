using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using CiSongProducer.Models;
using LeiTool.Pages;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms;

namespace LeiTool.ViewModels
{
    class CiSongContentPageViewModel:BindableBase
    {
        private ObservableCollection<CiSong> _ciSongs;

        public ObservableCollection<CiSong> CiSongs
        {
            get { return _ciSongs; }
            set { _ciSongs = value; }
        }

        public DelegateCommand<CiSong> CiSongTapped {  get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public CiSongContentPageViewModel()
        {
            _ciSongs = new ObservableCollection<CiSong>();
            LoadItemsCommand = new DelegateCommand(async () => await ExecuteLoadCiSongsCommand());
            LoadItemsCommand.Execute();
            CiSongTapped = new DelegateCommand<CiSong>(OnItemSelected);
        }
        public DelegateCommand LoadItemsCommand { get; }
        async Task ExecuteLoadCiSongsCommand()
        {
            IsBusy = true;
            try
            {
                _ciSongs.Clear();
                var items = await new CiSongProducer.Producer().GetRandomsCiSongs();
                foreach (var item in items)
                {
                    _ciSongs.Add(item);
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

        private CiSong _selectedCiSong;

        public CiSong SelectedCiSong
        {
            get => _selectedCiSong;
            set
            {
                SetProperty(ref _selectedCiSong, value);
                OnItemSelected(value);
            }
        }
        async void OnItemSelected(CiSong item)
        {
            if (item == null)
                return;
            var s1 = item.Paragraphs[0];
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CiSongDetialPage)}?SearchCondition={s1}");
        }
    }
}
