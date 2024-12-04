# IdentityWithJwtTestProject

## Description

This project manages user authentication and authorization using **ASP.NET Identity Library** and **JSON Web Token (JWT)**. Authentication rules are implemented through JWT, 
and authorization processes are defined based on custom attributes and the roles provided by the Identity Library.

## Features

- **User Registration**: New users can register to the system.
- **Role Management**: Administrators can assign permissions to roles, specifying which attributes each role can access.
- **Authorization**: Based on assigned roles, users can perform actions on the `Product` test controller.

## Development Approach

The project was developed with guidance from the **Angular E-Commerce Course** by **Gencay Yıldız** an instructor on YouTube.
The course provided valuable insights into building a secure and scalable authentication and authorization system.

## How It Works

1. Users register using the Identity Library.
2. Roles and permissions are assigned by the administrator.
3. Authorized users can interact with the `Product` controller's methods based on their roles.

## Technologies Used

- **ASP.NET Core Identity**
- **JWT (JSON Web Token)**
- **Custom Attributes for Authorization**

---
