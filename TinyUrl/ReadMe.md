# TinyURL-like Service (Proof of Concept)

[![.NET Core](https://img.shields.io/badge/.NET-6.0-blue)](https://dotnet.microsoft.com/)


A lightweight URL shortening service with real-time analytics, built with ASP.NET Core (C#) backend and React frontend.

## Features

### Backend
- **URL Shortening**: Generate short codes (6-8 characters)
- **Custom Aliases**: Support for custom short codes
- **Click Tracking**: Real-time click statistics
- **In-Memory Storage**: Uses `ConcurrentDictionary` for thread safety
- **REST API**: Full CRUD operations for URL management
- **Concurrency Support**: Thread-safe operation
## Building and Running the TinyUrl Service

These instructions guide you through building and running the TinyUrl service using the .NET CLI.

1.  **Navigate to the Project Directory:**

    ```bash
    cd path/to/TinyUrl
    ```

    Replace `path/to/TinyUrl` with the actual path to your TinyUrl project directory.

2.  **Restore NuGet Packages:**

    ```bash
    dotnet restore
    ```

    This command downloads and installs all the required NuGet packages for the project.

3.  **Build the Project:**

    ```bash
    dotnet build
    ```

    This command compiles the project's source code and produces the executable files.

4.  **Run the Application:**

    ```bash
    dotnet run
    ```

    This command starts the TinyUrl service.

## Accessing the Swagger UI

After successfully running the application, you can access the Swagger UI to interact with the API.

* **HTTP Profile:**

    Open your web browser and navigate to the following URL:

    ```
    http://localhost:5048/
    ```


* For the https profile: 
*  ```
    https://localhost:7278/ 
    ```
    You should see the Swagger UI, which provides a user-friendly interface for testing and exploring the API's endpoints.