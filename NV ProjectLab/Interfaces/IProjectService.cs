public interface IProjectService
{
    string AddCustomer(CustomerEntity customer);

    CustomerEntity GetCustomerWithId(int id);
    IEnumerable<CustomerEntity> GetCustomers();

    string ChangeCustomerStatus(int id, CustomerStatus status);
    string DeleteCustomer(int id);

}

