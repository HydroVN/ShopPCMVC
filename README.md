# 💻 Website Bán Máy Tính & Phụ Kiện PC

Dự án xây dựng website bán máy tính để bàn (PC Gaming) và phụ kiện máy tính sử dụng ASP.NET Core MVC kết hợp SQL Server.

---

# 🚀 Công nghệ sử dụng

| Công nghệ                | Mô tả                     |
| ------------------------ | ------------------------- |
| ASP.NET Core MVC .NET 10 | Framework phát triển web  |
| Entity Framework Core    | ORM thao tác CSDL         |
| SQL Server               | Hệ quản trị cơ sở dữ liệu |
| Bootstrap 5 / CSS        | Thiết kế giao diện        |
| Cookie Authentication    | Xác thực đăng nhập        |

---

# 📦 Cài đặt NuGet Packages

Mở:

```text id="6h4jxp"
Tools → NuGet Package Manager → Manage NuGet Packages for Solution
```

Cài các package sau:

| Package                                     | Chức năng                |
| ------------------------------------------- | ------------------------ |
| Microsoft.EntityFrameworkCore               | Entity Framework Core    |
| Microsoft.EntityFrameworkCore.SqlServer     | Kết nối SQL Server       |
| Microsoft.EntityFrameworkCore.Tools         | Migration & Scaffold     |
| Microsoft.EntityFrameworkCore.Design        | Hỗ trợ thiết kế EF Core  |

---

# ⚡ Cài nhanh bằng Package Manager Console

Mở:

```text id="rx0q9q"
Tools → NuGet Package Manager → Package Manager Console
```

Chạy lần lượt:

```powershell id="5yk1jv"
Install-Package Microsoft.EntityFrameworkCore
```

```powershell id="11ejk9"
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

```powershell id="p8dnlf"
Install-Package Microsoft.EntityFrameworkCore.Tools
```

```powershell id="h2pk7e"
Install-Package Microsoft.EntityFrameworkCore.Design
```

---

# 🗄️ Import Database Có Sẵn

Project sử dụng file database:

```text id="z8t3g7"
Database1.sql
```

## Cách import database vào SQL Server

### Bước 1: Mở SQL Server Management Studio (SSMS)

Kết nối tới SQL Server bằng tài khoản:

```text id="9xjlwm"
Server Name: .
Login: sa
Password: your_password
```

---

### Bước 2: Tạo Database mới

Chuột phải:

```text id="5l0a3h"
Databases → New Database
```

Đặt tên:

```text id="v3r2mj"
ComputerShopDB
```

---

### Bước 3: Mở file Database1.sql

Trong SSMS:

```text id="e0xjlwm"
File → Open → File
```

Chọn:

```text id="jlwm990"
Database1.sql
```

---

### Bước 4: Chạy file SQL

Nhấn:

```text id="jlwm101"
Execute
```

hoặc phím:

```text id="jlwm102"
F5
```

Sau khi chạy thành công sẽ tạo toàn bộ:

* Tables
* Relationships
* Dữ liệu mẫu

---

# 🛠️ Clone Project

```bash id="jlwm103"
git clone https://github.com/your-username/your-project.git
```

---

# 📂 Mở Project

Mở file:

```text id="jlwm104"
MVCQuanLyBanMayTinh.sln
```

bằng Visual Studio 2022.

---

# ⚙️ Cấu hình SQL Server

Mở file:

```text id="jlwm105"
appsettings.json
```

Sửa chuỗi kết nối:

```json id="jlwm106"
{
  "ConnectionStrings": {
    "ComputerShopDB": "Server=.;Database=ComputerShopDB;User Id=sa;Password=your_password;TrustServerCertificate=True;"
  }
}
```

Ví dụ:

```json id="jlwm107"
{
  "ConnectionStrings": {
    "ComputerShopDB": "Server=.;Database=ComputerShopDB;User Id=sa;Password=123456;TrustServerCertificate=True;"
  }
}
```

---

# 🗄️ Scaffold Database

Mở Package Manager Console và chạy:

```powershell id="jlwm108"
Scaffold-DbContext "Server=.;Database=ComputerShopDB;User Id=sa;Password=your_password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -DataAnnotations -Force
```

---

# ▶️ Chạy Project

Build project:

```bash id="jlwm109"
dotnet build
```

Chạy project:

```bash id="jlwm110"
dotnet run
```

Hoặc nhấn:

```text id="jlwm111"
F5
```

---

# 👤 Chức năng người dùng

* Đăng ký tài khoản
* Đăng nhập / Đăng xuất
* Xem danh sách sản phẩm
* Tìm kiếm sản phẩm
* Xem chi tiết sản phẩm
* Responsive giao diện

---

# 👑 Chức năng Admin

* Dashboard quản trị
* CRUD sản phẩm
* CRUD danh mục
* Quản lý người dùng
* Phân quyền Admin/User
* Thống kê sản phẩm

---

# 🔐 Cấp quyền Admin

Sau khi đăng ký tài khoản, mở SQL Server Management Studio (SSMS) và chạy:

```sql id="jlwm112"
UPDATE Users
SET Role_Id = 1
WHERE Id = 1;
```

Ví dụ:

```sql id="jlwm113"
UPDATE Users
SET Role_Id = 1
WHERE Id = 5;
```

Trong đó:

| Giá trị     | Ý nghĩa |
| ----------- | ------- |
| Role_Id = 1 | Admin   |
| Role_Id = 2 | User    |

---

# 📁 Cấu trúc thư mục

```text id="jlwm114"
├── Areas
│   └── Admin
├── Controllers
├── Data
├── Models
├── Views
├── wwwroot
├── Database1.sql
├── appsettings.json
└── Program.cs
```

---

# 🔄 Các lệnh GitHub

## Khởi tạo Git

```bash id="jlwm115"
git init
```

---

## Thêm file

```bash id="jlwm116"
git add .
```

---

## Commit

```bash id="jlwm117"
git commit -m "First commit"
```

---

## Kết nối GitHub

```bash id="jlwm118"
git remote add origin https://github.com/username/repository.git
```

---

## Push code

```bash id="jlwm119"
git branch -M main
git push -u origin main
```

---

# ❌ Nếu lỗi push GitHub

Chạy:

```bash id="jlwm120"
git pull origin main --allow-unrelated-histories
```

Sau đó:

```bash id="jlwm121"
git push -u origin main
```

---

# 📌 File .gitignore

Tạo file:

```text id="jlwm122"
.gitignore
```

Nội dung:

```gitignore id="jlwm123"
bin/
obj/
.vs/
appsettings.Development.json
```

---

# 🖥️ Yêu cầu hệ thống

* Visual Studio 2022
* .NET 10
* SQL Server 2019+
* SQL Server Management Studio (SSMS)

---

# 📸 Giao diện

* Trang chủ
* Trang sản phẩm
* Chi tiết sản phẩm
* Đăng nhập / Đăng ký
* Admin Dashboard

---


