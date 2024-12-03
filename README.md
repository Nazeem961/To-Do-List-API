# To-Do List REST API

This is a simple REST API for managing a To-Do List, built using ASP.NET Core Web API. It allows users to perform CRUD operations (Create, Read, Update, Delete) on tasks.

## Features

- Create a new task
- View all tasks
- Update an existing task (e.g., mark it as completed)
- Delete a task

## Technologies Used

- ASP.NET Core Web API
- C#
- In-memory data storage (can be extended to SQLite or SQL Server)

## How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/Nazeem961/ToDoList.git

2.Open the project in Visual Studio.

3.Run the project using Ctrl + F5.

4.Use any REST client (e.g., Postman) to interact with the API using the following endpoints:

GET /api/tasks - Get all tasks
POST /api/tasks - Add a new task
PUT /api/tasks/{id} - Update a task by ID
DELETE /api/tasks/{id} - Delete a task by ID

Example JSON for Creating a Task
{
  "title": "Complete the project",
  "status": false
}
