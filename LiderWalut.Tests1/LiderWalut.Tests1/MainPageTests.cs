using NUnit.Framework;
using LiderWalut.Tests;
using System.Collections.Generic;

namespace LiderWalut.Tests1
{

    [TestFixture]
    public class MainPageTests
    {
        static MainPage browser = new MainPage();

        [SetUp]
        public void Initialize()
        {

            browser.Navigate();
            browser.MaximizeWindow();
            browser.Wait();
        }

        [Test]
        public void CheckTransactionsLabelsAfterSwitchingTransactionTabs()
        {
            var listTitles = new List<string>();
            var listExpected = new List<string>();

            browser.ClickButton(MainPage.actionBuy);
            listTitles = browser.GetTitles();
            listExpected = new List<string>(new string[] { "WYSYŁASZ", "KURS WYMIANY", "KUPUJESZ" });
            CollectionAssert.AreEqual(listTitles, listExpected, "Labels for buy method are not as expected");

            browser.ClickButton(MainPage.actionSell);
            listTitles = browser.GetTitles();
            listExpected = new List<string>(new string[] { "SPRZEDAJESZ", "KURS WYMIANY", "OTRZYMUJESZ" });
            CollectionAssert.AreEqual(listTitles, listExpected, "Labels for sell method are not as expected");

            browser.ClickButton(MainPage.actionChange);
            listTitles = browser.GetTitles();
            listExpected = new List<string>(new string[] { "SPRZEDAJESZ", "KURS WYMIANY", "KUPUJESZ" });
            CollectionAssert.AreEqual(listTitles, listExpected, "Labels for change method are not as expected");
        }

        [TearDown]
        public void TearDown()
        {
            browser.Teardown();
        }
    }

}
