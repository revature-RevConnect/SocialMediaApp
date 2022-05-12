using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Database.DataAccess;


namespace RevConnectAPI.Tests
{
    internal class TestDB :IDisposable
    {

        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public RevConnectContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<RevConnectContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var testContext = new RevConnectContext(option);
            if (testContext != null)
            {
                testContext.Database.EnsureDeleted();
                testContext.Database.EnsureCreated();
            }

            return testContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
