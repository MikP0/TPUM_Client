using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;

namespace TPUM.Data.Repositiories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly DataContext _dataContext;

        public ClientRepository()
        {
            _dataContext = DbContext.Instance;
        }
        public ClientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Client Add(Client entity)
        {
            _dataContext.Clients.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Client client = _dataContext.Clients.FirstOrDefault(c => c.Id == id);
            _dataContext.Clients.Remove(client);
        }

        public IEnumerable<Client> Get()
        {
            return _dataContext.Clients;
        }

        public Client Get(int id)
        {
            return _dataContext.Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> Get(Func<Client, bool> filter)
        {
            return _dataContext.Clients.Where(filter).ToList();
        }

        public Client Update(int id, Client entity)
        {
            Client client = _dataContext.Clients.FirstOrDefault(c => c.Id == id);

            client.LastName = entity.LastName;
            client.Name = entity.Name;
            client.DateOfBirth = entity.DateOfBirth;
            client.Cart = entity.Cart;

            return client;
        }
    }
}
