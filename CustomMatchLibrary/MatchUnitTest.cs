﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomMatchLibrary
{
    using Domain;
    using DataTransferObjects;

    [TestClass]
    public class MatchUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Iphone X",
                Price = 6600,
                Category = new Category
                {
                    Id = 3,
                    CategoryName = "Tecnology",
                    SubCategory = new SubCategory { Id = 20 }
                }
            };


            var dtoObject = product.Match<ProductDTO>();
        }

        [TestMethod]
        public void TestMethodDifferentPropNames()
        {
            Token token = new Token();
            token.access_token = Guid.NewGuid().ToString();
            token.token_type = "2";

            var dtoObject = token.Match<TokenDTO>();
        }
    }
}
