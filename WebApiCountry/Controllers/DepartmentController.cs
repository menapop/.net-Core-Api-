using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;
using WebApi.Service.Services;
using WebApi.Service.Validators;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService departmentService;
        private readonly ILogger<Department> logger;


        public DepartmentController(IDepartmentService departmentService, ILogger<Department> logger)
        {
            this.departmentService = departmentService;
            this.logger = logger;
        }
        [HttpGet]
        public ActionResult Get()
        {
           
            try
            {
                var depts = departmentService.GetAll();
                return Ok(depts);
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong, message description:" + ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}", Name = "DepartmentCreated")]
        public IActionResult GetDepartment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }

            var dept = departmentService.Get(id);

            if (dept == null)
            {

                return NotFound();
            }

            return Ok(dept);
        }


        [HttpPut("{id}")]
        public IActionResult PutDepartment([FromRoute] int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                BadRequest();
            }
            try
            {
                departmentService.Put<DepartmentValidator>(department);
                return Ok(department);
            }
            catch (ArgumentNullException)
            {
                return NotFound("country does not exist");
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong, message description:" + ex.Message);
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult PostDepartment([FromBody] Department department)
        {
            try
            {
                var Department = departmentService.Post<DepartmentValidator>(department);
                logger.LogInformation("Record added " + Department.Id.ToString());
                return new CreatedAtRouteResult("CountryCreated", new { id = Department.Id }, Department);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Country does not exist");
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment([FromRoute] int id)
        {
            try
            {
                departmentService.Delete(id);
                return Ok("Record Deleted");
            }
            catch (ArgumentException)
            {
                return NotFound("Department does not exist");
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong,  message description: " + ex.Message);
                return BadRequest(ex);
            }
        }
    }


   }
 