using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        void Insert(Department obj);

        void Update(Department obj);

        void Delete(int id);

        Department Select(int id);

        List<Department> SelectAll();
    }
}
