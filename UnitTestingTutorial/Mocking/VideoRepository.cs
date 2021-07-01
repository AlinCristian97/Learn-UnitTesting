using System.Collections.Generic;
using System.Linq;

namespace UnitTestingTutorial.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
    }

    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                List<Video> videos = 
                    (from video in context.Videos
                        where !video.IsProcessed
                        select video).ToList();

                return videos;
            }
        }
    }
}