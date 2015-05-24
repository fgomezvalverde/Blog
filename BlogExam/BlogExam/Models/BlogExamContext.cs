using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogExam.Models
{
    /// <summary>
    /// Entity data for POST, used to have the info locally in this case
    /// </summary>
    public class BlogExamContext : DbContext
    {
    
        public BlogExamContext() : base("name=BlogExamContext")
        {
        }

        public System.Data.Entity.DbSet<BlogExam.Models.Post> Posts { get; set; }
    
    }
}
