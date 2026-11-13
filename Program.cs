
using StudentCourseApi.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// In-memory list containing five sample courses
var courses = new List<Course>
{
    new Course
    {
        Id = 1,
        Code = "CMPS360",
        Title = "Web Programming",
        Credits = 3,
        Instructor = "Professor Smith"
    },
    new Course
    {
        Id = 2,
        Code = "CMPS250",
        Title = "Data Structures",
        Credits = 3,
        Instructor = "Professor Johnson"
    },
    new Course
    {
        Id = 3,
        Code = "CMPS310",
        Title = "Database Management",
        Credits = 3,
        Instructor = "Professor Williams"
    },
    new Course
    {
        Id = 4,
        Code = "CMPS340",
        Title = "Software Engineering",
        Credits = 4,
        Instructor = "Professor Davis"
    },
    new Course
    {
        Id = 5,
        Code = "CMPS420",
        Title = "Cybersecurity Fundamentals",
        Credits = 3,
        Instructor = "Professor Brown"
    }
};

// GET: Return all courses
app.MapGet("/api/courses", () =>
{
    return Results.Ok(courses);
});

// GET: Return a specific course by ID
app.MapGet("/api/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(course);
});


// POST: Add a new course
app.MapPost("/api/courses", (Course newCourse) =>
{
    // Validate required fields
    if (string.IsNullOrWhiteSpace(newCourse.Code) ||
        string.IsNullOrWhiteSpace(newCourse.Title) ||
        string.IsNullOrWhiteSpace(newCourse.Instructor) ||
        newCourse.Credits < 1 ||
        newCourse.Credits > 6)
    {
        return Results.BadRequest(new
        {
            message = "Invalid course. Code, title, and instructor are required. Credits must be between 1 and 6."
        });
    }

    // Automatically assign the next available ID
    newCourse.Id = courses.Count == 0
        ? 1
        : courses.Max(c => c.Id) + 1;

    courses.Add(newCourse);

    return Results.Created($"/api/courses/{newCourse.Id}", newCourse);
});

// PUT: Update an existing course
app.MapPut("/api/courses/{id}", (int id, Course updatedCourse) =>
{
    var existingCourse = courses.FirstOrDefault(c => c.Id == id);

    if (existingCourse == null)
    {
        return Results.NotFound();
    }

    // Validate updated information
    if (string.IsNullOrWhiteSpace(updatedCourse.Code) ||
        string.IsNullOrWhiteSpace(updatedCourse.Title) ||
        string.IsNullOrWhiteSpace(updatedCourse.Instructor) ||
        updatedCourse.Credits < 1 ||
        updatedCourse.Credits > 6)
    {
        return Results.BadRequest(new
        {
            message = "Invalid course. Code, title, and instructor are required. Credits must be between 1 and 6."
        });
    }

    // Update the existing course
    existingCourse.Code = updatedCourse.Code;
    existingCourse.Title = updatedCourse.Title;
    existingCourse.Credits = updatedCourse.Credits;
    existingCourse.Instructor = updatedCourse.Instructor;

    return Results.Ok(existingCourse);
});


 // DELETE: Remove a course
app.MapDelete("/api/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
    {
        return Results.NotFound();
    }

    courses.Remove(course);

    return Results.NoContent();
});

app.Run();
