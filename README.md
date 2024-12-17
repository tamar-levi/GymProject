Gym Management System
Overview
This project is a high-level gym management system built using .NET Core. The system allows efficient management of gym groups, trainers, fitness types, schedules, and pricing. It includes user role management where members can request to join groups, and only admins have the authority to approve or deny these requests. All data is stored securely in an SQL database.

Features
Group Management

Members can browse available fitness groups (e.g., aerobics, weightlifting, yoga).
Each group has a designated trainer.
Members can request to join any group.
Admin Controls

Only admins can approve or deny requests for group memberships.
Full control over creating, updating, or deleting fitness groups, trainers, and schedules.
Fitness Categories

Support for multiple types of fitness activities (e.g., aerobics, strength training).
Flexible assignment of trainers to fitness groups.
Schedules and Pricing

Detailed scheduling for each fitness group.
Ability to set different prices based on group type and session times.
Database Storage

All data, including users, groups, schedules, and requests, is stored in a relational SQL database.
Technologies Used
Backend: .NET Core (C#)
Database: SQL Server
Frameworks & Tools: Entity Framework Core, ASP.NET MVC
Version Control: Git
Installation and Setup
Clone the Repository


git clone https://github.com/yourusername/gym-management-system.git
Navigate to the Project Directory

cd gym-management-system
Database Setup

Update the connection string in appsettings.json to match your SQL Server configuration.

Apply migrations:


dotnet ef database update
Run the Project



dotnet run
Access the Application

Open a browser and go to:
http://localhost:5000

License
This project is licensed under the MIT License.
