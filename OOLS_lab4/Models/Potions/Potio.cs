using OOLS_lab4.Models.Beasts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOLS_lab4.Models.Potions
{
    public abstract class Potio
    {
        public Potio()
        {

        }
        public bool IsIncreasePower { get; set; }
        protected abstract double coefficient { get; }
        public void TakePotio(Beast beast)
        {
            beast.Power = (int) Math.Round(beast.Power* coefficient);
        }
    }
}
