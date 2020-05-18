using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPUM.Presentation.ViewModel;

namespace TPUM.Presentation.UnitTests
{
    [TestClass]
    public class MainViewModelUnitTest
    {
        [TestMethod]
        public void PropertyTest()
        {
            MainViewModel _vm = new MainViewModel();
            Assert.AreEqual(_vm.CurrentProduct.Id, 1);
            Assert.AreEqual(_vm.CurrentProduct.Name, "Super gra");
            Assert.AreEqual(_vm.CurrentProduct.Author, "DVD Project Blue");
        }

        [TestMethod]
        public void SetPricesTimerTest()
        {
            MainViewModel _vm = new MainViewModel();
            Assert.AreEqual(_vm.CurrentProduct.Price, 31.50f);
            float _rememberPrice = _vm.CurrentProduct.Price;

            _vm.SetPricesTimer();
            System.Threading.Thread.Sleep(3000);

            Assert.IsTrue(_vm.CurrentProduct.Price < _rememberPrice);
        }

        [TestMethod]
        public void DeleteCurrentProductTest()
        {
            MainViewModel _vm = new MainViewModel();
            Assert.AreEqual(_vm.Products.Count, 3);

            _vm.DeleteCurrentProduct();

            Assert.AreEqual(_vm.Products.Count, 2);
        }
    }
}
