# Short URL Service

[![.NET Core](https://img.shields.io/badge/.NET-6.0-blue)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-18.x-blue)](https://reactjs.org/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)


A lightweight URL shortening service with real-time analytics, built with ASP.NET Core (C#) backend and React frontend.

## Features

### Backend
- **URL Shortening**: Generate short codes (6-8 characters)
- **Custom Aliases**: Support for custom short codes
- **Click Tracking**: Real-time click statistics
- **In-Memory Storage**: Uses `ConcurrentDictionary` for thread safety
- **REST API**: Full CRUD operations for URL management
- **Concurrency Support**: Thread-safe operation
## Building and Running the TinyUrl BackEnd Service

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

#  Frontend ________________________________________________
## Core Functionalities

* **Creating and Deleting Short URLs:**
    * Users can create short URLs associated with long URLs.
    * Users can delete existing short URLs.
* **Retrieving Long URLs:**
    * Given a short URL, the service returns the corresponding long URL.
* **Statistics Tracking:**
    * The service tracks the number of times a short URL has been accessed (clicked).
    * Users can retrieve statistics on the number of clicks for a specific short URL.
* **Custom and Random Short URL Generation:**
    * Users can specify a custom short URL.
    * If no custom short URL is provided, the service generates a unique random short URL.
    * The service maintains the uniqueness of all short URLs.
## Tech Stack
- **Backend**: ASP.NET Core 6.0
- **Frontend**: React 18, Axios
- **Storage**: In-memory (ConcurrentDictionary)
- **Security**: CORS configuration, input validation

## Getting Started

### Prerequisites
- [Node.js 16+](https://nodejs.org/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Recommended)

### Installation and run

#### Frontend
```bash
cd tinyurl-frontend
npm install
npm start

### Url 
http://localhost:3000/