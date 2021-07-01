using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace UnitTestingTutorial.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _videoRepository;

        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _videoRepository = videoRepository ?? new VideoRepository();
        }
        
        public string ReadVideoTitle()
        {
            string str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        // [] => ""
        // [{}, {}, {}] => "{},{},{}"
        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            IEnumerable<Video> videos = _videoRepository.GetUnprocessedVideos();
            
            foreach (Video v in videos)
                videoIds.Add(v.Id);

            return string.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}