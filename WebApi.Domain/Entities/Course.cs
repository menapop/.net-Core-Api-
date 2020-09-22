using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Domain.Entities
{
    public class Course:BaseEntity
    {
        public string CourseName { set; get; }
        public int DepartmentID { set; get; }
        public virtual Department Department { set; get; }
    }
}
