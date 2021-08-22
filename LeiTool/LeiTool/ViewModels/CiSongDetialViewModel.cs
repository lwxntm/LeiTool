using CiSongProducer;
using CiSongProducer.Models;
using Prism.Mvvm;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
namespace LeiTool.ViewModels
{
    [QueryProperty(nameof(SearchCondition), "SearchCondition")]
    public class CiSongDetialViewModel : BindableBase
    {
        //检索条件，格式是该词的第一句正文
        private string searchCondition;

        public string SearchCondition
        {
            get { return searchCondition; }
            set
            {
                searchCondition = value;
                OnCiSongLoad();
            }
        }


        private CiSong _ciSong;

        public CiSong CiSongEntity
        {
            get { return _ciSong; }
            set
            {
                SetProperty(ref _ciSong, value);
            }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { SetProperty(ref author, value); }
        }

        private string rhythmic;

        public string Rhythmic
        {
            get { return rhythmic; }
            set { SetProperty(ref rhythmic, value); }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set => SetProperty(ref content, value);
        }


        private async void OnCiSongLoad()
        {
            Content = "正在检索";

            Debug.WriteLine("正在检索");
            CiSongEntity = await new Producer().GetCiSongByP1(searchCondition);
            var sb = new StringBuilder();
            foreach (var p in CiSongEntity.Paragraphs)
            {
                sb.AppendLine(p.ToString());
            }
            Content = sb.ToString();
            Author = CiSongEntity.Author;
            Rhythmic = CiSongEntity.Rhythmic;
        }


    }
}
