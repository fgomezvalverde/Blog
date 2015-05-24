﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BlogExam.Models
{
    /// <summary>
    /// This is the Base of all, he is used to take the mold of the POST.
    /// ID = autogenerated, used to have a identification of the instance
    /// DATE = the creation date of the post
    /// TITLE = the title of the POST
    /// TAGS = the posible topics of the post
    /// BODY = all the information
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public DateTime DATE { get; set; }
        public String TITLE { get; set; }
        public String AUTHOR { get; set; }
        public String TAGS { get; set; }

        [DataType(DataType.MultilineText)]
        public String BODY { get; set; }

        
        /// <summary>
        /// Split the string that have the tags, separated by -
        /// </summary>
        /// <returns></returns> 
        /// EXAMPLE: TAGS = "food-science"   Return = ["food","science"]
        public String[] GetTags()
        {
            return TAGS.Split('-'); 
        }

        /// <summary>
        /// Using LINQ call the db to find the lasted POSTS and order it by date
        /// </summary>
        /// <returns></returns> 
        public static List<Post> GetLastedPost()
        {
            var datos = (from s in new BlogExamContext().Posts
                        select s).OrderByDescending(d => d.DATE).Take(6);
            return datos.ToList();
        }
    }

   
}