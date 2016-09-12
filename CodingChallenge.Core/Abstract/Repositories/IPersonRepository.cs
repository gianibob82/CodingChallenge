using CodingChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Abstract.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPetOwnersAsync();

        Task<IEnumerable<Person>> GetCatOwnersAsync();

        IEnumerable<Person> GetCatOwners(IEnumerable<Person> petOwners);
    }
}
