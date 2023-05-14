using AutoMapper;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace dotnetAPI_Rubrica.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ContactsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly APIResponse _response;
        private readonly IMapper _mapper;
        public ContactsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _response = new APIResponse();
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                List<Contact> contacts = await _unitOfWork.Contacts.GetAllAsync();
                //se il count è 0 allora restituisco un messaggio
                _response.Result = contacts.Count == 0 ? "Nessun risultato" : contacts;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessage.Add(ex.Message);
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

        }
        [HttpPost("CreateContact")]
        public async Task<ActionResult<APIResponse>> CreateContact([FromBody]ContactCreateDTO dto)
        {
            try
            {
               Contact newContact = _mapper.Map<Contact>(dto);
                await _unitOfWork.Contacts.CreateAsync(newContact);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = newContact;
                return Ok(_response);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Errore durante la creazione del contatto");
                return BadRequest(_response);
            }
        }
        
    }
}
