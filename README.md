# SupermarketDB 🛒

This is a web-based supermarket management system built with **ASP.NET MVC**. It allows users to manage product inventory and customer data through a user-friendly interface. The project supports basic CRUD operations, image uploads, and email notifications.

---

## 🔧 Tech Stack

- **.NET 7 / .NET 8**
- **ASP.NET MVC**
- **Entity Framework Core**
- **SQLite & SQL Server**
- **Bootstrap + HTML/CSS**
- **C#**

---

## 📦 Features

- ✅ Add/Edit/Delete products
- ✅ View customer list and details
- ✅ Upload product images to database
- ✅ Send emails using SMTP (e.g., Gmail)
- ✅ Connect to SQLite or SQL Server
- ✅ MVC structure with validation and model binding

---

## 📷 Screenshots

>

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/DreamVanMH/SupermarketDB.git
2. Open in VS Code or Visual Studio
bash
Copy
Edit
cd SupermarketDB
3. Update the connection string
Modify appsettings.json or DbContext to match your database setup:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Your_SQL_Server_or_SQLite_connection_string"
}
4. Run EF Core migrations
bash
Copy
Edit
dotnet ef migrations add InitialCreate
dotnet ef database update
📬 Email Configuration
Email settings are stored in appsettings.json. You need to provide your SMTP credentials to send emails:

json
Copy
Edit
"EmailSettings": {
  "SmtpServer": "smtp.gmail.com",
  "SmtpPort": 587,
  "SenderEmail": "your@gmail.com",
  "SenderName": "Your Name",
  "Username": "your@gmail.com",
  "Password": "your-app-password"
}
⚠️ Use an App Password if using Gmail and enable "Less secure app access" if needed.

📁 Project Structure
bash
Copy
Edit
SupermarketDB/
│
├── Controllers/          # MVC Controllers
├── Models/               # Entity classes
├── Views/                # Razor views for UI
├── Services/             # Email service
├── Data/                 # DbContext and migrations
├── wwwroot/img/          # Image uploads
├── appsettings.json      # Configuration
└── Program.cs            # Application entry point
🧪 Sample SQL Queries
Test in SSMS or SQLite CLI:

sql
Copy
Edit
SELECT * FROM products;
SELECT * FROM customers;
📅 Final Project Info
Developed for Programming for the Internet
📍 Fairleigh Dickinson University, Vancouver Campus
📅 July 2025
👤 Student: DreamVanMH

⭐ Future Improvements
 Add role-based authentication (admin/user)

 Shopping cart and checkout system

 Order history with receipts

📜 License
This project is for educational use only.
Not intended for commercial or production deployment.
```
