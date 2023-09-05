# Running the Martha Library Application - a .NET 7 Web API with Entity Framework Core/Dapper and an Angular Frontend 

This guide will walk you through the steps to run the solution, an API project that utilizes Entity Framework Core and Dapper for data access. By following these steps, you will be able to set up and run the project on your local machine.

## Prerequisites

Before you begin, make sure you have the following prerequisites installed on your machine:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio Code](https://code.visualstudio.com/) (recommended for the Frontend Project)
- [SQL Server Management Studio (LocalDb)]

## Getting Started

1. **Clone the Repository**

   Clone this repository to your local machine using Git:

   ```shell
   git clone https://github.com/Nwaneto/MarthaLibraryManagement.git
   ```

2. **Navigate to the Project Folder**

   Change your current directory to the project folder:

   ```shell
   cd your-dotnet-api
   ```

3. **Database Configuration**

   - **SQL Server**:
     
     If you're using SQL Server, open the `appsettings.json` file and update the connection string under the `"ConnectionStrings"` section:

     ```json
     
       "ConnectionString": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarthasLibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"
     
     ```

4. **Database Migration**

   The API automatically does a migration on first run to create all authentication related tables and tasks for a smooth run:
   Stored procedures for other data related tasks can be found in the Proc.sql file in the solution. Run the sql script against your database to enable the embeded functionalities

5. **Run the Application**

   Start the Web API by running the following command:

   ```shell
   dotnet run
   ```

   The API will be accessible at `https://localhost:5001` by default.

6. **Testing the API**

   The api has a swagger ui which is enough for testing, but you can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to test the API endpoints.

## API Endpoints

You can test all the API endpoints. To begin, you'll need to generate a token using the following credentials:

````json
{
    "email":"admin@root.com",
    "password":"123Pa$$word!"
}
token: root
````

The generated token will then be used to pass to the header of every api call for validation
- `GET /api/v1/librarybooks/getallbooks`: Get a list of all books.
- `GET /api/v1/librarybooks/getsinglebook?bookId={}`: Get a specific book by BookID.
- `POST api/v1/librarybooks/borrow?bookId={}&customerId={}`: Borrow a book.
- `POST /api/v1/librarybooks/reservebook?bookId={}&customerId={}`: Reserve a book.

Please refer to the swagger documentation or code for additional endpoints and details.

## License

This project is licensed under the [MIT License](LICENSE).
