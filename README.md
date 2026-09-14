# NV-ProjectLab

ProjectLab Panel API Documentation

Base URL: /api/ProjectLab\_panel



Endpoints

1\. Add New Customer

URL: /api/ProjectLab\_panel/add-new-customer



Method: POST



Description: Creates a new customer record from the provided data transfer object.



Request Body (CustomerDTO):



name (string): Customer's first name.



surname (string): Customer's last name.



email (string): Customer's email address.



Response: Returns a string confirmation message.



2\. Get Next Waiting Customer

URL: /api/ProjectLab\_panel/get-waiting-customer



Method: GET



Description: Retrieves the next customer in the waiting queue.



Response: Returns a CustomerEntity object.



3\. Get All Customers

URL: /api/ProjectLab\_panel/get-all-customers



Method: GET



Description: Retrieves a list of all registered customers.



Response: Returns an array of CustomerEntity objects (IEnumerable<CustomerEntity>).



4\. Get Customer by ID

URL: /api/ProjectLab\_panel/get-customer-with-id{id}



Method: GET



Parameters:



id (int, path): Unique identifier of the customer.



Response: Returns a CustomerEntity object.



5\. Get Customer by Email

URL: /api/ProjectLab\_panel/get-customer-with-email{email}



Method: GET



Parameters:



email (string, path): Email address of the customer.



Response: Returns a CustomerEntity object.



6\. Delete Customer by ID

URL: /api/ProjectLab\_panel/delete-customer/{id}



Method: DELETE



Parameters:



id (int, path): Unique identifier of the customer to delete.



Response: Returns a string confirmation message.



7\. Delete Customer by Email

URL: /api/ProjectLab\_panel/delete-customer-with-email/{email}



Method: DELETE



Parameters:



email (string, path): Email address of the customer to delete.



Response: Returns a string confirmation message.



8\. Update Customer Status

URL: /api/ProjectLab\_panel/update-status/{id}



Method: PUT



Parameters:



id (int, path): Unique identifier of the customer.



Request Body (ChangeStatusDto):



status (string/int): The new status value to apply.



Response: Returns a string confirmation message.

