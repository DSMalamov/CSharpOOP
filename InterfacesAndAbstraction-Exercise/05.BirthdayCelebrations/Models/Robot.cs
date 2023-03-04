using _04.BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl.Models;

public class Robot : IIdentifiable
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; private set; }
    public string Id { get; private set; }
}
