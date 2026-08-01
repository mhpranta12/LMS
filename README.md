# [LMS (Library Management System)]

[This application consisted with multiple features focusing on the management of a library.]

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-lightgrey)

---


## Architecture
```
┌─────────────────────────────┐
│        Presentation         │  ← Controllers, API endpoints
├─────────────────────────────┤
│         Application         │  ← Use cases, DTOs, interfaces, validation
├─────────────────────────────┤
│           Domain            │  ← Entities, enums, domain logic
├─────────────────────────────┤
│        Infrastructure       │  ← EF Core, repositories, external services
└─────────────────────────────┘
---
```
## Set Up Instructions 
**Backend**
Clone the repository
Copy the appsetting.json file
Create a Database in local named lms
Run the migrations file from the repository
Then rebuild the application
Then run the API Project.
Then Add some User role in the data base role table. 
Then Register as a new user
Then Login by that credentials
Then End points will be seen


## Front End
Clone the repository
Then run these commands in terminal
npm install
npm run dev

Then open the given port in browser 


## Features Completed
Backend
Full CRUD for Books maagement . Also books by branch and by category view


## Assumptions and design decisions
Architecture: Clean Architecture (To ensure proper organization, single responsiblity, testability)
Design Principles : SOLID (To ensure separation of concern)

Design Patterns  : Unit of work (To ensure atomicity of operations) , Repository (To ensure single responsibility)
Security : JWT Token

## How to run the application

