using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocamERP.Domain.Models;
using System.Collections.Generic;
using RocamERP.Infra.Data.Repositories;
using System.Linq;

namespace Rocam.ERP.Presentation.Web.Tests
{
    [TestClass]
    public class MiscellanousTests
    {
        [TestMethod]
        public void TestValidation()
        {
            List<Pessoa> pr = new List<Pessoa>()
            {
                new Pessoa()
                {
                    CadastroEstadual = new CadastroEstadual()
                    {
                        NumeroDocumento = "223328110001222"
                    },
                     CadastroNacional = new CadastroNacional()
                     {
                         NumeroDocumento = "98911309672"
                     },
                },
                new Pessoa()
                {
                    CadastroEstadual = new CadastroEstadual()
                    {
                        NumeroDocumento = "555555"
                    },

                     CadastroNacional = new CadastroNacional()
                     {
                         NumeroDocumento = "13936618666"
                     },
                }
            };

            string value = "555555";

            var result = pr.Any(p =>
            {
                if (p.CadastroEstadual != null && p.CadastroEstadual.NumeroDocumento == value)
                    return true;
                else
                    return false;
            });

            var resultNacional = pr.Any(p =>
            {
                if (p.CadastroNacional != null && p.CadastroNacional.NumeroDocumento == value)
                    return true;
                else
                    return false;
            });

            Assert.AreEqual(true, result);
        }
    }
}
