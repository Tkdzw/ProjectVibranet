using ManagementSystem.Mapping.DTOs;
using ManagementSystem.Services.App_Services;

namespace ManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        public ServiceResponse<UserDto> Create(UserDto user);
        public ServiceResponse<UserDto> Login(UserDto user);
        public ServiceResponse<UserDto> Update(UserDto user);
        public ServiceResponse<UserDto> Get(int id);
        public ServiceResponse<UserDto> GetByEmail(string email);
        public ServiceResponse<UserDto> GetAll();
    }
}