using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Calculatrice.Tests
{
    [TestClass()]
    public class CompteBancaireTests
    {

        [TestInitialize]
        public void InitializeCB()
        {
            InterfaceDataLayer fausseIDAL = Mock.Of<InterfaceDataLayer>();

        }

        [TestMethod()]
        public void DebiterTest_Solde300PLusGrandQueMontant100_Retourne200()
        {
            CompteBancaire compteBancaire = new CompteBancaire(300);
            double montant = 100;
            double resultat;

            resultat = compteBancaire.Debiter(montant);

            Assert.AreEqual(200, resultat);
        }

        [TestMethod()]
        public void DebiterTest_Solde100PlusPetitQueMontant300_RenvoieArgumentOutOfRangeException()
        {
            CompteBancaire compteBancaire = new CompteBancaire(100);
            double montant = 300;

            Assert.ThrowsException<ArgumentOutOfRangeException>(new Action(() => {
                compteBancaire.Debiter(montant);
                }));
        }

        [TestMethod()]
        [ExpectedException(typeof(AccountBlockedException))]
        public void DebiterTest_EssaiDebitSurCompteBloque_Exception()
        {
            CompteBancaire compteBancaire = new CompteBancaire(300, true);
            double montant = 100;

            compteBancaire.Debiter(montant);
        }

        [TestMethod()]
        public void CrediterTest_CompteBloque_Exception()
        {
            CompteBancaire compteBancaire = new CompteBancaire(300, true);
            double montant = 150;

            Assert.ThrowsException<AccountBlockedException>(new Action(() =>
            {
                compteBancaire.Crediter(montant);
            }));
        }

        [TestMethod()]
        public void CrediterTest_MontantPlusPetit0_ArgumentOutOfRangeException()
        {
            CompteBancaire compteBancaire = new CompteBancaire(100);
            double montant = -5;

            Assert.ThrowsException<ArgumentOutOfRangeException>(new Action(() =>
            {
                compteBancaire.Crediter(montant);
            }));
        }

        [TestMethod()]
        public void CrediterTest_MontantPlusGrand0_RetourneSoldePlusMontant600()
        {
            CompteBancaire compte = new CompteBancaire(300);
            double montant = 300;
            double resultat;

            resultat = compte.Crediter(montant);

            Assert.AreEqual(600, resultat);
        }

        [TestMethod()]
        public void BloquerCompteTest_CompteDebloque_CompteBloque()
        {
            CompteBancaire compteBancaire = new CompteBancaire(300);

            compteBancaire.BloquerCompte();

            Assert.IsTrue(compteBancaire.estBloque);
        }

        [TestMethod()]
        public void DebloquerCompteTest_CompteBloque_CompteDebloque()
        {
            CompteBancaire compte = new CompteBancaire(300, true);

            compte.DebloquerCompte();

            Assert.IsFalse(compte.estBloque);
        }
    }
}