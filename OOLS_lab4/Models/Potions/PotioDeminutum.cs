using OOLS_lab4.Models.Beasts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOLS_lab4.Models.Potions
{
    class PotioDeminutum : Potio
    {
        protected override double coefficient => 0.75;

        public void TakeShakedPotio(Beast beast)
        {
            beast.Power = (int)Math.Round(beast.Power * 0.5);
        }
    }
}
