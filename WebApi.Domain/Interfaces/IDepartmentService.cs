using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces
{
   public interface IDepartmentService
    {
        Department Post<V>(Department obj) where V : AbstractValidator<Department>;

        Department Put<V>(Department obj) where V : AbstractValidator<Department>;

        void Delete(int id);

        Department Get(int id);

        List<Department> GetAll();

    }
}
