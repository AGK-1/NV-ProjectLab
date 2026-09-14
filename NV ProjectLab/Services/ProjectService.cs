using System.Collections.Concurrent;

namespace NV_ProjectLab.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ConcurrentStack<CustomerEntity> _storage = new ConcurrentStack<CustomerEntity>();
        private int _nextId = 0;
        public string AddCustomer(CustomerEntity customer)
        {
            customer.Id = Interlocked.Increment(ref _nextId);
            _storage.Push(customer);
            return customer.Name + " Added successfully";
        }

        public string ChangeCustomerStatus(int id, CustomerStatus status)
        {
            var customer = _storage.Where(customer => customer.Id == id).FirstOrDefault();
            if (customer == null)
                return "Customer not found";
            customer.Status = status;
            return customer.Name + " Status is changed";
        }



        public string DeleteCustomer(int id)
        {
            while (_storage.TryPop(out var cust))
            {
                if (cust.Id == id)
                {
                    return cust.Name + " deleted";
                }
            }

            return "Customer not found";
        }

        public string DeleteCustomerWithEmail(string email)
        {
            while (_storage.TryPop(out var cust))
            {
                if (cust.Email == email)
                {
                    return cust.Name + " deleted";
                }
            }

            return "Customer not found";
        }
        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var list = _storage.ToList();

            return list;

        }

        public IEnumerable<CustomerEntity> GetAllWaitingCustomers()
        {
            var list = _storage.Where(c => c.Status == CustomerStatus.Waiting).ToList();

            return list;

        }
        public CustomerEntity GetCustomerWithId(int id)
        {
            var customer = _storage.Where(customer => customer.Id == id).FirstOrDefault();
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");
            return customer;
        }

        public CustomerEntity GetCustomerWithEmail(string email)
        {
            var customer = _storage.Where(customer => customer.Email == email).FirstOrDefault();
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");
            return customer;
        }

        public CustomerEntity GetNextCustomer()
        {
            var first = _storage.Where(c => c.Status == CustomerStatus.Waiting).LastOrDefault();
            return first;
        }

    }




}
