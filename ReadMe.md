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


# Employee Management System

## Overview

Employee Management System is an easy-to-use application for managing employees within a firm. It utilizes .NET Web API for backend services and Blazor WebAssembly for the frontend.

## Features

- **Authentication**: Uses JWT (JSON Web Tokens) for secure user authentication.
- **CRUD Operations**: Implements operations to manage employee data.
  - **Add Employee**: Allows adding new employees to the system.
  - **Update Employee**: Enables updating existing employee records.
  - **Delete Employee**: Provides functionality to remove employee records.
  - **Fetch Employees**: Retrieves a list of employees from the backend.

## Technologies Used

### Backend

- **.NET Web API**: Backend framework for handling HTTP requests.
- **Entity Framework Core**: ORM (Object-Relational Mapping) for database operations.
- **JWT**: Provides authentication tokens for secure user sessions.

### Frontend

- **Blazor WebAssembly**: Client-side framework for building interactive UI with .NET.
- **Data Binding**: Uses Blazor components for seamless data binding.

## Setup Instructions

### Prerequisites

- Visual Studio or Visual Studio Code installed.
- .NET SDK installed.
- SQL Server or another compatible database server.

### Steps to Set Up Environment

1. **Clone the Repository**
   ```bash
   git clone https://github.com/darkseidr/EmployeeManagement.git
   cd EmployeeManagement

2. **Backend Setup
 - **Open the solution in Visual Studio.
 - **Update database connection string in appsettings.json.
 - **Run Entity Framework migrations to set up the database.
 
3. **Frontend Setup
 - **Open the Blazor WebAssembly project in Visual Studio or Visual Studio Code.
 - **Configure API base URL in services.
 - **Build and run the Blazor WebAssembly project.

 
4. **Run the Application
 - **Start the backend API project.
 - **Start the Blazor WebAssembly application.


### API Endpoints

 Document the API endpoints used for CRUD operations:
  - **POST /api/Authenticate: Endpoint for user authentication.
  - **GET /api/Employees: Fetches all employees.
  - **GET /api/Employees/{id}: Fetches a specific employee by ID.
  - **POST /api/Employees: Adds a new employee.
  - **PUT /api/Employees/{id}: Updates an existing employee.
  DELETE /api/Employees/{id}: Deletes an employee.
### Screenshots
- **Include screenshots or GIFs demonstrating the application’s UI and functionality.

### Future Enhancements
- **Integration of email functionality on creating of user passing on initial login credentials
