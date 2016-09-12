using CodingChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Dto.Response
{
    public class CatsByOwnerGenderResponseData
    {
        public CatsByOwnerGenderResponseData()
        {
            CatNames = new List<string>();
        }

        public Gender Gender { get; set; }

        public List<string> CatNames { get; set; }
    }


}
