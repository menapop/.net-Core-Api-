using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;

namespace WebApi.Service.Services
{
   public  class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository iDepartmentRepository;
        private readonly IMapper mapper;

        public DepartmentService (IDepartmentRepository iDepartmentRepository, IMapper mapper)
        {
            this.iDepartmentRepository = iDepartmentRepository;
            this.mapper = mapper;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            iDepartmentRepository.Delete(id);
        }

        public Department Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return iDepartmentRepository.Select(id);
        }

        public List<Department> GetAll()
        {
            return iDepartmentRepository.SelectAll();
        }

        public Department Post<V>(Department department) where V : AbstractValidator<Department>
        {
            Validate(department, Activator.CreateInstance<V>());

            iDepartmentRepository.Insert(department);
            return department;
        }

        private void Validate<V>(Department department, V v) where V : AbstractValidator<Department>
        {
            throw new NotImplementedException();
        }

        public Department Put<V>(Department department) where V : AbstractValidator<Department>
        {
            Validate(department, Activator.CreateInstance<V>());

            iDepartmentRepository.Update(department);
            return department;
        }



        private void Validate(Department obj, AbstractValidator<Department> validator)
        {
            if (obj == null)
                throw new Exception("records not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
