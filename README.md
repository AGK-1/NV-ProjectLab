<p align="center">
  <img src="https://www.manubes.com/wp-content/uploads/2025/03/crud-infografik-1600-1000.png" alt="ProjectLab Panel Banner" />
</p>

Core Service Methods

# ProjectLab Panel API

Base URL: `/api/ProjectLab_panel`

An updated in-memory, thread-safe ASP.NET Core Web API leveraging `ConcurrentStack` and `Interlocked` operations to manage customer records, status tracking, and waiting queue mechanics.

---

## Architecture & Storage Overview

* **Thread-Safe In-Memory Queue:** Backed by `ConcurrentStack<CustomerEntity>` with atomic ID generation via `Interlocked.Increment`.
* **Ephemeral Data:** Because state is held entirely in system memory, data resets whenever the application pool restarts.

---

## Updated Endpoints Reference

### 1. Customer Management & Queuing
* **`POST /api/ProjectLab_panel/add-new-customer`**  
  Creates and pushes a new customer to the top of the storage stack with an auto-assigned ID.
* **`GET /api/ProjectLab_panel/get-all-waiting-customer`**  
  Retrieves a collection of all customers currently flagged with a `Waiting` status.
* **`GET /api/ProjectLab_panel/get-next-waiting-customer`**  
  Fetches the next prioritized customer in line from the waiting pool.
* **`GET /api/ProjectLab_panel/get-all-customers`**  
  Returns all customer records currently registered in the system.

### 2. Lookups & Queries
* **`GET /api/ProjectLab_panel/get-customer-with-id{id}`**  
  Finds and returns a specific customer by their numeric ID (throws `KeyNotFoundException` if missing).
* **`GET /api/ProjectLab_panel/get-customer-with-email{email}`**  
  Finds and returns a specific customer by their email address.

### 3. State Changes & Removals
* **`PUT /api/ProjectLab_panel/update-status/{id}`**  
  Updates the status enum for a target customer using their ID.
* **`DELETE /api/ProjectLab_panel/delete-customer/{id}`**  
  Pops through stack elements to locate and remove a record by ID.
* **`DELETE /api/ProjectLab_panel/delete-customer-with-email/{email}`**  
  Pops through stack elements to locate and remove a record by email address.