using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pasajes.Api.Models;
using Pasajes.Api.Repositories;
using Pasajes.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pasajes.Api.Controllers
{
    [Route("api/tales")]
    public class TaleSourcesController : Controller
    {
        private ILogger<TaleSourcesController> _logger;
        private IStreamingService _streamingService;
        private ITalesRepository _talesRepository;

        public TaleSourcesController(
            ILogger<TaleSourcesController> logger,
            IStreamingService streamingService,
            ITalesRepository talesRepository)
        {
            _logger = logger;
            _streamingService = streamingService;
            _talesRepository = talesRepository;
        }

        [HttpGet("{taleId}/talesources/{sourceId}")]
        public async Task<IActionResult> GetTaleSourcesAsync(Guid taleId, Guid sourceId)
        {
            try
            {
                var tale = _talesRepository.GetTale(taleId);
                if (tale == null)
                {
                    return NotFound();
                }

                var taleSource = _talesRepository.GetTaleSource(sourceId);
                if (taleSource == null)
                {
                    return NotFound();
                }

                if (taleSource.Url.Contains("youtube"))
                {
                    return File(await _streamingService.GetYoutubeAudioStreamAsync(taleSource.Url), "audio/mp3", $"{tale.Title}.mp3");
                }
                else
                {
                    return File(_streamingService.GetAudioStream(taleSource.Url), "audio/mp3", $"{tale.Title}.mp3");
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.ToString());
                return StatusCode(500, "Unknown Error");
            }
        }
    }
}
