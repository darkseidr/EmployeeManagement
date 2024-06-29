# Project Setup and Documentation

## Setting Up the Environment

### Prerequisites
- [ ] Visual Studio or Visual Studio Code installed
- [ ] .NET SDK installed
- [ ] SQL Server or another compatible database server

### Steps to Set Up Environment

1. **Clone the Repository**
 git clone [https://github.com/yourusername/yourrepository.git](https://github.com/darkseidr/EmployeeManagement.git)
   cd yourrepository
2. Restore Dependencies using CLI
"dotnet restore"

3. Set Up Database
* Create a database instance on your SQL Server.
* Update the connection string in appsettings.json or use environment variables.

4. Run Migrations using cli
"Update-Database"


Employe Management
Overview
 A easy to use firm employee management system it utilizes .NET Web API for backend services and Blazor WebAssembly for the frontend.

Features:
 Authentication: Uses JWT for secure authentication.
 CRUD Operations: Implements CRUD operations for managing employee data.
 Add Employee: Allows adding new employees.
 Update Employee: Enables updating existing employee records.
 Delete Employee: Provides functionality to delete employee records.
 Fetch Employees: Retrieves a list of employees from the backend.

 
Technologies Used

Backend:
 .NET Web API
 Entity Framework Core for database operations
 JWT (JSON Web Tokens) for authentication
 
Frontend:
 Blazor WebAssembly standalone app
 Data binding with Blazor components
 
Setup Instructions

 Prerequisites
  Visual Studio or Visual Studio Code
  .NET SDK
  SQL Server

 
 Steps to Run
  Clone the Repository

Backend Setup
 Open the solution in Visual Studio.
 Update database connection string in appsettings.json.
 Run Entity Framework migrations to set up the database.
 
Frontend Setup
 Open the Blazor WebAssembly project in Visual Studio or Visual Studio Code.
 Configure API base URL in services.
 Build and run the Blazor WebAssembly project.

 
Run the Application
 Start the backend API project.
 Start the Blazor WebAssembly application.


API Endpoints

 Document the API endpoints used for CRUD operations:
  POST /api/Authenticate: Endpoint for user authentication.
  GET /api/Employees: Fetches all employees.
  GET /api/Employees/{id}: Fetches a specific employee by ID.
  POST /api/Employees: Adds a new employee.
  PUT /api/Employees/{id}: Updates an existing employee.
  DELETE /api/Employees/{id}: Deletes an employee.
Screenshots
Include screenshots or GIFs demonstrating the application’s UI and functionality.

Future Enhancements
Integration of email functionality on creating of user passing on initial login credentials
