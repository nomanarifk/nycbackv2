using MongoDB.Bson;
using nycWeb.DTOs;
using nycWeb.Models;
using nycWeb.Services;
using nycWeb.BusinessLogic;
using nycformweb.DTOs;

namespace nycWeb.BusinessLogic
{
    public class RegistrationBL
    {
        public readonly RegistrationService _registrationService;
        public readonly RegistrationSequenceService _registrationSequenceService;
        public RegistrationBL(RegistrationService registrationService, RegistrationSequenceService registrationSequenceService)
        {
            _registrationService = registrationService;
            _registrationSequenceService = registrationSequenceService;
        }

        public async Task<Registration?> CreateNewRegistration(RegistrationDtoToCreate registrationDto)
        {
            Registration registrationModel = EntityMapper.MapToEntity(registrationDto);

            registrationModel.Status = "Pending";

            await _registrationService.CreateAsync(registrationModel);

            return registrationModel;
        }

        public async Task<List<RegistrationDtoToReturn>> GetAllRegistrationDtoToReturn()
        {
            return await _registrationService.GetSummaryListAsync();
        }

        public async Task<Registration?> GetByIdAsync(string id)
        {
            var registration = await _registrationService.GetAsync(id);

            if (registration != null)
            {
                registration.Status = string.IsNullOrWhiteSpace(registration.Status) ? "Pending" : registration.Status;
            }

            return registration;
        }

        public async Task<RegistrationSummaryDto> GetCounts()
        {
            var registrations = await _registrationService.GetAllAsync();

            var summary = new RegistrationSummaryDto
            {
                Total = registrations.Count,
                Pending = registrations.Count(r => string.IsNullOrWhiteSpace(r.Status) || r.Status == "Pending"),
                InReview = registrations.Count(r => r.Status == "In Review"),
                ReviewDone = registrations.Count(r => r.Status == "Review Done"),
                Approved = registrations.Count(r => r.Status == "Approved"),
                Rejected = registrations.Count(r => r.Status == "Rejected"),
                Participant = registrations.Count(r => r.Role == "participant"),
                Facilitator = registrations.Count(r => r.Role == "facilitator"),
                RegionCounts = registrations
                    .GroupBy(r => r.personalInfo.CurrentRegion?.ToLower() ?? "unknown")
                    .Select(g => new RegionCounterDto
                    {
                        Region = g.Key,
                        Total = g.Count(),
                        Pending = g.Count(r => string.IsNullOrWhiteSpace(r.Status) || r.Status == "Pending"),
                        InReview = g.Count(r => r.Status == "In Review"),
                        ReviewDone = g.Count(r => r.Status == "Review Done"),
                        Approved = g.Count(r => r.Status == "Approved"),
                        Rejected = g.Count(r => r.Status == "Rejected"),
                        Participant = g.Count(r => r.Role == "participant"),
                        Facilitator = g.Count(r => r.Role == "facilitator")
                    })
                    .OrderBy(r => r.Region)
                    .ToList()
            };

            return summary;
        }
    }
}
