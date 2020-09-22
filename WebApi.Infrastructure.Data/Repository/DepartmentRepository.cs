using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;
using WebApi.Infrastructure.Data.Context;

namespace WebApi.Infrastructure.Data.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private SqlServerContext context;

        public DepartmentRepository(SqlServerContext context)
        {
            this.context = context;
        }

        public void Insert(Department department)
        {
            context.Set<Department>().Add(department);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<Department>().Remove(Select(id));
            context.SaveChanges();
        }

        public Department Select(int id)
        {
            return context.Set<Department>().Find(id);
        }

        public List<Department>SelectAll()
        {
            return context.Set<Department>().ToList();
        }
        public void Update(Department department)
        {
            context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
