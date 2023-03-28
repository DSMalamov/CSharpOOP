using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite.Models.Interface;

public interface IGiftOperations
{
    void Add(GiftBase gift);
    void Remove(GiftBase gift);
}
