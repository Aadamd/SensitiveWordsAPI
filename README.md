# Sensitive Words Microservice

## Overview

The Sensitive Words Microservice provides functionality to filter out sensitive words from a given string. It includes a RESTful API with CRUD operations for managing the list of sensitive words.

## Features

- Filter Sensitive Words: Send a string to the microservice and it will sanitize the string by replacing the sensitive words with asterisks.
- Manage Sensitive Words: Add, Update, Delete and Retrieve the list of sensitive words.

## Details
- Framework: .NET CORE
- Database: Microsoft SQL Server
- API Documentation: Swagger

## API Endpoints
- GET /api/SensitiveWords/getSensitiveWords: Retrieve the list of sensitive words
- POST /api/SensitiveWords/addSensitiveWord: Add a new word
- POST /api/SensitiveWords/addSensitiveWords: Add a list of words
- PUT /api/SensitiveWords/updateSensitiveWord: Update an existing word
- DELETE /api/SensitiveWords/deleteSensitiveWord: Delete a sensitive word
- POST /api/SensitiveWords/sanitizeString: Sanitizes strings

## Configuration
- Connection String: Update the connection string in the 'appsettings.json' file to point to the SQL Server instance

## Future Improvements
- Make the word Id's Guid
- Make Models and DTO's for the data
- create a batch delete method
- Option to Delete word from DB using the word instead of the WordId
- Create DB or ensure the DB exists when running the API

