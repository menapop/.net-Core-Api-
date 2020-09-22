using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Domain.Entities
{
    public class Department:BaseEntity
    {
        public string DepartmentName { set; get; }
        public virtual ICollection<Course> Courses { set; get; }
    }
}
