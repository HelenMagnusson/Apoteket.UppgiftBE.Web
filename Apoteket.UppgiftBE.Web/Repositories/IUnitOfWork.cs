namespace Apoteket.UppgiftBE.Web.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }
        void SaveChanges();

    }
}