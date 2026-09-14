using Microsoft.AspNetCore.Mvc;
using NV_ProjectLab.Services;

namespace NV_ProjectLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectLab_panel : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectLab_panel(ProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost("add-new-customer")]
        public string AddNewCustomer(CustomerDTO dto)
        {
            return _projectService.AddCustomer(new CustomerEntity
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email
            });

        }

        [HttpGet("get-all-waiting-customer")]
        public IEnumerable<CustomerEntity> GetAllCustomer()
        {
            return _projectService.GetAllWaitingCustomers();
        }



        [HttpGet("get-next-waiting-customer")]
        public CustomerEntity GetNextCustomer()
        {
            return _projectService.GetNextCustomer();
        }


        [HttpGet("get-all-customers")]
        public IEnumerable<CustomerEntity> GetAll()
        {
            return _projectService.GetCustomers();
        }

        [HttpGet("get-customer-with-id{id}")]
        public CustomerEntity GetCustomerWithId(int id)
        {
            return _projectService.GetCustomerWithId(id);
        }

        [HttpGet("get-customer-with-email{email}")]
        public CustomerEntity GetCustomerWithId(string email)
        {
            return _projectService.GetCustomerWithEmail(email);
        }


        [HttpPut("update-status/{id}")]
        public string ChangeStatusCustomer(int id, ChangeStatusDto _status)
        {

            var stat = _status;
            return _projectService.ChangeCustomerStatus(id, stat.Status);

        }


        [HttpDelete("delete-customer/{id}")]
        public string Delete(int id)
        {
            return _projectService.DeleteCustomer(id);
        }

        [HttpDelete("delete-customer-with-email/{email}")]
        public string Delete(string email)
        {
            return _projectService.DeleteCustomerWithEmail(email);
        }


    }
}
