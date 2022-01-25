// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

using Apoteket.UppgiftBE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apoteket.UppgiftBE.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApotekContext db;

        public ProductRepository(ApotekContext context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Product Add(Product product)
        {
            
            return db.Products.Add(product);
        }
       
        public Product Remove(Product product)
        {
            return db.Products.Remove(product);
        }

        public List<Product> GetAllProducts()
        {

            return db.Products.ToList();
        }
        public Product GetByID(int? id)
        {
            var allProducts = GetAllProducts();
            if (allProducts.Where(x => x.Id == id).Any())
            {
                return allProducts.First(x => x.Id == id);
            }
            else return null;
        }


        public List<Product> GetAllHardcodedProducts()
        {
            return new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Äpple",
                Price = 11.60
            },
            new Product()
            {
                Id = 2,
                Name = "Päron",
                Price = 1.60
            },
            new Product()
            {
                Id = 3,
                Name = "Plommon",
                Price = 4.50
            }
        };
        }




    }
 
    }