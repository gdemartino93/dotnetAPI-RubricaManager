using dotnetAPI_Rubrica.Data;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Repository.IRepository;

namespace dotnetAPI_Rubrica.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _dbContact;
        public ContactRepository(ApplicationDbContext dbContact) : base(dbContact)
        {
            _dbContact = dbContact;
        }
        public async Task<Contact> UpdateContact(Contact contact)
        {
            contact.UpdatedAt = DateTime.Now;
            _dbContact.Contacts.Update(contact);
            await _dbContact.SaveChangesAsync();
            return contact;
        }
    }
}
