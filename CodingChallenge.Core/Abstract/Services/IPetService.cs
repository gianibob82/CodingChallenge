using CodingChallenge.Core.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Abstract.Services
{
    public interface IPetService
    {
        Task<List<CatsByOwnerGenderResponseData>> ListCatNamesInAlphabeticalOrderGroupedByGenderAsync();
    }
}
