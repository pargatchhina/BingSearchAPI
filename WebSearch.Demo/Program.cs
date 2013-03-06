using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using WebSearch.BL.Classes;

namespace WebSearch.Demo
{
    internal class Program
    {
        #region Constants

        private const string CnstUrl        = "Bing.Url";
        private const string CnstAccesskey  = "Bing.AccessKey";

        #endregion

        private static void Main(string[] args)
        {
            var s = new List<string> {"Xbox"};

            var search = new BingSearch(new Uri(ConfigurationManager.AppSettings[CnstUrl]))
                {
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings[CnstAccesskey],
                                                        ConfigurationManager.AppSettings[CnstAccesskey])
                };

            search.QuerySearchCompletedAsync += search_QuerySearchCompletedAsync;
            search.QuerySearchExceptionAsync += search_QuerySearchExceptionAsync;

            search.ExecuteAsync(null);

            Console.ReadLine();
        }

        private static void search_QuerySearchExceptionAsync(object sender, QuerySearchExceptionArgs e)
        {
            SearchedQuery results = e.SearchedQuery;
            Console.WriteLine("Query: {0}, Exception: {1}", results.Query, results.Exception.Message);
        }

        private static void search_QuerySearchCompletedAsync(object sender, QuerySearchCompletedArgs e)
        {
            SearchedQuery results = e.SearchedQuery;

            foreach (QueryResult result in results.Result)
            {
                Console.WriteLine("Query: {0}, GUID: {1}, WebTotal: {2}", results.Query, result.ID, result.WebTotal);
            }
        }
    }
}