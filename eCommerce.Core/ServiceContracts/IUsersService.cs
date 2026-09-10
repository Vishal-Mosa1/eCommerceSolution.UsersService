using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle user registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    /// <summary>
    /// Method to get user by Id
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    Task<UserDTO> GetUserByUserId(Guid UserId);
}
