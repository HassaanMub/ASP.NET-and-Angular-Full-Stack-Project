# Vehicle Management System 🚗

A full-stack Vehicle Management System built using **ASP.NET Core Web API**, **Entity Framework Core**, and **Angular**.  
The project follows a clean architecture approach with separate layers for scalability and maintainability.

---

## 🛠️ Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQLite Database
- Clean Architecture (Domain, Application, Infrastructure, API layers)

### Frontend
- Angular (Standalone Components)
- TypeScript
- HTML / CSS
- RxJS

---

## 📁 Project Structure

```text
VehicleManagementSystem/
│
├── VehicleManagementSystem.AngularClient   # Frontend (Angular)
├── VehicleManagementSystem.API             # Backend API (Controllers, DB)
├── VehicleManagementSystem.Application     # Business logic layer
├── VehicleManagementSystem.Domain          # Entities / Models
├── VehicleManagementSystem.Infrastructure  # Data access / EF Core
```

---

## 🚀 Features

- View list of vehicles
- View vehicle details page
- Dynamic routing (`/products/:id`)
- API integration with Angular
- Clean layered backend architecture
- SQLite database integration

---

## ▶️ How to Run the Project

### Backend (API)

1. Open solution in Visual Studio or VS Code
2. Navigate to API folder:
   ```
   VehicleManagementSystem.API
   ```
3. Run migrations (if needed):
   ```
   dotnet ef database update
   ```
4. Start API:
   ```
   dotnet run
   ```

API will run on:
```
http://localhost:5248
```

---

### Frontend (Angular)

1. Navigate to Angular project:
   ```
   VehicleManagementSystem.AngularClient
   ```

2. Install dependencies:
   ```
   npm install
   ```

3. Run Angular app:
   ```
   ng serve
   ```

Frontend runs on:
```
http://localhost:4200
```

---

## 📌 Notes

- Backend must be running before frontend works properly
- Images are served from API (`wwwroot/images`)
- Database used is SQLite (`vehicle.db`)

---

## 👨‍💻 Author

Built as a learning project for full-stack development using Angular + ASP.NET Core.

```
---
