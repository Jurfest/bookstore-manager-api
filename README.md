# 📚 Bookstore Management API

A robust and well-structured REST API built with **.NET** to manage a bookstore's inventory. This project demonstrates clean architecture principles, domain modeling with inheritance, strict business rules, and a complete **CRUD** (Create, Read, Update, Delete) flow, all documented automatically via **Swagger**.

This repository is ideal for learning, technical assessments, and as a solid foundation for real-world .NET Web API projects.

---

## 🚀 Technologies Used

* **C# / .NET 8.0**
* **ASP.NET Core Web API**
* **Swagger (Swashbuckle)** — interactive API documentation
* **Data Annotations & Domain Validation**

---

## 🛠️ Features & Business Rules

The system manages books following well-defined rules to ensure data integrity and consistency.

### ✅ Functional Requirements

* [x] Create a new book
* [x] List all books
* [x] Retrieve a book by ID
* [x] Update existing book details
* [x] Delete a book from the system

### 🔐 Data Validation Rules

* **ID**: Automatically generated `GUID`
* **Title & Author**:

  * Minimum: 2 characters
  * Maximum: 120 characters
* **Price & Stock**:

  * Must be greater than or equal to zero
* **Genre**:

  * Must belong to a predefined list (e.g. Fiction, Romance, Mystery, Sci‑Fi)
* **Uniqueness**:

  * Prevents duplicate entries for the same **Title + Author** combination
* **Timestamps**:

  * `CreatedAt` and `UpdatedAt` are managed automatically by the system

---

## 📁 Domain Model

The domain layer uses **class inheritance** to promote reuse, clarity, and scalability.

| Field  | Type    | Required | Rules                   |
| ------ | ------- | -------- | ----------------------- |
| Id     | GUID    | Yes      | Generated automatically |
| Title  | string  | Yes      | 2–120 characters        |
| Author | string  | Yes      | 2–120 characters        |
| Genre  | string  | Yes      | Must be a valid genre   |
| Price  | decimal | Yes      | ≥ 0                     |
| Stock  | int     | Yes      | ≥ 0                     |

---

## 🛣️ API Endpoints

| Method | Endpoint        | Description                          |
| ------ | --------------- | ------------------------------------ |
| POST   | /api/books      | Registers a new book                 |
| GET    | /api/books      | Returns all books (optional filters) |
| GET    | /api/books/{id} | Returns a book by ID                 |
| PUT    | /api/books/{id} | Updates an existing book             |
| DELETE | /api/books/{id} | Removes a book from the system       |

---

## 🚥 HTTP Status Codes

| Code | Meaning        | Description                           |
| ---- | -------------- | ------------------------------------- |
| 200  | OK             | Successful request with returned data |
| 201  | Created        | Resource successfully created         |
| 204  | No Content     | Successful update or deletion         |
| 400  | Bad Request    | Validation or request errors          |
| 404  | Not Found      | Resource not found                    |
| 409  | Conflict       | Business rule or duplication conflict |
| 500  | Internal Error | Unexpected server-side failure        |

---

## ⚙️ How to Run the Project

### Prerequisites

* .NET SDK 8.0+

### Steps

Clone the repository:

```bash
git clone https://github.com/your-username/bookstore-management-api.git
```

Navigate to the project folder:

```bash
cd bookstore-management-api
```

Restore dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

Access Swagger UI:

```
https://localhost:5001/swagger
```

(or the port shown in your terminal)

---

## 📌 Possible Improvements

* Persistence layer with Entity Framework Core
* Authentication & Authorization (JWT)
* Pagination and filtering
* Unit and integration tests
* Docker support

---

## 🧠 Purpose

This project was built to practice and demonstrate:

* Clean API design
* Domain-driven validation
* Proper use of HTTP semantics
* Modern .NET Web API patterns

Feel free to fork, experiment, and extend 🚀

