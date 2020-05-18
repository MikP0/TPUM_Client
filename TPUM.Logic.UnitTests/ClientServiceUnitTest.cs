using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPUM.Logic.DTOs;
using TPUM.Logic.Services;

namespace TPUM.Logic.UnitTests
{
    [TestClass]
    public class ClientServiceUnitTest
    {
        [TestMethod]
        public void GetUserUnitTest()
        {
            ClientService _ClientService = new ClientService();
            Assert.AreEqual(_ClientService.GetUser(1).Result.Name, "Jan");
        }

        [TestMethod]
        public void GetUsersUnitTest()
        {
            ClientService _ClientService = new ClientService();

            Task<IEnumerable<ClientDTO>> _Clients = _ClientService.GetUsers();

            Assert.AreEqual(_Clients.Result.Count(), 1);
        }

        [TestMethod]
        public void GetUsersByAgeUnitTest()
        {
            ClientService _ClientService = new ClientService();

            Task<IEnumerable<ClientDTO>> _Clients = _ClientService.GetUsersByAge(23);

            Assert.AreEqual(_Clients.Result.Count(), 1);
        }
    }
}
