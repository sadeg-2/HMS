using HMS.Core.Dtos;
using HMS.Core.ViewModels;

namespace HMS.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        List<UserViewModel> GetAll();
        UserViewModel GetUserByUsername(string username);
        Task<string> Delete(string Id);
        Task<UpdateUserDto> Get(string Id);

    }
}
