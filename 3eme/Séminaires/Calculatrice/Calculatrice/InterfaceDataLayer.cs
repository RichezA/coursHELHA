using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public interface InterfaceDataLayer
    {
        CompteBancaire RetrouverCompte(string nom);
    }
}
