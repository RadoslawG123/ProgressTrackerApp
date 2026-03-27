# 📈 ProgressTrackerApp

> An ASP.NET Core MVC web application designed to help users track their goals, daily tasks, and habits. It features an integrated interactive calendar and provides private data isolation for every registered user.

## 🎥 Short Presentation

![Dashboard/Calendar Screenshot](./images/calendar-preview.png)

## 🛠 Tech Stack

- **Backend:** C#, ASP.NET Core MVC (.NET)
- **Database & ORM:** SQL Server, Entity Framework Core
- **Security/Auth:** ASP.NET Core Identity
- **Frontend:** Razor Pages (`.cshtml`), HTML, CSS, JavaScript
- **Libraries:** [FullCalendar.js](https://fullcalendar.io/) (for interactive event management)

## ⭐ Key Features

- **Secure Authentication:** Complete user registration and login system.
- **Global Authorization:** The entire application is protected by default, ensuring unauthorized users cannot access any endpoints (with intentional exceptions using `[AllowAnonymous]`).
- **Strict Data Privacy:** Every database record (Goals, Tasks, Habits) is strictly tied to a `UserId`, guaranteeing that users can only see and manage their own data.
- **Comprehensive CRUD Operations:** Full management of Goals, Tasks (linked to Goals), Habits, and Habit Completions.
- **Interactive Calendar:**
  - Displays habits as dynamic events.
  - Clickable days (`dateClick`) that redirect users to a creation form with pre-filled dates via URL parameters.
  - Color-coded events for better visual tracking.

## 🧠 What I Learned

This project helped me understand the core concepts of building a Full-Stack application using `C#` and `ASP.NET Core`. Key takeaways include:

- **Integrating Frontend Libraries:** I learned how to connect a third-party JavaScript library (FullCalendar) with a C# backend to display dynamic data on a web page.
- **Entity Framework Core Basics:** Gained practical experience in configuring database relationships (like One-to-Many between Goals and Tasks) and writing basic LINQ queries to retrieve and filter data.
- **User Authorization & Data Privacy:** I learned how to require users to log in before using the app. More importantly, I ensured that users can only see and manage their own records by filtering database queries by their `UserId`.
- **Data Validation:** Practiced using `ModelState` in controllers to verify user input from forms before saving anything to the database.
