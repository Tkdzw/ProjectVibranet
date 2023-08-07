using ManagementSystem.Mapping.DTOs;

namespace ManagementSystem.Services.App_Services
{
    public class ServiceResponse<T> 
    {
        public T? Data { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsSuccess { get; set; }
    }
}