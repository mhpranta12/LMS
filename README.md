# [LMS (Library Management System)]

[This application consisted with multiple features focusing on the management of a library.]

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-lightgrey)

---


## Architecture

[Describe the architectural style used, e.g. Clean/Onion Architecture, and briefly explain each layer's responsibility.]

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
<b> Set Up Instructions <b>

