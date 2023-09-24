using AuthServer.Dtos;

namespace AuthServer.Services
{
    public interface IAccountService
    {
        Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequest request);
        Task<UserLoginResponse> UserLoginAsync(UserLoginRequest request);
        Task<AddRoleAsyncResponse> AddRoleAsync(AddRoleAsyncRequest request);
    }
}
