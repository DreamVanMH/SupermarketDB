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

> img reference from Amazon.ca, only for educational purpose

---

## 🚀 Getting Started

Copy the sample config and fill in your own credentials:

````bash
cp appsettings.Template.json appsettings.json

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

📜 MIT License

Copyright (c) 2025 DreamVanMH

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction...

---

Educational Use Notice:
This project is intended for **educational and demonstration purposes only**.
All trademarks and product images referenced (e.g., from Amazon.ca) are the property of their respective owners.
No commercial use or distribution of such materials is intended or permitted.

## 🛡️ Image Use Disclaimer

All product images shown in this project are referenced from Amazon.ca and are used **strictly for educational and non-commercial purposes only**.
The copyright and trademarks of all product images belong to their respective owners.
This project is not affiliated with or endorsed by Amazon in any way.

If you are the copyright holder and believe any content should be removed, please contact us.

---
````
