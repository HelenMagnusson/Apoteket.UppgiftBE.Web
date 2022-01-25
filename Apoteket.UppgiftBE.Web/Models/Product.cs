
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Apoteket.UppgiftBE.Web.Models
{
    public class ApotekContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

    }

    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double? Price { get; set; }
        public Product()
        {

        }
    }
}