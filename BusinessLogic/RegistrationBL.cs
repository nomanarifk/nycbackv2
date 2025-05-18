using MongoDB.Bson;
using nycWeb.DTOs;
using nycWeb.Models;
using nycWeb.Services;
using nycWeb.BusinessLogic;

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
    }
}
