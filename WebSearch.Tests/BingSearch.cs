using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebSearch.BL.Classes;

namespace WebSearch.Tests
{
    [TestClass]
    public class BingSearchTest
    {
        #region Constants

        static string CNST_URL          = "https://api.datamarket.azure.com/Bing/SearchWeb/v1/";
        static string CNST_ACCESSKEY    = "SET ACCESS KEY";

        #endregion

        BingSearch _unitUnderTest;
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cunstructor_Empty()
        {
            Assert.IsNotNull(new BingSearch());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cunstructor_NullUri()
        {
            Assert.IsNotNull(new BingSearch(null));
        }

        [TestMethod]
        public void Cunstructor_NullQuery()
        {
            int _querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CNST_URL));

            _unitUnderTest.Credentials = new NetworkCredential(CNST_ACCESSKEY, CNST_ACCESSKEY);

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++_querySearchExceptionCount;

            _unitUnderTest.ExecuteAsync(null);

            System.Threading.Thread.Sleep(2000);//sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, _querySearchExceptionCount);
        }

        [TestMethod]
        public void Cunstructor_NullQueryAndNoCredentials()
        {
            int _querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CNST_URL));

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++_querySearchExceptionCount;

            _unitUnderTest.ExecuteAsync(null);

            System.Threading.Thread.Sleep(2000);//sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, _querySearchExceptionCount);
        }

        [TestMethod]
        public void Cunstructor_ValidQueryWithResponse()
        {
            int _querySearchCompletedCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CNST_URL));

            _unitUnderTest.Credentials = new NetworkCredential(CNST_ACCESSKEY, CNST_ACCESSKEY);

            _unitUnderTest.QuerySearchCompletedAsync += (s, e) => ++_querySearchCompletedCount;

            List<string> query = new List<string>();
            query.Add("Xbox");

            _unitUnderTest.ExecuteAsync(query);

            System.Threading.Thread.Sleep(2000);//sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, _querySearchCompletedCount);
        }



        #region Async Event Tests
        
        [TestMethod]
        public void Search_QuerySearchCompletedAsyncEventsFires()
        {
            int _querySearchCompletedCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CNST_URL));

            _unitUnderTest.QuerySearchCompletedAsync += (s, e) => ++_querySearchCompletedCount;

            _unitUnderTest.Credentials = new NetworkCredential(CNST_ACCESSKEY, CNST_ACCESSKEY);

            List<string> query = new List<string>();
            query.Add("xbox");

            _unitUnderTest.ExecuteAsync(query);
            System.Threading.Thread.Sleep(2000);//sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, _querySearchCompletedCount);
        }

        [TestMethod]
        public void Search_QuerySearchExceptionAsyncEventsFires()
        {
            int _querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri(CNST_URL));

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++_querySearchExceptionCount;

            _unitUnderTest.Credentials = new NetworkCredential("TESTKEY", "TESTKEY");

            List<string> query = new List<string>();
            query.Add("xbox");

            _unitUnderTest.ExecuteAsync(query);

            System.Threading.Thread.Sleep(2000);//sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, _querySearchExceptionCount);
        }


        [TestMethod]
        public void Search_QuerySearchExceptionAsyncEventsFiresWrongUrl()
        {
            int _querySearchExceptionCount = 0;

            _unitUnderTest = new BingSearch(new Uri("http://localhost/"));

            _unitUnderTest.QuerySearchExceptionAsync += (s, e) => ++_querySearchExceptionCount;

            _unitUnderTest.Credentials = new NetworkCredential(CNST_ACCESSKEY, CNST_ACCESSKEY);

            List<string> query = new List<string>();
            query.Add("xbox");

            _unitUnderTest.ExecuteAsync(query);

            System.Threading.Thread.Sleep(2000);//sleep since the events are async and may not complete before returning

            Assert.AreEqual(1, _querySearchExceptionCount);
        }

        #endregion
    }
}
