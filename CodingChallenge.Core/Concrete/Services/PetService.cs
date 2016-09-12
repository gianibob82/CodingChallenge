using CodingChallenge.Core.Abstract.Repositories;
using CodingChallenge.Core.Abstract.Services;
using CodingChallenge.Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Concrete.Services
{
    public class PetService : IPetService
    {
        IPersonRepository _peopleRepo;
        public PetService(IPersonRepository peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public async Task<List<CatsByOwnerGenderResponseData>> ListCatNamesInAlphabeticalOrderGroupedByGenderAsync()
        {
            var catOwners = await _peopleRepo.GetCatOwnersAsync();

            return catOwners.GroupBy(o => o.Gender)
                .Select(g => new CatsByOwnerGenderResponseData
                {
                    Gender = g.Key,
                    CatNames = catOwners.SelectMany(people => people.Pets).Select(p => p.Name).OrderBy(n => n).ToList()
                }).ToList();
        }
    }
}
