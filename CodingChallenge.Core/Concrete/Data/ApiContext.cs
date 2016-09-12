using CodingChallenge.Core.Abstract.Data;
using CodingChallenge.Core.Abstract.Repositories;
using CodingChallenge.Core.Concrete;
using CodingChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Concrete.Data
{
    public class ApiContext : IApiContext
    {
        Uri _baseAddress;
        public ApiContext(string apiBaseAddress)
        {
            _baseAddress = new Uri(apiBaseAddress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Returns an ApiResponse object. Check IsSuccessful property to
        /// validate the result
        /// </returns>
        public async Task<ApiResponse<List<Person>>> GetPeopleAsync()
        {
            ApiResponse<List<Person>> apiResponse = new ApiResponse<List<Person>>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/people.json");
                if (response.IsSuccessStatusCode)
                {
                    var people = await response.Content.ReadAsAsync<List<Person>>();

                    apiResponse.IsSuccess = response.IsSuccessStatusCode;
                    apiResponse.Data = people;
                }
                else
                    apiResponse.ErrorMessage = response.ReasonPhrase;
            }

            return apiResponse;
        }

    }
}
