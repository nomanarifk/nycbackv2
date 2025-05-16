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
        public RegistrationBL(RegistrationService registrationService, RegistrationSequenceService registrationSequenceService){
            _registrationService = registrationService;
            _registrationSequenceService = registrationSequenceService;
        }

        public async Task<Registration?> CreateNewRegistration(RegistrationDtoToCreate registrationDto)
        {
            Registration registrationModel = EntityMapper.MapToEntity(registrationDto);

            await _registrationService.CreateAsync(registrationModel);

            return registrationModel;
        }
    }
}
