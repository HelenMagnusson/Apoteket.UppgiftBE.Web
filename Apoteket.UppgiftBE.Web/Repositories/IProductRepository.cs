// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

using Apoteket.UppgiftBE.Web.Models;
using System.Collections.Generic;

namespace Apoteket.UppgiftBE.Web.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetByID(int? id);
        Product Add(Product product);
        Product Remove(Product product);
    }
}

