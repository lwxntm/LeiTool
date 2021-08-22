using System;
using System.Collections.Generic;
using System.Text;

namespace CiSongProducer.Models
{
   public class CiSong
    {
        private string rhythmic;

        public string Rhythmic
        {
            get { return rhythmic; }
            set { rhythmic = value; }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }


        private List<string> paragraphs;

        public List<string> Paragraphs
        {
            get { return paragraphs; }
            set { paragraphs = value; }
        }

        private List<string> tags;

        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

    }
}
