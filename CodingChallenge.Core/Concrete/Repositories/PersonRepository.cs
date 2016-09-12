using CodingChallenge.Core.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Core.Models;
using CodingChallenge.Core.Abstract.Data;
using CodingChallenge.Core.Exceptions;

namespace CodingChallenge.Core.Concrete.Services
{
    public class PersonRepository : IPersonRepository
    {
        IApiContext _context;
        public PersonRepository(IApiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetPetOwnersAsync()
        {
            var response  = await _context.GetPeopleAsync();
            if (response.IsSuccess)
                return response.Data.Where(o => o.Pets != null);

            throw new ApiConnectionException("api connection error: " + response.ErrorMessage);
        }

        public async Task<IEnumerable<Person>> GetCatOwnersAsync()
        {
            var petOwners = await GetPetOwnersAsync();
            return GetCatOwners(petOwners);
        }

        public IEnumerable<Person> GetCatOwners(IEnumerable<Person> petOwners)
        {
            var catOwners = petOwners.Where(o => o.Pets.Any(p => p.Type == PetType.Cat));
            return catOwners;
        }
    }
}
