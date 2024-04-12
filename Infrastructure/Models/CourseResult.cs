using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class CourseResult
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<Course>? Courses { get; set; }

        public void UpdateTotalPages()
        {
            TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
        }

    }
}
