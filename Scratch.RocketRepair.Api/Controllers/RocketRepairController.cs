using System.Net.Mime;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Scratch.RocketRepair.Api.Controllers
{
    [ApiController]
    [Route("downloads")]
    public class RocketRepairController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RocketRepairController> _logger;
        private readonly SecretClient _secretClient;

        public RocketRepairController(ILogger<RocketRepairController> logger, SecretClient secretClient)
        {
            _logger = logger;
            _secretClient = secretClient;
        }

        [HttpGet("v/{version}")]
        [RequestSizeLimit(75000000)]
        public IActionResult Get([FromRoute] string version)
        {
            // Name of the share, directory, and file we'll download from
            const string shareName = "scratch-rocketrepair";
            const string dirName = "release/0.0.1";
            const string fileName = "RocketRepair.zip";
            const string contentType = MediaTypeNames.Application.Zip;

            var connectionString = _secretClient.GetSecret("connectionstring-storageaccount");

            // Path to the save the downloaded file
            // Get a reference to the file
            var share = new ShareClient(connectionString.Value.Value, shareName);
            var directory = share.GetDirectoryClient(dirName);
            var file = directory.GetFileClient(fileName);

            // Download the file
            var download = (ShareFileDownloadInfo) file.Download();
            return File(download.Content, contentType, fileName);
        }
    }
}