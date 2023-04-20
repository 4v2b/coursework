using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class JsonSerializerTest
    {
        [TestMethod]
        public void Deserialize_throws_FileNotFoundException_when_file_does_not_exist()
        {
            //Arrange
            string file = $"file{new Random().Next(10000)}.json";

            //Act + Assert
            Assert.ThrowsException<FileNotFoundException>(()=> JsonSerializer<Promotion>.Deserialize(file));
                    
        }

        [TestMethod]
        public void Deserialize_returns_collection_when_file_is_correct()
        {
            //Arrange
            string file = $"file{new Random().Next(10000)}.json";
            JsonSerializer<Promotion>.Serialize(file, GetPromoList());
            var list = new List<Promotion>();

            //Act
            list = JsonSerializer<Promotion>.Deserialize(file);

            //Assert
            Assert.IsNotNull(list);

        }

        [TestMethod]
        public void Serialize_write_json_in_file_when_collection_not_null()
        {
            //Arrange
            string file = $"file{new Random().Next(10000)}.json";

            //Act
            JsonSerializer<Promotion>.Serialize(file,GetPromoList());

            //Assert
            Assert.IsNotNull(JsonSerializer<Promotion>.Deserialize(file));
        }

        [TestMethod]
        public void Serialize_throws_ArgumentException_when_file_name_is_empty()
        {
            //Arrange
            string file = "";

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => JsonSerializer<Promotion>.Serialize(file, GetPromoList()));

        }

        [TestMethod]
        public void Serialize_throws_ArgumentException_when_collection_is_null()
        {
            //Arrange
            string file = "test.json";
            List<Promotion> list = null;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => JsonSerializer<Promotion>.Serialize(file, list));

        }

        public List<Promotion> GetPromoList()
        {
            return new List<Promotion>()
            {
                new SpecialOffer()
            {
                Url = "http://localhost"
            },
            new PromoСode()
            {
                Code = "000000",
            }
            };
        }

    }
}
