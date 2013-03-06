using System;

namespace WebSearch.BL.Classes
{
    /// <summary>
    ///     it holds the result returned from bing using Composite method
    /// </summary>
    public class QueryResult
    {
        #region Cunstructor

        #endregion

        #region Properites

        /// <summary>
        ///     GUID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        ///     WebTotal
        /// </summary>
        public long? WebTotal { get; set; }

        #endregion
    }
}