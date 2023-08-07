using AutoMapper;
using ManagementSystem.Data.DbContext;
using ManagementSystem.Data.EntityModels;
using ManagementSystem.Mapping.DTOs;
using ManagementSystem.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ManagementSystem.Services.App_Services
{
    public class UserDetailsService : IUserDetailsService
    {
        public readonly ManagementSystemDbContext _context;
        public readonly IMapper _mapper;

        public UserDetailsService(ManagementSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ServiceResponse<UserDetailsDto> Create(UserDetailsDto userDto)
        {
            try
            {
                var user = _mapper.Map<UserDetailsDto, UserDetails>(userDto);

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                var _user = _context.SystemUserDetails.Add(user);
                _context.SaveChanges();

                return new ServiceResponse<UserDetailsDto>
                {
                    Data = _mapper.Map<UserDetails, UserDetailsDto>(_user.Entity),
                    Message = "UserDetails Updated Successfully",
                    Time = DateTime.Now,
                    IsSuccess = true
                }; 
            }
            catch 
            {
                throw new NotImplementedException(); ;
            }
        }

        public ServiceResponse<UserDetailsDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<UserDetailsDto> Get(int id)
        {
            try
            {
                var _user = _context.SystemUserDetails.FirstOrDefault(x => x.Id == id);
                if (_user != null)
                {
                    var res = _mapper.Map<UserDetails, UserDetailsDto>(_user);
                    return new ServiceResponse<UserDetailsDto>
                    {
                        Data = res,
                        Message = $"{res.Name} Found",
                        Time = DateTime.Now,
                        IsSuccess = true
                    };
                }
                else
                {
                    return new ServiceResponse<UserDetailsDto>
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

        public ServiceResponse<UserDetailsDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<UserDetailsDto> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<UserDetailsDto> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<UserDetailsDto> Update(UserDetailsDto useDto)
        {
            try
            {
                var _user = _mapper.Map<UserDetailsDto, UserDetails>(useDto);
                var res = _context.SystemUserDetails.Update(_user);
                _context.SaveChanges();

                return new ServiceResponse<UserDetailsDto>
                {
                    Data = _mapper.Map<UserDetails, UserDetailsDto>(res.Entity),
                    Message = "UserDetails Updated Successfully",
                    Time = DateTime.Now,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ServiceResponse<UserDetailsDto> Update()
        {
            throw new NotImplementedException();
        }
    }
}
