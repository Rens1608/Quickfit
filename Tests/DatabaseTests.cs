using NUnit.Framework;
using DataLayer;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConnectionTest()
        {
            string expected = "Data Source=mssql.fhict.local;Initial Catalog=dbi414029;User ID=dbi414029;Password=***********";
            string actual = AppSettingsJson.GetConnectionstring();

            Assert.AreEqual(expected, actual);
        }
    }
}