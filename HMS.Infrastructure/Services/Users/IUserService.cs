using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using HMS.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = HMS.Core.Dtos.Query;

namespace HMS.Infrastructure.Services.Users
{
    public interface IUserService
    {
        public List<User> GetAllData();

        public Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        UserViewModel GetUserByUsername(string username);
        Task<string> Delete(string Id);
        Task<UpdateUserDto> Get(string Id);



    }
}
