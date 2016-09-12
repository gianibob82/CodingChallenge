using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge.Core.Abstract.Repositories;
using Moq;
using CodingChallenge.Core.Abstract.Data;
using CodingChallenge.Core.Concrete.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CodingChallenge.Core.Models;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Core.Abstract.Services;

namespace CodingChallenge.Tests
{
    [TestClass]
    public class PetServiceTests
    {
        [TestMethod]
        public async Task ListCatNamesInAlphabeticalOrderGroupedByGenderAsync()
        {
            string s = System.Text.Encoding.UTF8.GetString(Resources.people, 0, Resources.people.Length);

            var context = JsonConvert.DeserializeObject<IEnumerable<Person>>(s);

            var apiContext = new Mock<IApiContext>();
            apiContext.Setup(api => api.GetPeopleAsync()).ReturnsAsync(new Core.Concrete.ApiResponse<List<Person>> {
                 Data = context.ToList(),
                   IsSuccess = true
            });

            IPersonRepository peopleRepo = new PersonRepository(apiContext.Object);

            var pets = await peopleRepo.GetCatOwnersAsync();

            Assert.IsNotNull(pets);
            Assert.AreNotEqual(pets.Count(), 0);

            IPetService petService = new PetService(peopleRepo);

            var result = await petService.ListCatNamesInAlphabeticalOrderGroupedByGenderAsync();

            Assert.AreEqual(result.Count, 2);

            Assert.AreNotEqual(result.First().CatNames, 0);
        }
    }
}

