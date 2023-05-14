using AutoMapper;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
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
        [HttpGet("GetContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetContacts(int pageSize = 3, int currentPage = 1)
        {
            try
            {
                //recupero tutti i contatti in modo da poterli contare e calcolare il numero di pagine totali
                List<Contact> allContacts = await _unitOfWork.Contacts.GetAllAsync();
                //calcolo il numero di pagine totali in base agli elementi totali e la dimensione della pagina arrotondando per eccesso
                int totalPage = (int)Math.Ceiling(allContacts.Count / (double)pageSize);
                //aggiungo il numero di pagine totale alla risposta api in modo da poter essere consumato nel fe
                _response.TotalPage = totalPage;
                //aggiungo la pagina corrente alla risposta api in modo da poter essere consumato nel fe
                _response.CurrentPage = currentPage;

               List<Contact> contacts = await _unitOfWork.Contacts.GetAllAsync(pageSize:pageSize,currentPage:currentPage);

                _response.Result = contacts.Count == 0 ? "Nessun risultato" : contacts;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Errore durante la ricerca dei contatti");
                return BadRequest(_response);
            }
        }
        [HttpGet("GetContactsWithUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetContactsWithUser()
        {
            try
            {
                List<Contact> contacts = await _unitOfWork.Contacts.GetAllAsync(includeProperties: "User");
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]


        [HttpPost("CreateContact")]
        public async Task<ActionResult<APIResponse>> CreateContact([FromBody]ContactCreateDTO dto)
        {
            try
            {
                if(!StaticData.Validation.IsValidEmail(dto.Email))
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    _response.ErrorMessage.Add("Email non valida");
                    return BadRequest(_response);
                }
                if(!StaticData.Validation.IsValidTelephone(dto.TelephoneNumber))
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    _response.ErrorMessage.Add("Numero di telefono non valido");
                    return BadRequest(_response);
                }
                if(dto.Id is not 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    _response.ErrorMessage.Add("Esiste già un contatto con questo ID.");
                    return BadRequest(_response);
                }
                if(dto is null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage.Add("Contatto non valido");
                    return BadRequest(_response);
                }
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

        [HttpDelete("DeleteContact/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteContact(int id)
        {
            Contact contact = await _unitOfWork.Contacts.GetAsync(a => a.Id == id);
            if(contact is null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Contatto non trovato");
                return BadRequest(_response);
            }
            await _unitOfWork.Contacts.DeleteAsync(contact);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = "Contatto eliminato";
            return Ok(_response);
            

        }

        [HttpGet("GetContact/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetContact(int id)
        {
            try
            {
                Contact contact = await _unitOfWork.Contacts.GetAsync(a => a.Id == id);
                if(contact is null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage.Add("Contatto non trovato");
                    return BadRequest(_response);
                }
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = contact;
                return Ok(_response);
            }
            catch (Exception)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Errore durante la ricerca del contatto");
                return BadRequest(_response);
            }
        }

        [HttpGet("GetContact/{}")]
        public async Task<ActionResult<APIResponse> 

    }
}
