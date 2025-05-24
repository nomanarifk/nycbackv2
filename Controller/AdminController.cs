using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;

namespace nycformweb.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("GetQuotaDetail")]
        public async Task<IActionResult> GetQuotaDetail()
        {
            // Define scopes required
            string[] scopes = { DriveService.Scope.DriveReadonly };

            string jsonCreds = Environment.GetEnvironmentVariable("GOOGLE_CREDS")!;

            if (string.IsNullOrEmpty(jsonCreds))
            {
                throw new InvalidOperationException("GOOGLE_CREDENTIALS_JSON environment variable is not set.");
            }

            GoogleCredential credential;
            using (var stream = new FileStream(jsonCreds, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(scopes);
            }

            // Create Drive service
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive Quota Checker",
            });

            // Get the about resource, specifically storageQuota
            var aboutRequest = service.About.Get();
            aboutRequest.Fields = "storageQuota";

            var about = await aboutRequest.ExecuteAsync();

            var quota = about.StorageQuota;

            var freeBytes = quota.Limit - quota.Usage.GetValueOrDefault(0);

            var summary = new DriveStorageInfo
            {
                LimitGB = ToGB(quota.Limit),
                UsageGB = ToGB(quota.Usage),
                UsageInDrive = ToGB(quota.UsageInDrive),
                UsageInDriveTrash = ToGB(quota.UsageInDriveTrash),
                FreeGB = ToGB(freeBytes)
            };

            return Ok(summary);
        }
        
        double ToGB(long? bytes) => Math.Round((bytes ?? 0) / 1073741824.0, 2);

        private class DriveStorageInfo
        {
            public double LimitGB { get; set; }
            public double UsageGB { get; set; }
            public double UsageInDrive { get; set; }
            public double UsageInDriveTrash { get; set; }
            public double FreeGB { get; set; }
        }
    }
}