# 🚌 AIUB Shuttle Management System

![AIUB Banner](https://img.shields.io/badge/AIUB-Shuttle%20Management-blue?style=for-the-badge)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_Framework-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

## 📋 Overview

**AIUB Shuttle Management System** is a comprehensive desktop application designed to streamline shuttle transportation services for the **American International University-Bangladesh (AIUB)**. Built with C# Windows Forms and SQL Server, it enables efficient management of shuttle bookings, routes, schedules, and real-time seat availability tracking.

The platform features a **multi-role authentication system** (Student, Faculty, Staff, Admin) with automated booking management, schedule tracking, notification systems, and comprehensive administrative controls.

---

## ✨ Key Features

### 👤 **For Students & Faculty**
- 📝 Register and create user accounts with role-based ID validation
- 🔍 View available shuttle schedules and routes
- 🎫 Book shuttle seats in real-time
- 📊 Track booking history and status
- 🔔 Receive system notifications about bookings and updates
- ✏️ Update profile information (email, password, phone, address)
- ❌ Cancel bookings
- 🔐 Secure password recovery system

### 🏛️ **For Administrators**
- 👥 Manage user accounts (Students, Faculty, Staff)
  - Add new users with complete profile information
  - Edit existing user details
  - View user booking information
  - Cancel user bookings
- 🚐 Manage shuttles and routes
- 📊 View system-wide dashboard with statistics
- 💾 User data management with full CRUD operations
- 📢 Send notifications to users
- 🔧 Monitor system operations

---

## 🛠️ Technology Stack

### **Frontend**
- ![C#](https://img.shields.io/badge/-C%23-239120?logo=c-sharp&logoColor=white) **C# Windows Forms** - Rich desktop UI with modern controls
- **Custom UI Components** - Reusable user controls (userComponents folder)
- **Component Cards** - Modular UI card components

### **Backend**
- ![.NET](https://img.shields.io/badge/-.NET_Framework-5C2D91?logo=.net&logoColor=white) **.NET Framework** - Core application framework
- ![SQL Server](https://img.shields.io/badge/-SQL_Server-CC2927?logo=microsoft-sql-server&logoColor=white) **SQL Server** - Relational database management
- **ADO.NET** - Data access and database operations

### **Architecture**
- **Windows Forms Application** - Event-driven desktop application
- **Direct Database Access** - SQL queries with parameterized commands
- **Session Management** - Role-based user authentication
- **Notification System** - Real-time user notifications

---

## 📁 Project Structure

```
AIUB_SHUTTLE_MANAGEMENT_SYSTEM/
│
├── Database.sql                          # Database creation script
├── LICENSE                               # MIT License
├── README.md                             # Project documentation
├── AIUB_SHUTTLE_MANAGEMENT_SYSTEM.sln   # Visual Studio solution
│
└── NewInterior/                         # Main application project
    ├── Program.cs                       # Application entry point
    ├── mainForm.cs                      # Main application form with sidebar navigation
    ├── App.config                       # Configuration settings
    ├── app.manifest                     # Application manifest
    │
    ├── Login/                           # Authentication module
    │   ├── LoginFrom.cs                 # Login interface
    │   ├── RegisterForm.cs              # User registration
    │   ├── ForgotFrom.cs                # Password recovery
    │   └── CreateNewPassword.cs         # Password reset
    │
    ├── Views/                           # User interface forms
    │   ├── formHome.cs                  # User home dashboard
    │   ├── formDashboard.cs             # Admin dashboard
    │   ├── formManageAccount.cs         # Account management
    │   ├── formShuttleSchedule.cs       # Shuttle schedules
    │   ├── formShuttleList.cs           # Shuttle list view
    │   ├── formAboutUs.cs               # About page
    │   ├── formAddStudent.cs            # Add student form
    │   ├── formAddFaculty.cs            # Add faculty form
    │   ├── formAddStuff.cs              # Add staff form
    │   ├── formEditStudent.cs           # Edit student details
    │   ├── formEditFaculty.cs           # Edit faculty details
    │   └── formEditStuff.cs             # Edit staff details
    │
    ├── Models/                          # Data models
    │   └── MakeNotification.cs          # Notification system model
    │
    ├── Database/                        # Database connection layer
    │   └── DatabaseConnection.cs        # SQL Server connection management
    │
    ├── userComponents/                  # Custom user controls
    │
    ├── componentCards/                  # Reusable UI card components
    │
    ├── Resources/                       # Application resources
    │   └── (images, icons, assets)
    │
    └��─ Properties/                      # Project properties
        └── AssemblyInfo.cs
```

---

## 🚀 Installation & Setup

### **Prerequisites**
- Windows 10 or later
- Visual Studio 2019 or 2022 (with .NET Desktop Development workload)
- .NET Framework 4.7.2 or later
- Microsoft SQL Server 2016+ or SQL Server Express
- SQL Server Management Studio (SSMS) - recommended

### **Step 1: Clone Repository**
```bash
git clone https://github.com/Mahbubul-Islam/AIUB_SHUTTLE_MANAGEMENT_SYSTEM.git
cd AIUB_SHUTTLE_MANAGEMENT_SYSTEM
```

### **Step 2: Switch to Main Branch**
```bash
git checkout Final-Project
```

### **Step 3: Database Setup**
1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
3. Open the `Database.sql` file from the repository root
4. Execute the script to create database and tables

The script creates:
- **Database**: `AIUB_SHUTTLE_MANAGEMENT_SYSTEM`
- **Tables**: 
  - `Users` (UserID, Name, Email, Password, Role, Gender, Nationality, BloodGroup, Address, Dob, PhoneNumber)
  - `Shuttles` (ShuttleName, Route, Capacity, Time)
  - `Booking` (BookingID, ShuttleName, UserID, BookingSeatNumber, BookingStatus, BookedTime)
  - `Notifications` (NotificationID, Message, UserID, Date)

### **Step 4: Configure Database Connection**
1. Open the solution in Visual Studio
2. Navigate to `NewInterior/Database/DatabaseConnection.cs`
3. Update the connection string with your SQL Server instance name:

```csharp
private static readonly string connectionString = "Server=YOUR_SERVER_NAME\\SQLEXPRESS; database=AIUB_SHUTTLE_MANAGEMENT_SYSTEM; integrated security=SSPI";
```

**Example Server Names**:
- `DESKTOP-RPJPVDU\\SQLEXPRESS`
- `localhost\\SQLEXPRESS`
- `.\\SQLEXPRESS`
- `MH-SHUVO\\SQLEXPRESS`

### **Step 5: Build and Run**
1. Open `AIUB_SHUTTLE_MANAGEMENT_SYSTEM.sln` in Visual Studio
2. Build the solution (Ctrl + Shift + B)
3. Press `F5` or click **"Start"** to run the application
4. The login form will appear

---

## 🎯 Usage Guide

### **Default Login Credentials**
After running the database script, use these credentials:

```
UserID: admin
Password: admin
Role: Admin
```

### **User ID Formats**
Each role has a specific ID format:
- **Student**: `XX-XXXXX-X` (e.g., 22-54555-2)
- **Faculty**: `XXXX-XXX-X` (e.g., 1234-123-1)
- **Staff**: `XX-XX-X` (e.g., 12-34-1)
- **Admin**: Custom format

### **Registration Process**
1. Click "Sign Up" on login screen
2. Select role (Student/Faculty/Staff)
3. Enter details with correct ID format
4. Valid email required (must contain @)
5. Password and confirm password must match

### **Password Recovery**
1. Click "Forgot Password" on login screen
2. Enter UserID, Name, and Email
3. System validates information
4. Create new password
5. Password must be different from previous

---

## 🔔 **Notification System**

The application features an **integrated notification system** that tracks user actions:

### **Features:**
- ✅ **Automated notifications** for user actions
- 💾 **Database-stored notifications** in Notifications table
- 📢 **Admin notifications** for system events
- 🔐 **User-specific notifications** for account changes

### **Notification Triggers:**
- User account updates
- Password changes
- Booking cancellations
- New user additions (admin notification)
- Profile modifications

### **Implementation:**
```csharp
// Example from code
MakeNotification.AddNotification(userId, "Your account is updated!");
MakeNotification.AddNotification(userId, "Your booking is canceled!");
MakeNotification.AddNotification(adminId, "A user is added!");
```

---

## 📊 Database Schema

### **Users Table**
| Column | Type | Description |
|--------|------|-------------|
| UserID | VARCHAR(50) | Primary key, unique identifier (PK) |
| Name | VARCHAR(100) | User's full name |
| Email | VARCHAR(100) | Email address |
| Password | VARCHAR(100) | User password (stored as plain text) |
| Role | VARCHAR(50) | User role (Student/Faculty/Staff/Admin) |
| Gender | VARCHAR(10) | Gender |
| Nationality | VARCHAR(50) | Nationality |
| BloodGroup | VARCHAR(10) | Blood group |
| Address | VARCHAR(255) | Residential address |
| Dob | DATE | Date of birth |
| PhoneNumber | VARCHAR(20) | Contact number |

### **Shuttles Table**
| Column | Type | Description |
|--------|------|-------------|
| ShuttleName | VARCHAR(50) | Primary key, shuttle identifier (PK) |
| Route | VARCHAR(100) | Shuttle route details |
| Capacity | INT | Total seat capacity |
| Time | TIME | Departure time |

### **Booking Table**
| Column | Type | Description |
|--------|------|-------------|
| BookingID | INT | Primary key, auto-increment (PK) |
| ShuttleName | VARCHAR(50) | Foreign key to Shuttles (FK) |
| UserID | VARCHAR(50) | Foreign key to Users (FK) |
| BookingSeatNumber | VARCHAR(50) | Assigned seat number |
| BookingStatus | VARCHAR(50) | Booking status |
| BookedTime | DATETIME | Booking timestamp |

### **Notifications Table**
| Column | Type | Description |
|--------|------|-------------|
| NotificationID | INT | Primary key, manual increment (PK) |
| Message | TEXT | Notification message |
| UserID | VARCHAR(50) | Foreign key to Users (FK) |
| Date | DATETIME | Notification timestamp |

---

## 👥 Contributors

This project was developed as a collaborative effort by a team of AIUB students:

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/Mahbubul-Islam">
        <img src="https://avatars.githubusercontent.com/u/152017110?v=4" width="100px;" alt="Mahbubul Islam"/>
        <br />
        <sub><b>Mahbubul Islam (Shiam)</b></sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/MH-SHUVO20">
        <img src="https://avatars.githubusercontent.com/u/125986989?v=4" width="100px;" alt="MD. Mehedi Hasan Shuvo"/>
        <br />
        <sub><b>MD. Mehedi Hasan Shuvo</b></sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/ShinJon1903">
        <img src="https://avatars.githubusercontent.com/u/192086391?v=4" width="100px;" alt="Mantasa Afrin Shinjon"/>
        <br />
        <sub><b>Mantasa Afrin Shinjon</b></sub>
      </a>
    </td>
    <td align="center">
      <img src="https://via.placeholder.com/100?text=AB" width="100px;" alt="Apu Barua"/>
      <br />
      <sub><b>Apu Barua</b></sub>
    </td>
  </tr>
</table>

---

## 🔒 Security Features

- ✅ **Case-sensitive authentication** - SQL collation for UserID and Password
- ✅ **SQL parameterized queries** - Prevents SQL injection
- ✅ **Role-based access control** - Different interfaces for different roles
- ✅ **Password recovery system** - Validates user identity before reset
- ✅ **Input validation** - Client-side and server-side validation
- ✅ **Email format validation** - Required '@' symbol
- ✅ **User ID pattern matching** - Regex validation for each role
- ✅ **Foreign key constraints** - Database referential integrity with CASCADE delete

---

## 🐛 Known Issues & Future Enhancements

### **Current Limitations**
- Passwords stored in plain text (not hashed)
- No email notification system
- No real-time shuttle tracking
- Desktop-only application

### **Planned Features**
- 📧 **Password hashing** - Secure password storage (bcrypt/SHA-256)
- 📱 **Mobile application** (Android/iOS)
- 🌐 **Web portal** for cross-platform access
- 🗺️ **GPS tracking** for real-time shuttle location
- 📊 **Advanced analytics** with charts and graphs
- 💳 **Payment integration** for booking fees
- 🔔 **Email notifications** for booking confirmations
- 📲 **SMS alerts** for booking updates
- 🎫 **QR code** based ticket system
- 🌙 **Dark mode** theme option

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

```
MIT License
Copyright (c) 2025 Mahbubul Islam

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software...
```

---

## 📞 Contact

For queries, suggestions, or contributions:

- **Mahbubul Islam (Shiam)**: [@Mahbubul-Islam](https://github.com/Mahbubul-Islam) | mahbubulislamshiam48@gmail.com
- **MD. Mehedi Hasan Shuvo**: [@MH-SHUVO20](https://github.com/MH-SHUVO20) | mdmehedihasanshuvo994@gmail.com
- **Mantasa Afrin Shinjon**: [@ShinJon1903](https://github.com/ShinJon1903)
- **Apu Barua**: Team Member

---

## 🙏 Acknowledgments

- **American International University-Bangladesh (AIUB)** - For inspiration and academic support
- **Course Instructor** - For guidance throughout the project development
- **All team members** - For dedication and collaborative effort
- **Open Source Community** - For tools and resources

---

## 🔧 Troubleshooting

### **Common Issues**

**1. Database Connection Error**
```
Error: Cannot connect to database
Solution: 
- Check SQL Server is running
- Update server name in DatabaseConnection.cs
- Ensure integrated security is enabled
```

**2. Login Failed**
```
Error: Invalid username or password
Solution: 
- Verify credentials (case-sensitive)
- Check database has admin user
- Run Database.sql script to create default admin
```

**3. Build Errors**
```
Error: Missing references or dependencies
Solution: 
- Restore NuGet packages
- Check .NET Framework version (4.7.2+)
- Clean and rebuild solution
```

**4. User ID Format Error**
```
Error: Invalid User ID format
Solution: 
- Student: XX-XXXXX-X (e.g., 22-54555-2)
- Faculty: XXXX-XXX-X (e.g., 1234-123-1)
- Staff: XX-XX-X (e.g., 12-34-1)
```

For more help, visit the [Issues](https://github.com/Mahbubul-Islam/AIUB_SHUTTLE_MANAGEMENT_SYSTEM/issues) page.

---

<p align="center">
  <b>⭐ Star this repository if you find it helpful!</b>
  <br/>
  <sub>Made with ❤️ by AIUB Students for AIUB Community</sub>
  <br/><br/>
  <img src="https://img.shields.io/github/stars/Mahbubul-Islam/AIUB_SHUTTLE_MANAGEMENT_SYSTEM?style=social" alt="GitHub stars"/>
  <img src="https://img.shields.io/github/forks/Mahbubul-Islam/AIUB_SHUTTLE_MANAGEMENT_SYSTEM?style=social" alt="GitHub forks"/>
  <img src="https://img.shields.io/github/contributors/Mahbubul-Islam/AIUB_SHUTTLE_MANAGEMENT_SYSTEM" alt="Contributors"/>
</p>
