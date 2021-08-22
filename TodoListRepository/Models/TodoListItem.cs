using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListRepository.Models
{
    [Table("todoListItem")]
    public class TodoListItem
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string content;

        [MaxLength(250), Unique]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private bool isFinished;
        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }


    }
}
