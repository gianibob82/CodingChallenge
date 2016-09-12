using CodingChallenge.Core.Concrete;
using CodingChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Abstract.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApiContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Returns an ApiResponse object. Check IsSuccessful property to
        /// validate the result
        /// </returns>
        Task<ApiResponse<List<Person>>> GetPeopleAsync();
    }
}
