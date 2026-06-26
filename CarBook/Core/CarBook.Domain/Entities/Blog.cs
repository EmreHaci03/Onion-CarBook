using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; } 
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate {  get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public List<TagCloud> TagClouds { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}
