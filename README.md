# Intense HR Platform

A REST API for managing job candidates and their skills, built as part of an internship application task.


## Technologies
- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- MySQL (Pomelo EF Core provider)
- Swagger / OpenAPI


## Setup
1. **Configure the database** – update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DbCon": "server=localhost;database=YOUR_DB;user=YOUR_USER;password=YOUR_PASSWORD"
   }
    ```        

2. **Apply migrations** – this will create the tables and seed initial data:
    `Update-Database`

3. **Run the project** - Press F5 or use the Run button in Visual Studio

4. **Open Swagger UI** to explore and test the API.


## Seed Data
The database is pre-populated with 5 candidates and 6 skills (C#, Java, C++, Database Design, English, Russian) with predefined assignments, so the API can be tested immediately after setup.


## Hardest Part 
The most challenging part was implementing the SearchCandidate method, particularly the case where the user searches by multiple skills at once.

**The solution works as follows:**

1. Get the IDs of all skills matching the search skills names
2. Go through the junction table (JobCandidatesSkills) to get the IDs of all candidates that have at least one of those skills — a candidate's ID appears once per matching skill they possess
3. Group the results by candidate ID and count occurrences — only candidates whose count equals the total number of searched skills are returned

When both a name and skills are provided, candidates are first filtered by name, and then the same skill-counting logic is applied to that filtered set.