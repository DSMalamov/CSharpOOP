using _08.CollectionHierarchy.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private readonly List<string> data;
        public MyList()
        {
            data = new List<string>();
        }
        public int Used => data.Count;

        public int Add(string item)
        {
            data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string element = null;

            if (data.Count > 0)
            {
                element = data[0];
                data.RemoveAt(0);
            }

            return element;

        }
    }
}
