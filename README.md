# User Management API

This is a basic **Building a Simple API with Copilot** built with **ASP.NET Core**. It supports **CRUD** operations to manage user data and includes features like logging, error handling, and token-based authentication.

## Features

- **CRUD Operations**: Add, read, update, and delete users.
- **Logging**: All requests and responses are logged.
- **Error Handling**: Standardized error responses for better consistency.
- **Authentication**: Token-based authentication to secure the API.

## Running the Application

1. Clone the repository.
2. Open the solution in Visual Studio or any other IDE that supports .NET.
3. Run the project using `dotnet run` or press `F5` in Visual Studio.
4. The API will run locally on `https://localhost:5001`.

## API Endpoints

- **GET /api/users**: Retrieves all users.
- **GET /api/users/{id}**: Retrieves a user by ID.
- **POST /api/users**: Adds a new user.
- **PUT /api/users/{id}**: Updates an existing user.
- **DELETE /api/users/{id}**: Deletes a user.

## Authentication

To access protected endpoints, include a token in the `Authorization` header, e.g., `Authorization: Bearer valid-token`.

## License

This project is licensed under the MIT License.
