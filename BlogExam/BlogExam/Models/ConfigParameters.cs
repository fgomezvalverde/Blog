using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogExam.Models
{
    /// <summary>
    /// THis class is for manage the configuration variables
    /// </summary>
    public static class ConfigParameters
    {
        /// <summary>
        /// In the section of latest post, its to know the number of latest POST
        /// </summary>
        public static int AMOUNT_LATEST_POST = 6;

        /// <summary>
        /// To show the number of posts in a single page
        /// </summary>
        public static int AMOUNT_POST_BY_PAGE = 5;
    }
}