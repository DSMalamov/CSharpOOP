﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int bateries)
        {
            Model = model;
            Color = color;
            Bateries = bateries;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Bateries { get; private set; }
        

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Bateries} Batteries{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
        }
    }
}
