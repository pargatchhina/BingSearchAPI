using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSearch.BL.Classes;

namespace WebSearch.Tests
{
    [TestClass]
    public class QuerySearchCompletedArgsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullArg()
        {
            new QuerySearchCompletedArgs(null);
        }
        
        [TestMethod]
        public void Constructor_ValidArg_SetsPublicProperty()
        {
            SearchedQuery page          = new SearchedQuery("xbox");
            QuerySearchCompletedArgs args = new QuerySearchCompletedArgs(page);

            Assert.AreSame(page, args.SearchedQuery);
        }

    }
}
