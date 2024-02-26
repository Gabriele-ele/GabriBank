# GabriBank

## Introduction

This is simple bank payment system application. Application is for transactions between users and for managing users accounts.

## Setup

### Prerequisites

Make sure you have installed the following:

- dotnet 3.1 or later

### Building the application

```bash
dotnet build
```

### Running the application

```bash
dotnet run
```

### Database

The application is using PostgreSQL database.

## API documentation

### Endpoints

- `GET /users`: Returns a list of all users
- `GET /users{id}`: Returns user with specified id with users information
- `POST /users`: Cretes new user
- `POST /accounts`: Creates new account
- `PUT /accounts`: Updates account information (Saving or Default) and balance
- `POST /users{id}/transactions`: Makes a transaction
