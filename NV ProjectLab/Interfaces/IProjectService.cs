public interface IProjectService
{
    string AddCustomer(CustomerEntity customer);

    CustomerEntity GetCustomerWithId(int id);

    CustomerEntity GetCustomerWithEmail(string email);
    IEnumerable<CustomerEntity> GetAllWaitingCustomers();
    IEnumerable<CustomerEntity> GetCustomers();
    CustomerEntity GetNextCustomer();
    string ChangeCustomerStatus(int id, CustomerStatus status);
    string DeleteCustomer(int id);
    string DeleteCustomerWithEmail(string email);

}

