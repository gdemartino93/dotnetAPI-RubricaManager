using dotnetAPI_Rubrica.Models;
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
        private readonly IContactRepository _contactRepository;
        private readonly APIResponse _response;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _response = new APIResponse();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                List<Contact> contacts = await _contactRepository.GetAllAsync();
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
        
    }
}
