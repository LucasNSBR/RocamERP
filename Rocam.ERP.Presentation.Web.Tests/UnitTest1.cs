using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using RocamERP.Domain.Models;
using System.Collections.Generic;
using RocamERP.Infra.Data.Repositories;
using System.Linq;
using RocamERP.Presentation.Web.Areas.Plataforma.Controllers;
using RocamERP.Infra.Data.QuerySpecifications;
using RocamERP.Infra.Data.QuerySpecifications.CidadeQuerySpecifications;
using AutoMapper;
using RocamERP.Presentation.Web.ViewModels.PessoaViewModels;
using System.Text;

namespace Rocam.ERP.Presentation.Web.Tests
{
    [TestClass]
    public class MiscellanousTests
    {
        [TestMethod]    
        public void UrlTests()
        {
            var token = "123";
            var url = "http://localhost:57756/Manage/ConfirmEmail";
            var body = new StringBuilder();
            body.Append($"<a href=\"{url}?token={token}\">");
            body.Append($"</a>");

            Assert.AreEqual("<a href=\"http://localhost:57756/Manage/ConfirmEmail?token=123\"></a>", body.ToString());
        }

        [TestMethod]
        public void BoolTests()
        {
            Cheque c = new Cheque()
            {
                DataVencimento = DateTime.Now.AddYears(-1)
            };

            Trace.WriteLine(c.DataVencimento);
           // Assert.AreEqual(true, c.ChequeVencido);

        }

        [TestMethod]
        public void ReflectionTests()
        {
            Pessoa _pessoa = new Pessoa()
            {
                Nome = "Lucas Pereira"
            };

            PessoaViewModel _pessoaVM = new PessoaViewModel()
            {
                Nome = "Lucas Pereira"
            };

            Type _sourceType = typeof(Pessoa);
            Type _destionationType = typeof(PessoaViewModel);

            var obj = _sourceType.GetConstructor(new Type[] { });
            var p = obj.Invoke(new object[] { });


            var mapped = Mapper.Map(_sourceType.GetType(), _destionationType.GetType());

            Assert.AreEqual(typeof(Pessoa), mapped.GetType());

        }

        [TestMethod]
        public void MyTestMethod()
        {
            List<Cidade> Cidades = new List<Cidade> {
                new Cidade()
                {
                    Nome = "Nova Serrana"
                },
                new Cidade()
                {
                    Nome = "Belo Horizonte"
                },
                new Cidade()
                {
                    Nome = "Perdigão"
                },
                new Cidade()
                {
                    Nome = "Vila Cruzeiro"
                },
            };

            //NomeCidadeEspecification spec = new NomeCidadeEspecification("o");
            //sNomeCidadeEspecification specTwo = new NomeCidadeEspecification("z");

            //var list = Cidades.AsQueryable().Where(spec.And(specTwo).ToExpression());
            //var lists = Cidades.Where(c => spec.IsSatisfiedBy(c));

            //Assert.AreEqual(2, list.Count());
            ////Assert.AreEqual("Vila Cruzeiro", list.First().Nome);
        }

        [TestMethod]
        public void TestConvert()
        {
            var x = new { aclass = "btn btn-primary", type = "submit" };
            var props = x.GetType();

            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (var v in props.GetProperties())
            {
                values.Add(v.Name, (string)v.GetValue(x, null));
            }
            
            foreach(var v in values)
            {
                Trace.WriteLine($"Key: {v.Key}");
                Trace.WriteLine($"Value: {v.Value}");
            }
        }

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
