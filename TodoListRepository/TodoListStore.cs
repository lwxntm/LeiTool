using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListRepository.Models;

namespace TodoListRepository
{
    public class TodoListStore
    {
        private SQLiteAsyncConnection conn;

        private string statusMessage;

        public string StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; }
        }

        public TodoListStore(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<TodoListItem>().Wait();
        }

        public async Task<bool> AddTodoListItem(string todoListItemContent)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(todoListItemContent))
                    throw new Exception("Valid name required");

                // TODO: insert a new person into the Person table
                await conn.InsertAsync(new TodoListItem { Content = todoListItemContent });
                statusMessage = "添加成功";
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                statusMessage = e.Message;
            }

            return await Task.FromResult(true);
        }

        public async Task<List<TodoListItem>> GetAllTodoListItem()
        {
            return await conn.Table<TodoListItem>().ToListAsync();
        }
        public async Task<bool> DeleteItemById(int id)
        {
            await conn.Table<TodoListItem>().DeleteAsync(i => i.Id == id);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItem(TodoListItem todoListItem)
        {
            var model = await conn.Table<TodoListItem>().FirstOrDefaultAsync(t => todoListItem.Id == t.Id);
            model.Content=todoListItem.Content;
            model.IsFinished = todoListItem.IsFinished;
            await conn.UpdateAsync(model);
            return await Task.FromResult(true);
        }
    }
}
