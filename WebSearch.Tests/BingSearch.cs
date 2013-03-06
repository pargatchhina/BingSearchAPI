using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSearch.BL.Classes;

namespace WebSearch.Tests
{
    [TestClass]
    public class BingSearchTest
    {
        #region Constants

        private const string CnstUrl        = "https://api.datamarket.azure.com/Bing/SearchWeb/v1/";
        private const string CnstAccesskey  = "SET ACCESS KEY";

        #endregion

        private BingSearch _unitUnderTest;

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Cunstructor_Empty()
        {
            Assert.IsNotNull(new BingSearch());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Cunstructor_NullUri()
        {
            Assert.IsNotNull(new BingSearch(null));
        }

        [TestMethod]
        public void Cunstructor_NullQuery()
        {
            int querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CnstUrl))
                {
                    Credentials = new NetworkCredential(CnstAccesskey, CnstAccesskey)
                };

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++querySearchExceptionCount;

            _unitUnderTest.ExecuteAsync(null);

            Thread.Sleep(2000); //sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, querySearchExceptionCount);
        }

        [TestMethod]
        public void Cunstructor_NullQueryAndNoCredentials()
        {
            int querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CnstUrl));

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++querySearchExceptionCount;

            _unitUnderTest.ExecuteAsync(null);

            Thread.Sleep(2000); //sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, querySearchExceptionCount);
        }

        [TestMethod]
        public void Cunstructor_ValidQueryWithResponse()
        {
            int querySearchCompletedCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CnstUrl))
                {
                    Credentials = new NetworkCredential(CnstAccesskey, CnstAccesskey)
                };

            _unitUnderTest.QuerySearchCompletedAsync += (s, e) => ++querySearchCompletedCount;

            var query = new List<string> {"Xbox"};

            _unitUnderTest.ExecuteAsync(query);

            Thread.Sleep(2000); //sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, querySearchCompletedCount);
        }

        #region Async Event Tests

        [TestMethod]
        public void Search_QuerySearchCompletedAsyncEventsFires()
        {
            int querySearchCompletedCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CnstUrl));

            _unitUnderTest.QuerySearchCompletedAsync += (s, e) => ++querySearchCompletedCount;

            _unitUnderTest.Credentials = new NetworkCredential(CnstAccesskey, CnstAccesskey);

            var query = new List<string> {"xbox"};

            _unitUnderTest.ExecuteAsync(query);
            Thread.Sleep(2000); //sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, querySearchCompletedCount);
        }

        [TestMethod]
        public void Search_QuerySearchExceptionAsyncEventsFires()
        {
            int querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CnstUrl));

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++querySearchExceptionCount;

            _unitUnderTest.Credentials = new NetworkCredential("TESTKEY", "TESTKEY");

            var query = new List<string> {"xbox"};

            _unitUnderTest.ExecuteAsync(query);

            Thread.Sleep(2000); //sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, querySearchExceptionCount);
        }


        [TestMethod]
        public void Search_QuerySearchExceptionAsyncEventsFiresWrongUrl()
        {
            int querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri("http://localhost/"));

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++querySearchExceptionCount;

            _unitUnderTest.Credentials = new NetworkCredential(CnstAccesskey, CnstAccesskey);

            var query = new List<string> {"xbox"};

            _unitUnderTest.ExecuteAsync(query);

            Thread.Sleep(2000); //sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, querySearchExceptionCount);
        }

        #endregion
    }
}