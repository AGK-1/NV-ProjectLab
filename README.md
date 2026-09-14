<p align="center">
  <img src="https://www.manubes.com/wp-content/uploads/2025/03/crud-infografik-1600-1000.png" alt="ProjectLab Panel Banner" />
</p>

Core Service Methods


AddCustomer(CustomerEntity customer): Assigns an auto-incremented thread-safe ID, pushes the entity to the top of the concurrent stack, and returns a success string.

ChangeCustomerStatus(int id, CustomerStatus status): Searches for a customer by ID and updates their status enum, returning a status modification message or "Customer not found".

DeleteCustomer(int id) / DeleteCustomerWithEmail(string email): Iterates through the stack via TryPop to locate and remove the targeted record. (Note: Popping elements out of order to find a specific match can temporarily alter stack sequencing unless carefully managed).

GetCustomers(): Converts and returns all items currently in the stack as an IEnumerable<CustomerEntity>.

GetAllWaitingCustomers(): Filters the stack to return all entities flagged with the CustomerStatus.Waiting state.

GetCustomerWithId(int id) / GetCustomerWithEmail(string email): Queries the storage collection and returns the matching entity, throwing a KeyNotFoundException if no match is found.

GetNextCustomer(): Retrieves the most recent waiting customer (LastOrDefault on the filtered waiting subset, reflecting stack LIFO behavior).