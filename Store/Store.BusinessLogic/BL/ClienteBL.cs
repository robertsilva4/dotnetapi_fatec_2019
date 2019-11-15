using Store.BusinessLogic.BL.Interfaces;
using Store.Model.Entities;
using Store.Model.Infrastucture.DataAcess;
using Store.Model.Infrastucture.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.BL
{
    public class ClienteBL : IClienteBL
    {
        private ClienteDao _clienteDao;

        public ClienteBL()
        {
            this._clienteDao = new ClienteDao();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            cliente.Senha = HashMD5.GetHash(cliente.Senha);
            return this._clienteDao.Update(cliente);
        }

        public Cliente Consultar(int idCliente)
        {
            return this._clienteDao.Select(idCliente);
        }

        public Cliente Inserir(Cliente cliente)
        {
            cliente.Senha = HashMD5.GetHash(cliente.Senha);
            return this._clienteDao.Insert(cliente);
        }

        public List<Cliente> Listar()
        {
            return this._clienteDao.Select();
        }

        public Cliente Logar(Cliente cliente)
        {
            cliente.Senha = HashMD5.GetHash(cliente.Senha);
            return this._clienteDao.Select(cliente);
        }

        public void Dispose()
        {
            this._clienteDao.Dispose();
        }
    }
}
