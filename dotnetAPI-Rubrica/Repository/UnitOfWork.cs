using AutoMapper;
using dotnetAPI_Rubrica.Data;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace dotnetAPI_Rubrica.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IContactRepository Contacts { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(IContactRepository contactRepository,IUserRepository userRepository)
        {
            Contacts = contactRepository;
            Users = userRepository;
        }
        public void Dispose()
        {
            Dispose();         
        }
        public void Save()
        {
            Contacts.SaveAsync();
        }
    }
}
