BingSearchAPI
=============

Bing API Client Library is used to make queries and fetches the data using async and await methods. The benefit of using these methods are that it can make hundereds of queries asynchronously without blocking the main thread. I used Bing's API as it allows users to make 5000 transactions/queries for free and on the other hand google allows only 100 queries for free.

BingSearch is the main class from "WebSearch.BL" project which makes calls to Bing API, it inherits a proxy class and an interface. This base proxy class can be downloaded through their website which makes the process bit easy to fetch the results and An interface contains only the signatures of events.


BingSearc events
================
QuerySearchCompletedAsync: It gets called when query finish executing.
QuerySearchExceptionAsync: It catches exceptions while making exception.


Projects
========
These projects are created using Visual Studio 2012, which are:
1. WebService.BL contains core libraries
2. WebService.Demo is a Console application to make calls to Bing API
3. WebService.Test contains different test casses


Steps to test Console Application
=================================
1. Set Bing API AccessKey to Bing.AccessKey in App.config file of Console application
2. you can add 100s of queries one by one to the query List i.e. queries.Add("PS4") before calling ExecuteAsync method of BingSearch class
