using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pasajes.Api.Services
{
    public interface IStreamingService
    {
        Task<Stream> GetYoutubeAudioStreamAsync(string url);

        Stream GetAudioStream(string url);
    }
}
