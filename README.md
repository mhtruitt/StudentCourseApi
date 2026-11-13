
# StudentCourseApi

## Project Description

StudentCourseApi is an ASP.NET Core Minimal API application built using C# and .NET 10. The application manages university courses through RESTful API endpoints and provides a simple HTML and JavaScript interface for displaying available courses.

## Technologies Used

- C#
- ASP.NET Core Minimal API
- .NET 10
- HTML5
- CSS3
- JavaScript
- REST API
- JSON

## Prerequisites

Before running the application, make sure you have:

- .NET 10 SDK installed
- Visual Studio Code or another C# editor
- PowerShell or a terminal
- A modern web browser

## Installation and Setup

1. Clone the repository:

   ```powershell
   git clone YOUR_GITHUB_REPOSITORY_URL
   ```

2. Navigate to the project directory:

   ```powershell
   cd StudentCourseApi
   ```

3. Restore dependencies:

   ```powershell
   dotnet restore
   ```

4. Build the application:

   ```powershell
   dotnet build
   ```

5. Run the application:

   ```powershell
   dotnet run
   ```

6. Open the local address displayed in the terminal to view the browser interface.

## Project Structure

```text
StudentCourseApi/
│
├── Models/
│   └── Course.cs
│
├── wwwroot/
│   └── index.html
│
├── Program.cs
├── StudentCourseApi.csproj
├── appsettings.json
├── .gitignore
└── README.md
```

## Course Model

Each course contains the following properties:

| Property | Data Type |
|---|---|
| Id | Integer |
| Code | String |
| Title | String |
| Credits | Integer |
| Instructor | String |

The application starts with five sample courses stored in an in-memory list.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | /api/courses | Retrieve all courses |
| GET | /api/courses/{id} | Retrieve a course by ID |
| POST | /api/courses | Create a new course |
| PUT | /api/courses/{id} | Update an existing course |
| DELETE | /api/courses/{id} | Delete a course |

## Example POST Request

```json
{
  "code": "CMPS360",
  "title": "Web Programming",
  "credits": 3,
  "instructor": "Professor Smith"
}
```

## Validation

The API rejects submissions with HTTP 400 Bad Request when:

- Course code is blank.
- Course title is blank.
- Instructor is blank.
- Credits are less than 1 or greater than 6.

The API returns HTTP 404 Not Found when a requested course ID does not exist.

## Testing

The API was tested using PowerShell HTTP requests and a web browser.

Testing included:

1. GET all courses — HTTP 200.
2. GET course by ID — HTTP 200.
3. GET missing course ID — HTTP 404.
4. POST a new course — HTTP 201.
5. POST invalid course information — HTTP 400.
6. PUT an existing course — HTTP 200.
7. DELETE an existing course — HTTP 204.
8. Browser interface displaying courses using JavaScript fetch().

## Testing Evidence

Screenshots demonstrating the eight required tests are included in the `screenshots` folder.

## Browser Interface

The application includes an HTML, CSS, and JavaScript webpage served through ASP.NET Core's wwwroot directory.

JavaScript uses the fetch() method to retrieve course information from the API and dynamically display course cards containing the course code, title, and credits.

## Important Note

Course information is stored in memory rather than a database. Changes made through POST, PUT, and DELETE are temporary and reset when the application restarts.

## Reflection

The StudentCourseApi project helped me understand how C# fundamentals can be applied to web development using ASP.NET Core Minimal APIs. I learned how to create a model, work with collections, implement CRUD operations, and use HTTP status codes to communicate the results of API requests.

One issue I encountered was that the .NET SDK was not initially installed or available on my computer. I resolved this by installing the .NET 10 SDK and verifying the installation through PowerShell before creating the project.

I also learned how an API connects to a browser interface. My HTML page uses JavaScript's fetch() method to send a GET request to the API, retrieve course information in JSON format, and dynamically display that information as course cards. This demonstrated how the backend and frontend communicate without requiring a database or additional frameworks.

Overall, this assignment improved my understanding of REST APIs, C#, HTTP methods, input validation, and the relationship between server-side and client-side programming.
