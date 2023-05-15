using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;

namespace dotnetAPI_Rubrica.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        bool IsUniqueEmail(string email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO);
        Task<List<UserDTO>> GetAllUsers();
        //Task<bool> Logout();
        Task<UserDTO> GetMe();
    }
}
