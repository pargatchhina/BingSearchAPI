using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSearch.BL.Classes;

namespace WebSearch.Tests
{
    [TestClass]
    public class QuerySearchExceptionArgsTest
    {
        [TestMethod]
        public void Cunstructor_Empty()
        {
            SearchedQuery query = new SearchedQuery("test");

            QuerySearchExceptionArgs args = new QuerySearchExceptionArgs(query);

            Assert.AreSame(query, args.SearchedQuery);
        }
    }
}
