using dotnetAPI_Rubrica.Models;

namespace dotnetAPI_Rubrica.Repository.IRepository
{
    public interface IContactRepository : IRepository<Contact>
    {
       Task<Contact> UpdateContact(Contact contact);
    }
}
