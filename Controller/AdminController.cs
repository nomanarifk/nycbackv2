using System.Net;
using System.Net.Mail;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nycformweb.Helpers;

namespace nycformweb.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController(IOptions<EmailSettings> emailSettings) : ControllerBase
    {
        private readonly EmailSettings _emailSettings = emailSettings.Value;

        [HttpGet("GetQuotaDetail")]
        public async Task<IActionResult> GetQuotaDetail()
        {
            // Define scopes required
            string[] scopes = { DriveService.Scope.DriveReadonly };

            string jsonCreds = Environment.GetEnvironmentVariable("GOOGLE_CREDS")!;

            if (string.IsNullOrEmpty(jsonCreds))
            {
                throw new InvalidOperationException("GOOGLE_CREDS environment variable is not set.");
            }

            GoogleCredential credential;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonCreds)))
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

        [HttpPost("sendFeedback")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        { 
            try
            {
                string password = Encoding.UTF8.GetString(Convert.FromBase64String(_emailSettings.PasswordBase64));

                var fromAddress = new MailAddress(_emailSettings.From, _emailSettings.FromName);
                var toAddress = new MailAddress(_emailSettings.To, _emailSettings.ToName);

                using var smtp = new SmtpClient
                {
                    Host = _emailSettings.SmtpHost,
                    Port = _emailSettings.SmtpPort,
                    EnableSsl = _emailSettings.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, password)
                };

                using var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = $"NYC Feedback Form: {request.Phone}",
                    Body = $"Phone: {request.Phone}\n\nMessage:\n{request.Text}",
                };

                await smtp.SendMailAsync(message);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Email failed to send. Error: {ex.Message}");
            }
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