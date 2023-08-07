using ManagementSystem.Mapping.DTOs;
using ManagementSystem.Services.App_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Services.Interfaces
{
    public interface IUserDetailsService
    {

        public ServiceResponse<UserDetailsDto> Create(UserDetailsDto user);
        public ServiceResponse<UserDetailsDto> Update(UserDetailsDto user);
        public ServiceResponse<UserDetailsDto> Delete(int id);
        public ServiceResponse<UserDetailsDto> Get(int id);
        public ServiceResponse<UserDetailsDto> GetByEmail(string email);
        public ServiceResponse<UserDetailsDto> GetByUsername(string username);
        public ServiceResponse<UserDetailsDto> GetAll();

    }
}
