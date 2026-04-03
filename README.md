# 📝 Task Manager API (Clean Architecture)

## 🚀 Project Overview

This is a simple Task Management API built using **ASP.NET Core** following **Clean Architecture** principles.

The system allows users to perform CRUD operations on tasks.

---

## 🏗️ Architecture

This project follows Clean Architecture:

* **Domain Layer** → Entities
* **Application Layer** → Interfaces, DTOs, Services
* **Infrastructure Layer** → Database access (ADO.NET, SQL)
* **API Layer** → Controllers

---

## ⚙️ Technologies Used

* ASP.NET Core Web API
* ADO.NET
* SQL Server
* Clean Architecture
* Dependency Injection

---

## 📌 Features

* ✅ Create Task
* ✅ Get All Tasks
* ✅ Get Task By Id
* ✅ Update Task
* ✅ Delete Task

---

## 🔌 API Endpoints

| Method | Endpoint       | Description     |
| ------ | -------------- | --------------- |
| GET    | /api/task      | Get all tasks   |
| GET    | /api/task/{id} | Get task by id  |
| POST   | /api/task      | Create new task |
| PUT    | /api/task      | Update task     |
| DELETE | /api/task/{id} | Delete task     |

---

## 🧪 How to Run

1. Clone the repo
2. Setup SQL Server DB
3. Update connection string in `appsettings.json`
4. Run the project
5. Use Swagger to test APIs

---

## 👨‍💻 Author

**Md Rafidul Islam Bhuiyan**
