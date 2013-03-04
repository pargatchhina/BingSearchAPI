using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSearch.BL.Classes;

namespace WebSearch.Demo
{
    class Program
    {
        #region Constants

        static string CNST_URL          = "Bing.Url";
        static string CNST_ACCESSKEY    = "Bing.AccessKey";

        #endregion

        static void Main(string[] args)
        {
            List<string> s = new List<string>();

            s.Add("Xbox");
            s.Add("PS3");
            s.Add("PS4");
            s.Add("JustEat");
            s.Add("Neetu");
            s.Add("Pargat");
            s.Add("Yuvraj");

            BingSearch search                   = new BingSearch(new Uri(ConfigurationManager.AppSettings[CNST_URL]));
            search.Credentials                  = new NetworkCredential(ConfigurationManager.AppSettings[CNST_ACCESSKEY], ConfigurationManager.AppSettings[CNST_ACCESSKEY]);

            search.QuerySearchCompletedAsync    += search_QuerySearchCompletedAsync;
            search.QuerySearchExceptionAsync    += search_QuerySearchExceptionAsync;

            search.ExecuteAsync(null);

            Console.ReadLine();
        }

        static void search_QuerySearchExceptionAsync(object sender, QuerySearchExceptionArgs e)
        {
            SearchedQuery results = e.SearchedQuery;
            Console.WriteLine("Query: {0}, Exception: {1}", results.Query, results.Exception.Message);
        }

        static void search_QuerySearchCompletedAsync(object sender, QuerySearchCompletedArgs e)
        {
            SearchedQuery results = e.SearchedQuery;

            foreach (var result in results.Result)
            {
                Console.WriteLine("Query: {0}, GUID: {1}, WebTotal: {2}", results.Query, result.ID, result.WebTotal);
            }
        }
    }
}
