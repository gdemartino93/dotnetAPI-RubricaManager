using dotnetAPI_Rubrica.Data;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace dotnetAPI_Rubrica.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    [ApiVersionNeutral]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private APIResponse _response;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new APIResponse();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginRes = await _userRepository.Login(loginRequestDTO);
            if (loginRes.User == null || string.IsNullOrEmpty(loginRes.Token))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Username o password non corretti");
                _response.Result = "Username o password non corretti";
                return BadRequest(_response);
            }
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            _response.Result = loginRes;
            _response.IsSuccess = true;

            return Ok(_response);
        }
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            //check if password matches
            if (registerRequestDTO.Password != registerRequestDTO.ConfirmPassword)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Le password devono essere uguali");
                return BadRequest(_response);
            }
            if (!StaticData.Validation.IsValidEmail(registerRequestDTO.Email))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                _response.ErrorMessage.Add("Inserisci un email valida");
                return UnprocessableEntity(_response);
            }
            //check if username and email already exist
            bool usernameExist = _userRepository.IsUniqueUser(registerRequestDTO.Username);
            bool emailExist = _userRepository.IsUniqueEmail(registerRequestDTO.Email);
            //if already exist
            if (!usernameExist && !emailExist)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            try
            {
                var newUser = await _userRepository.Register(registerRequestDTO);
                if (newUser is not null)
                {
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.Created;
                    _response.Result = newUser;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                _response.ErrorMessage.Add(ex.Message);
                return UnprocessableEntity(_response);
            }
            return null;
        }

        //make function to get all users async
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
             var users = await _userRepository.GetAllUsers();
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = users;
            return Ok(_response);
        }
    }
}
