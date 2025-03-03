# PayRollApi

A simple ASP.NET Core Web API for managing employees and payroll data. This project showcases a typical .NET folder structure with controllers, business logic, and models, plus a Swagger interface for easy API exploration and testing.

---

## Features
- **Employee Management**: Create, read, update, and delete employees through `/api/Employee` endpoints.
- **Payroll Calculations**: Basic logic to handle pay data through `/api/Pay`.
- **Swagger Integration**: Automatic documentation and testing via [Swagger UI](https://swagger.io/tools/swagger-ui/).
- **Scalable Architecture**: Separation of concerns in Controllers, Logic, and Models.

---

## API Endpoints

### Employee
1. **GET** `/api/Employee`  
   - Retrieves a list of all employees.
2. **GET** `/api/Employee/{emp_id}`  
   - Retrieves details of a specific employee by ID.
3. **POST** `/api/Employee`  
   - Creates a new employee.  
   - Expects employee data in the request body (JSON).
4. **PUT** `/api/Employee/{emp_id}`  
   - Updates an existing employee by ID.  
   - Expects updated employee data in the request body.
5. **DELETE** `/api/Employee/{emp_id}`  
   - Deletes an employee by ID.

### Pay
1. **GET** `/api/Pay`  
   - Retrieves pay-related information for all employees (if applicable).
2. **GET** `/api/Pay/{emp_id}`  
   - Retrieves pay information for a specific employee by ID (if implemented).


## Prerequisites
- [.NET 8 (or later)](https://dotnet.microsoft.com/download)
- A local or remote SQL database (for storing employee/payroll data)
- [Git](https://git-scm.com/) (optional, but recommended for version control)

---

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/GhostHunterr/PayRollAPI.git
   cd PayRollApi
   ```

2. **Open in Visual Studio or VS Code**:
   - **Visual Studio**: Double-click the `.sln` file or use `File > Open > Project/Solution`.
   - **VS Code**: `File > Open Folder` and select the root folder.

3. **Install dependencies**:
   ```bash
   dotnet restore
   ```

---

## Configuration

1. **Create an `appsettings.json` file** in the root of the project with a **ConnectionStrings** property named **MyConnection**. For example:
   ```json
   {
     "ConnectionStrings": {
       "MyConnection": "Server=localhost;Database=PayRollDb;Trusted_Connection=True;"
     }
   }
   ```
   - If you store sensitive credentials, consider using [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) or environment variables for production.

2. **appsettings.Development.json**:
   - Used when the environment is set to `Development`. You can override or add dev-specific settings here.

3. **.gitignore**:
   - Excludes build artifacts, user-specific files, and other generated content. Adjust as needed.

---

## Running the Application

From the **command line**:
```bash
# Build the solution
dotnet build

# Run the application
dotnet run 
```

Or in **Visual Studio**:
1. Right-click on the `PayRollApi` project and select **Set as Startup Project**.
2. Press `F5` (Debug) or `Ctrl + F5` (Run without debugging).

Once running, navigate to:
- **Swagger UI**: [https://localhost:5041/swagger](http://localhost:5041/swagger/)

---


## Contributing
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/my-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/my-feature`).
5. Open a Pull Request.

---
