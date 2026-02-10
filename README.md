📚 Bookstore Management API
A robust REST API built with .NET to manage a bookstore's inventory. This project implements a full CRUD (Create, Read, Update, Delete) system, featuring domain inheritance, strict data validation, and automated documentation with Swagger.

🚀 Technologies Used
C# / .NET 8.0 (or your current version)

ASP.NET Core Web API

Swagger (Swashbuckle) for API documentation

LINQ for data manipulation

🛠️ Features & Business Rules
The system manages books with the following logic:

Requirements
[x] Create a new book.

[x] List all books.

[x] Search for a specific book by ID.

[x] Edit existing book details.

[x] Delete a book from the system.

Data Validation
IDs: Automatically generated GUIDs.

Length: Titles and Authors must be between 2 and 120 characters.

Stock & Price: Must be greater than or equal to zero (non-negative).

Genre: Must belong to a predefined list (Fiction, Romance, Mystery, etc.).

Uniqueness: Prevents duplicate entries for the same title/author combination.

Timestamps: Automatically manages CreatedAt and UpdatedAt fields.

📁 Domain Model
The project uses class inheritance to organize the domain, ensuring a clean and scalable architecture.

Field,Type,Required,Rules
Id,GUID,Yes,Generated automatically
Title,string,Yes,2-120 characters
Author,string,Yes,2-120 characters
Genre,string,Yes,Must be a valid genre
Price,decimal,Yes,≥0
Stock,int,Yes,≥0

🛣️ API Endpoints

Method,Endpoint,Description
POST,/api/books,Registers a new book.
GET,/api/books,Returns all books (optional filters).
GET,/api/books/{id},Returns a specific book by ID.
PUT,/api/books/{id},Updates an existing book.
DELETE,/api/books/{id},Removes a book from the database.

🚥 HTTP Status Codes

Code,Usage,Description
200,OK,Successful request with data returned.
201,Created,Successfully created a new resource.
204,No Content,Successful operation (Delete/Update) with no body.
400,Bad Request,Validation errors or malformed data.
404,Not Found,Resource or route not found.
409,Conflict,Data duplication or business rule conflict.
500,Internal Error,Unexpected server-side failure.

Gemini said
Here is a professional and complete README.md in English for your project. It follows the standard structure for .NET GitHub repositories, highlighting the technical requirements and rules you mentioned.

📚 Bookstore Management API
A robust REST API built with .NET to manage a bookstore's inventory. This project implements a full CRUD (Create, Read, Update, Delete) system, featuring domain inheritance, strict data validation, and automated documentation with Swagger.

🚀 Technologies Used
C# / .NET 8.0 (or your current version)

ASP.NET Core Web API

Swagger (Swashbuckle) for API documentation

LINQ for data manipulation

🛠️ Features & Business Rules
The system manages books with the following logic:

Requirements
[x] Create a new book.

[x] List all books.

[x] Search for a specific book by ID.

[x] Edit existing book details.

[x] Delete a book from the system.

Data Validation
IDs: Automatically generated GUIDs.

Length: Titles and Authors must be between 2 and 120 characters.

Stock & Price: Must be greater than or equal to zero (non-negative).

Genre: Must belong to a predefined list (Fiction, Romance, Mystery, etc.).

Uniqueness: Prevents duplicate entries for the same title/author combination.

Timestamps: Automatically manages CreatedAt and UpdatedAt fields.

📁 Domain Model
The project uses class inheritance to organize the domain, ensuring a clean and scalable architecture.

Field	Type	Required	Rules
Id	GUID	Yes	Generated automatically
Title	string	Yes	2-120 characters
Author	string	Yes	2-120 characters
Genre	string	Yes	Must be a valid genre
Price	decimal	Yes	≥0
Stock	int	Yes	≥0
🛣️ API Endpoints
Method	Endpoint	Description
POST	/api/books	Registers a new book.
GET	/api/books	Returns all books (optional filters).
GET	/api/books/{id}	Returns a specific book by ID.
PUT	/api/books/{id}	Updates an existing book.
DELETE	/api/books/{id}	Removes a book from the database.
🚥 HTTP Status Codes
Code	Usage	Description
200	OK	Successful request with data returned.
201	Created	Successfully created a new resource.
204	No Content	Successful operation (Delete/Update) with no body.
400	Bad Request	Validation errors or malformed data.
404	Not Found	Resource or route not found.
409	Conflict	Data duplication or business rule conflict.
500	Internal Error	Unexpected server-side failure.

⚙️ How to Run
Clone the repository:
git clone https://github.com/your-username/bookstore-api.git

Navigate to the project folder:

cd bookstore-api

Restore dependencies:

dotnet restore

Run the application:

dotnet run

Access Documentation: Once running, open http://localhost:5000/swagger (or the port shown in your terminal) to test the endpoints via Swagger UI.
