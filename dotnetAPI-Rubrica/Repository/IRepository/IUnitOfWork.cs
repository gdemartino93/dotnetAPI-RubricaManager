namespace dotnetAPI_Rubrica.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository Contacts { get; }
        IUserRepository Users { get; }
        void Save();
    }
}
