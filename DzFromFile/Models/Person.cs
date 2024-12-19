using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.Models
{
    class Person
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public Person(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Name} ({Role})";
        }
    }
}
