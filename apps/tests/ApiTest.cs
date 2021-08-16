using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using api;

namespace tests
{
    [TestClass]
    public class ApiTest
    {
        private static api.Repository.CNABRepository _cnabRepository;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            _cnabRepository = new api.Repository.CNABRepository("server=localhost;database=db_dev;user id=root;password=admin");
        }

        [TestMethod]
        public void GetCnabTest()
        {
            var cnabs = _cnabRepository.GetAll();
            Assert.IsTrue(cnabs != null);
        }

        [TestMethod]
        public async Task SaveCnabTest()
        {
            var cnabList = new List<api.Model.CNABModel>();
            TimeSpan.TryParseExact("101030", "hhmmss", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan cnabHour);
            cnabList.Add(
                new api.Model.CNABModel()
                {
                    IdTransactionType = 2,
                    Value = 10,
                    Cpf = "47586454988",
                    Card = "Cartão",
                    NameStore = "Loja Teste",
                    NameStoreOwner = "DonoLojaTeste",
                    DateOccurrence = DateTime.Now,
                    DateOccurrenceHour = cnabHour
                }
            );
            await _cnabRepository.SaveAll(cnabList);
            Assert.IsTrue(true);
        }
    }
}
