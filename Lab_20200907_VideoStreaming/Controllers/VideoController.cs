using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab_20200907_VideoStreaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;

        public VideoController(ILogger<VideoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var videoFileStream =
                System.IO.File.Open(
                    "wwwroot/example.mp4",
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read,
                    System.IO.FileShare.Read);

            return File(
                fileStream: videoFileStream,
                contentType: "video/mp4",
                enableRangeProcessing: true);
        }
    }
}
