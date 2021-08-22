using CiSongProducer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CiSongProducer
{
    public class Producer
    {

        private List<CiSong> _ciList;

        public Producer()
        {
            if (_ciList == null)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                //从资源里读取信息到流里，ShijingProducer是项目名称，jsons是文件夹名称，shijing.json是文件名称
                var fileStream = assembly.GetManifestResourceStream("CiSongProducer.jsons.ci300.json");
                var streamReader = new StreamReader(fileStream);
                var fileContentString = streamReader.ReadToEnd();
                _ciList = JsonConvert.DeserializeObject<List<CiSong>>(fileContentString);
            }
        }

        public async Task<List<CiSong>> GetRandomsCiSongs()
        {
            var list1 = new List<CiSong>();
            for (int i = 0; i < 5; i++)
            {
                list1.Add(_ciList[new Random().Next(0, _ciList.Count - 20) + i]);
            }
            return await Task.FromResult(list1);
        }
        public async Task<CiSong> GetCiSongByAuthorAndCipaiMing(string author, string rhythmic)
        {
            return await Task.FromResult(_ciList.FirstOrDefault(s => author.Equals(s.Author) && rhythmic.Equals(s.Rhythmic)));
        }
        public async Task<CiSong> GetCiSongByP1(string p1)
        {
            return await Task.FromResult(_ciList.FirstOrDefault(s => p1.Equals(s.Paragraphs[0])));
        }
    }
}
