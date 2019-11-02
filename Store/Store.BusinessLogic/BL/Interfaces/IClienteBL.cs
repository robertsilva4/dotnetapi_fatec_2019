using Store.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.BL.Interfaces
{
    public interface IClienteBL : IDisposable
    {
        Cliente Inserir(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        List<Cliente> Listar();
        Cliente Consultar(int idCliente);
        Cliente Logar(Cliente cliente);
    }
}
