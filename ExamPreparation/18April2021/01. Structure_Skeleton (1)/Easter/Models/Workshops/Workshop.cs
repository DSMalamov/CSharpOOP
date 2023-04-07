using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            bool BreakCyckle = true;

            while (BreakCyckle)
            {
                BreakCyckle = true;

                foreach (var dye in bunny.Dyes) 
                {
                    if (bunny.Energy > 0 && !dye.IsFinished())
                    {
                        bunny.Work();
                        dye.Use();
                        egg.GetColored();
                        
                    }

                    if (egg.IsDone() || dye.IsFinished())
                    {
                        BreakCyckle = false;
                        break;

                    }
                }
                
                
            }
        }
    }
}
