using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Concrete
{
    public class ApiResponse<T> where T : class
    {
        public bool IsSuccess { get; set; } 

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }
}
