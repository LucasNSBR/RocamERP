using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocamERP.Domain.Models;
using System.Collections.Generic;
using RocamERP.Infra.Data.Repositories;

namespace Rocam.ERP.Presentation.Web.Tests
{
    [TestClass]
    public class MiscellanousTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string c ="";
            string d ="";

            Assert.AreNotEqual(c.GetType(), d.GetType());

            List<Pessoa> clientes = new List<Pessoa>();
        
            
            

           // Assert.AreEqual(d.GetRegistroFederal(), c.GetRegistroFederal());

            //Assert.AreNotEqual(clientes[0], clientes[1]);

            //Assert.AreEqual(c.GetType(), d.GetType());

        }

        [TestMethod]
        public void Tests()
        {
            DateTime d = new DateTime();
            d = DateTime.Now.AddYears(1);

            System.Diagnostics.Debug.WriteLine("Data: " + d.ToShortDateString());
            Assert.AreEqual(d, d);
        }
    }
}
