using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOLS_lab4.Models.Beasts
{
    public class Beast : ReactiveObject
    {
        [Reactive] public int Power { get; set; }
        public string Name { get; set; }
        public Beast(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override string ToString()
        {
            return $"{Name}, уровень силы {Power}";
        }
    }
}
