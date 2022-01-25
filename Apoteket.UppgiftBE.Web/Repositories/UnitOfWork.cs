using Apoteket.UppgiftBE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apoteket.UppgiftBE.Web.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApotekContext db;
        public IProductRepository ProductRepository { get; set; }

        public UnitOfWork(ApotekContext db)
        {
            this.db = db;
            ProductRepository = new ProductRepository(db);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
