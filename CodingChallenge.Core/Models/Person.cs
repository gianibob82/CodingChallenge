using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Core.Models
{
    public class Person
    {
        public Person()
        {
            Pets = new List<Pet>();
        }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public byte Age { get; set; }

        public List<Pet> Pets { get; set; }
    }
}
