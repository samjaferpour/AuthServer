using AuthServer.Dtos;
using AuthServer.Entities;
using AuthServer.Helpers;
using AuthServer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUserRepository userRepository,
                              IRoleRepository roleRepository,
                              IUserRoleRepository userRoleRepository,
                              IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._userRoleRepository = userRoleRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<AddRoleAsyncResponse> AddRoleAsync(AddRoleAsyncRequest request)
        {
            var role = new Role
            {
                Name = request.Name,
                IsActive = false
            };
            await _roleRepository.InsertAsync(role);
            await _unitOfWork.CommitChangesAsync();
            return new AddRoleAsyncResponse
            {
                RoleId = role.Id
            };
        }

        public Task<UserLoginResponse> UserLoginAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequest request)
        {

            var userIsExist = await _userRepository.IsUserExistsAsync(request.Username);
            if (userIsExist)
            {
                throw new Exception("User already exists!");
            }
            var passwordSalt = Guid.NewGuid().ToString();
            var user = new User
            {
                Username = request.Username,
                PasswordSalt = passwordSalt,
                PasswordHash = PasswordManager.GetHash(request.Password + passwordSalt),
                Name = request.Name,
                IsActive = false
            };
            await _userRepository.InsertAsync(user);
            foreach (var roleId in request.RoleIds)
            {
                await _userRoleRepository.InsertAsync(new UserRole
                {
                    UserId = user.Id,
                    RoleId = roleId
                });
            }
            await _unitOfWork.CommitChangesAsync();
            return new UserRegisterResponse
            {
                UserId = user.Id
            };
        }
    }
}
