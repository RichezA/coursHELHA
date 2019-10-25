using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class CompteBancaire
    {
        public string nomBanque { get; set; }
        public double solde { get; private set; }
        public Boolean estBloque { get; set; }

        public CompteBancaire(double solde) : this("RICHEZ", solde) { }

        public CompteBancaire(double solde, Boolean estBloque) : this("RICHEZ", solde, estBloque) { }

        public CompteBancaire(string nomBanque = "AXA", double solde = 300, Boolean estBloque = false)
        {
            this.nomBanque = nomBanque;
            this.solde = solde;
            this.estBloque = estBloque;
        }

        public double Debiter(double montant)
        {
            if (montant <= solde && !this.estBloque)
            {
                this.solde -= montant;
                return this.solde;
            }
            else if (this.estBloque) throw new AccountBlockedException();
            else throw new ArgumentOutOfRangeException(string.Format("Le montant est plus grand que le solde restant: {0}", this.solde));
        }

        public double Crediter(double montant)
        {
            if (montant < 0) throw new ArgumentOutOfRangeException(String.Format("Le montant est plus petit que le montant minimum: {0}", montant));
            else if (!this.estBloque) return this.solde += montant;
            throw new AccountBlockedException();
        }

        public void BloquerCompte()
        {
            if (this.estBloque) throw new AccountBlockedException();
            this.estBloque = true;
        }

        public void DebloquerCompte()
        {
            if (!this.estBloque) throw new AccountBlockedException();
            this.estBloque = false;
        }
    }

    public class AccountUnBlockedException : Exception
    {
    
    }
    public class AccountBlockedException : Exception
    {

    }
}
