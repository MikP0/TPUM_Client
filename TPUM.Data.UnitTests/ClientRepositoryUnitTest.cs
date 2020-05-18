using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Data.Model;
using TPUM.Data.Repositiories;

namespace TPUM.Data.UnitTests
{
    [TestClass]
    public class ClientRepositoryUnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            DataContext dataContext = new DataContext { Clients = new List<Client>() };
            ClientRepository ClientRepository = new ClientRepository(dataContext);
            Assert.IsNotNull(ClientRepository);
        }

        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext { Clients = new List<Client>() };
            ClientRepository ClientRepository = new ClientRepository(dataContext);
            IEnumerable<Client> Clients = ClientRepository.Get();
            Assert.IsNotNull(Clients);
        }
        [TestMethod]
        public void AddTest()
        {
            DataContext dataContext = new DataContext { Clients = new List<Client>() };
            ClientRepository ClientRepository = new ClientRepository(dataContext);
            Client client = new Client
            {
                Id = -1,
                DateOfBirth = new DateTime(1990, 1, 1),
                Cart = new Cart(),
                Name = "John",
                LastName = "Doe"
            };

            ClientRepository.Add(client);
            Assert.IsNotNull(ClientRepository.Get(-1));
        }
        [TestMethod]
        public void DeleteTest()
        {
            DataContext dataContext = new DataContext { Clients = new List<Client>() };
            ClientRepository ClientRepository = new ClientRepository(dataContext);
            Client client = new Client
            {
                Id = -1,
                DateOfBirth = new DateTime(1990, 1, 1),
                Cart = new Cart(),
                Name = "John",
                LastName = "Doe"
            };
            ClientRepository.Add(client);
            ClientRepository.Delete(-1);

            Assert.AreEqual(0, ClientRepository.Get().ToList().Count());
        }

        [TestMethod]
        public void FilterTest()
        {
            DataContext dataContext = new DataContext { Clients = new List<Client>() };
            ClientRepository ClientRepository = new ClientRepository(dataContext);
            Client client = new Client
            {
                Id = -1,
                DateOfBirth = new DateTime(1990, 1, 1),
                Cart = new Cart(),
                Name = "John",
                LastName = "Doe"
            };
            Client client2 = new Client
            {
                Id = -2,
                DateOfBirth = new DateTime(1991, 1, 1),
                Cart = new Cart(),
                Name = "Jack",
                LastName = "Sparrow"
            };
            ClientRepository.Add(client);
            ClientRepository.Add(client2);

            List<Client> clients = ClientRepository.Get(c => c.DateOfBirth == new DateTime(1990, 1, 1)).ToList();
            Assert.AreEqual(1, clients.Count());
            
        }
        [TestMethod]
        public void UpdateTest()
        {
            DataContext dataContext = new DataContext { Clients = new List<Client>() };
            ClientRepository ClientRepository = new ClientRepository(dataContext);
            Client client = new Client
            {
                Id = -1,
                DateOfBirth = new DateTime(1990, 1, 1),
                Cart = new Cart(),
                Name = "John",
                LastName = "Doe"
            };
            ClientRepository.Add(client);

            string newName = "Jack";
            Client client2 = new Client
            {
                Id = -1,
                DateOfBirth = new DateTime(1990, 1, 1),
                Cart = new Cart(),
                Name = newName,
                LastName = "Doe"
            };
            ClientRepository.Update(-1, client2);
            Assert.AreEqual(newName, ClientRepository.Get(-1).Name);
        }
    }
}
