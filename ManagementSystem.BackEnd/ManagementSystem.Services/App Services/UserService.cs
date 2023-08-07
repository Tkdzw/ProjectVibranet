using AutoMapper;
using ManagementSystem.Data.DbContext;
using ManagementSystem.Data.EntityModels;
using ManagementSystem.Mapping.DTOs;
using ManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Services.App_Services
{
    public class UserService : IUserService
    {
        public readonly ManagementSystemDbContext _context;
        public readonly IMapper _mapper;

        public UserService(ManagementSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ServiceResponse<UserDto> Create(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<UserDto, UserDetails>(userDto);
                var _user = _context.SystemUserDetails.Add(user);
                _context.SaveChanges();
                var _userDto = _mapper.Map<UserDetails, UserDto>(_user.Entity);

                return new ServiceResponse<UserDto>
                {
                    Message = $"User with Id {_userDto.Id} was not found",
                    Time = DateTime.Now,
                    IsSuccess = false
                };
            }
            catch
            {
                throw new NotImplementedException(); ;
            }
        }


        public ServiceResponse<UserDto> Get(int id)
        {
            try
            {
                var _user = _context.SystemUserDetails.FirstOrDefault(x => x.Id == id);
                if (_user != null)
                {
                    var res = _mapper.Map<UserDetails, UserDto>(_user);
                    return new ServiceResponse<UserDto>
                    {
                        Data = res,
                        Message = $"{res.UserName} Found",
                        Time = DateTime.Now,
                        IsSuccess = true
                    };
                }
                else
                {
                    return new ServiceResponse<UserDto>
                    {
                        Message = $"User with Id {id} was not found",
                        Time = DateTime.Now,
                        IsSuccess = false
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceResponse<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<UserDto> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<UserDto> Login(UserDto user)
        {

            var _user = _context.SystemUserDetails.FirstOrDefault(x => x.Id == user.Id);

            var _userDto = _mapper.Map<UserDetails, UserDto>(_user);

            string UserName = _userDto.UserName;
            string Password = _userDto.Password;

            if (UserName == null || Password == null)
            {
                return new ServiceResponse<UserDto>
                {
                    Message = "User Credetnials Are Bad",
                    Time = DateTime.Now,
                    IsSuccess = false
                }; 
            }
            else if (Password == null)
            {
                return new ServiceResponse<UserDto> 
                { 
                    Message = "Enter Password",
                    Time = DateTime.Now, 
                    IsSuccess = false };
            }
            else if (UserName.Length == 0)
            {
                return new ServiceResponse<UserDto> 
                { 
                    Message = "Enter Username", 
                    Time = DateTime.Now, 
                    IsSuccess = false
                };
            }
            
            if(BCrypt.Net.BCrypt.Verify(user.Password, Password))
            {
                return new ServiceResponse<UserDto>
                {
                    Message = "Access Granted",
                    Time = DateTime.Now,
                    IsSuccess = true
                };
            }
            else
            {
                 return new ServiceResponse<UserDto>
                    {
                        Message = "Credentrials Wrong",
                        Time = DateTime.Now,
                        IsSuccess = false
                    };
            }
        }
            
           

        public ServiceResponse<UserDto> Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
