# Running the Martha Library Application - a .NET 7 Web API with Entity Framework Core/Dapper and an Angular Frontend 

This guide will walk you through the steps to run the solution, an API project that utilizes Entity Framework Core and Dapper for data access. By following these steps, you will be able to set up and run the project on your local machine.

## Prerequisites

Before you begin, make sure you have the following prerequisites installed on your machine:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended for the API Project)
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
     
     If you're using SQL Server, open the `database.json` file in the Configurations Folder of the API and update the connection string under the `"ConnectionStrings"` section:

     ```json
     
       "ConnectionString": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarthasLibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"
     
     ```

4. **Database Migration**

   The API automatically does table creation and migration on first run to create all authentication related tables and tasks for a smooth run:
   Stored procedures for other data related tasks can be found in the Proc.sql file within the SQL Scripts folder in the Host Application. Run the sql script against your database to enable the embedded functionalities

5. **Run the Application**

   Start the Web API from Visual Studio or by running the following command:

   ```shell
   dotnet run
   ```

   The API will be accessible at `https://localhost:5001` by default as shown in the image below.
   ![Screenshot](URL_OF_YOUR_IMAGE)
   ![Screenshot](https://github.com/Nwaneto/MarthaLibraryManagement/blob/main/Capture23.PNG)


7. **Testing the API**

   The api has a swagger ui which is enough for testing, but you can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to test the API endpoints.
   ![Screenshot](https://github.com/Nwaneto/MarthaLibraryManagement/blob/main/Capture22.PNG)

8. **Testing the frontend**
   Before you begin, make sure you have the following prerequisites installed on your machine:

   - [Node.js](https://nodejs.org/) (LTS version recommended.)
   - [Angular CLI](https://angular.io/cli) (installed globally)

      Start the Solution in Visual Studio using the multiple Startup Project option, with the Angular project starting after the API:
      Web browser should automatically open on `http://localhost:55601/` to view and interact with the Angular application.

   ![Screenshot](https://github.com/Nwaneto/MarthaLibraryManagement/blob/main/Capture25.PNG)
   ![Screenshot](https://github.com/Nwaneto/MarthaLibraryManagement/blob/main/Capture24.PNG)

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
