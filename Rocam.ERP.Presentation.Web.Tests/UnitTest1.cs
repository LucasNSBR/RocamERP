using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocamERP.Domain.Models;
using System.Collections.Generic;

namespace Rocam.ERP.Presentation.Web.Tests
{
    [TestClass]
    public class MiscellanousTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cliente c = new ClientePessoaFisica()
            {
                CPF = "98911309672"
            };
            Cliente d = new ClientePessoaJuridica()
            {
                CNPJ = "22332811000122"
            };
            Cliente f = new ClientePessoaJuridica();

            Assert.AreNotEqual(c.GetType(), d.GetType());

            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(c);
            clientes.Add(d);
            Assert.AreEqual(d.GetRegistroFederal(), c.GetRegistroFederal());

            //Assert.AreNotEqual(clientes[0], clientes[1]);

            //Assert.AreEqual(c.GetType(), d.GetType());

        }
    }
}
