using System;
using System.Collections.Generic;
using System.Text;

namespace LinqOperations
{
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age{ get; set; }
        public HumanGender Gender { get; set; }
        public bool IsKid() => Age < 18;
        public List<Human> Relatives { get; } = new List<Human>();

    }
}
