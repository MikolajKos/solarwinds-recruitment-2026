# Software Engineer Recruitment Assignment

Welcome to my repository! This repository contains my solutions for the recruitment assignment. It is divided into two separate projects, each addressing a specific task.

## 📁 Repository Structure

### [Task 1: Calculator](./Task1_Calculator/swi)
A console application handling specific logic for calculations. 
*Please navigate to the `Task1_Calculator` folder and read its dedicated README for detailed information about the architecture.*

---

### Task 2: Rick and Morty API Integration
This is the core project of the assignment. It is an ASP.NET Core Web API that interacts with the public [Rick and Morty API](https://rickandmortyapi.com/). 

The API provides two main functionalities:
1. **Character Search:** A dedicated endpoint to quickly search and filter specific characters, locations and episodes by their name.
2. **Top Pairs Calculation:** An advanced algorithm that calculates and returns the most frequently occurring pairs of characters in the same episodes, grouped and filtered according to the user's criteria.

#### 🚀 Key Features
* **Search & Filter:** Easily retrieve character data based on name queries.
* **Asynchronous Processing:** Efficiently fetches data from external endpoints using `Task.WhenAll` to ensure maximum performance and avoid blocking the main thread.
* **Smart Batching:** Character requests for the "Top Pairs" feature are chunked into smaller batches to prevent URI length limits and reduce the number of HTTP requests.
* **Custom Algorithms:** Built-in logic to sort, filter, and limit the scope of the character pairs directly in memory using optimized dictionaries and LINQ.

#### 🛠️ Tech Stack
* **Framework:** .NET 8 (C#)
* **Web:** ASP.NET Core Web API
* **Testing:** xUnit, Moq
* **Containerization:** Docker

#### 🧪 Testing Strategy (Quality Assurance)
Testing was a major focus in this project. Instead of writing trivial tests for basic built-in language features (like simple LINQ filtering), I prioritized **critical domain logic and infrastructure boundaries**:
1. **Domain Logic:** Complex methods (like batch creation and dictionary sorting) are extracted and fully covered by unit tests with various edge cases (using `[MemberData]`).
2. **External API Mocking:** The `HttpClient` interactions are covered by integration-style tests. I implemented a custom `HttpMessageHandler` stub/mock strategy. This ensures the service logic is tested against simulated API JSON responses (handling multiple endpoint routes like `/episode` and `/character`) without making actual network calls.

#### 🏃‍♂️ How to Run
1. Navigate to the Task 2 project folder.
2. Restore dependencies:
   ```bash
   dotnet restore
   dotnet run
   ```
3. Open the provided Swagger UI URL in your browser (e.g., http://localhost:5000/swagger/index.html) to interact with the endpoints.
4. To run the test suite, simply navigate to RickAndMorty.Tests project and execute:
   ```bash
   dotnet test
   ```

### 🐳 How to Run (Docker)
1. Navigate to the Task 2 project catalog where '.sln' file is located.
2. Build the Docker image:
   ```bash
   docker build -f RickAndMortyApi/Dockerfile -t rick-and-morty-api .
   ```
3. Run the container (with Development environment enabled to access Swagger):
   ```bash
   docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development --name rm-api rick-and-morty-api
   ```
4. Open your browser and navigate to http://localhost:8080/swagger/index.html to explore the API. (Note: Adjust the port if your Docker configuration exposes a different one).
