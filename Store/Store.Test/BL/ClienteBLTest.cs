using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.BusinessLogic.BL;
using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Test.BL
{
    [TestClass]
    public class ClienteBLTest
    {
        [TestMethod]
        public void Inserir()
        {
            using(var bl = new ClienteBL())
            {
                var cliente = new Cliente()
                {
                    Cpf = "11111111111",
                    Email = "diego_1souza@hotmail.com",
                    Nome = "Diego",
                    Senha = "diego"
                };

                cliente = bl.Inserir(cliente);
            }
        }

        [TestMethod]
        public void Atualizar()
        {
            using (var bl = new ClienteBL())
            {
                var cliente = bl.Consultar(1);
                cliente.Nome = "Diego de Souza";
                bl.Atualizar(cliente);
            }
        }

        [TestMethod]
        public void Consultar()
        {
            using (var bl = new ClienteBL())
            {
                var cliente = bl.Consultar(1);
            }
        }

        [TestMethod]
        public void Listar()
        {
            using (var bl = new ClienteBL())
            {
                var clientes = bl.Listar();
            }
        }

        [TestMethod]
        public void Logar()
        {
            using (var bl = new ClienteBL())
            {
                var cliente = new Cliente()
                {
                    Email = "diego_1souza@hotmail.com",
                    Senha = "diego"
                };

                var clienteLogado = bl.Logar(cliente);
            }
        }
    }
}
