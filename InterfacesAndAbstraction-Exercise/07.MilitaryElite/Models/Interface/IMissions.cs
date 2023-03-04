﻿using _07.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models.Interface
{
    public interface IMissions 
    {
        string CodeName { get; }
        State State { get; }

        public void CompleteMission();
    }
}