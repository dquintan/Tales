using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace Pasajes.Api.Services
{
    public class StreamingService : IStreamingService
    {
        ///private string blabla = Startup.Configuration["aaa:aaa"];

        public async Task<Stream> GetYoutubeAudioStreamAsync(string url)
        {
            var cli = new WebClient();
            var id = YoutubeClient.ParseVideoId(url);
            var client = new YoutubeClient();

            // Get metadata for all streams in this video
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);

            // Select one of the streams
            var streamInfo = streamInfoSet.Audio;

            byte[] buff;
            using (var fs = await client.GetMediaStreamAsync(streamInfo.FirstOrDefault(c => c.Container == Container.Mp4)))
            {
                var br = new BinaryReader(fs);
                long numBytes = fs.Length;
                buff = br.ReadBytes((int)numBytes);
            }

            return new MemoryStream(buff);
        }

        public Stream GetAudioStream(string url)
        {
            byte[] buff = null;

            using (var wc = new WebClient())
                buff = wc.DownloadData(url);

            return new MemoryStream(buff);
        }
    }
}
