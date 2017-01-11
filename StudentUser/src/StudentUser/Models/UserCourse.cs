using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUser.Models
{
    public class UserCourse
    {
        public ApplicationUser User{ get; set; }
        public string UserId { get; set; }
        public Course Course { get; set; }
        public int CourseId{ get; set; }

    }
}
