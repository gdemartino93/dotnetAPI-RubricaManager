using dotnetAPI_Rubrica.Data;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace dotnetAPI_Rubrica.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IContactRepository Contacts { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Contacts = new ContactRepository(_dbContext);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
