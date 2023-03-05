using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy.Models.Interface
{
    public interface IMyList : IAddRemoveCollection
    {
        public int Used { get;}

    }
}
