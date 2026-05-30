# 💻 Website Bán Máy Tính & Phụ Kiện PC

Dự án xây dựng website bán máy tính để bàn (PC Gaming) và phụ kiện máy tính sử dụng:

* ASP.NET Core MVC (C#)
* SQL Server
* Entity Framework Core
* Bootstrap / CSS
* Authentication & Authorization

---

# 🚀 Chức năng chính

## 👤 Người dùng

* Đăng ký tài khoản
* Đăng nhập / Đăng xuất
* Xem danh sách sản phẩm
* Tìm kiếm sản phẩm
* Xem chi tiết sản phẩm
* Giao diện responsive

## 🛠️ Admin

* Quản lý sản phẩm (CRUD)
* Quản lý danh mục
* Quản lý người dùng
* Phân quyền Admin/User
* Dashboard quản trị

---

# 🗄️ Công nghệ sử dụng

| Công nghệ             | Mô tả                     |
| --------------------- | ------------------------- |
| ASP.NET Core MVC      | Framework backend         |
| Entity Framework Core | ORM kết nối CSDL          |
| SQL Server            | Hệ quản trị cơ sở dữ liệu |
| Bootstrap 5           | Thiết kế giao diện        |
| Cookie Authentication | Xác thực đăng nhập        |

---

# ⚙️ Cài đặt project

## 1️⃣ Clone project

```bash
git clone https://github.com/your-username/your-project.git
```

---

## 2️⃣ Mở project bằng Visual Studio

Mở file:

```text
YourProject.sln
```

---

## 3️⃣ Cấu hình chuỗi kết nối SQL Server

Mở file:

```text
appsettings.json
```

Sửa:

```json
"ConnectionStrings": {
  "ComputerShopDB": "Server=.;Database=ComputerShopDB;User Id=sa;Password=your_password;TrustServerCertificate=True;"
}
```

---

# 🛠️ Scaffold Database

Chạy lệnh:

```powershell
Scaffold-DbContext "Server=.;Database=ComputerShopDB;User Id=sa;Password=your_password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -DataAnnotations -Force
```

---

# ▶️ Chạy project

Mở Package Manager Console:

```powershell
Update-Database
```

Sau đó chạy:

```powershell
dotnet run
```

Hoặc nhấn:

```text
F5
```

---

# 👑 Cập nhật tài khoản thành Admin

Sau khi đăng ký tài khoản, mở SQL Server và chạy lệnh:

```sql
UPDATE Users
SET Role_Id = 1
WHERE Id = 1;
```

Trong đó:

* `Role_Id = 1` → quyền Admin
* `Id = 1` → ID tài khoản trong bảng Users

Ví dụ:

```sql
UPDATE Users
SET Role_Id = 1
WHERE Id = 5;
```

---

# 📂 Cấu trúc thư mục

```text
├── Controllers
├── Models
├── Views
├── Data
├── wwwroot
├── Areas
│   └── Admin
```

---

# 🔐 Tài khoản mặc định

## Admin

```text
Email: admin@gmail.com
Password: 123456
```

---

# 📸 Giao diện

* Trang chủ
* Trang sản phẩm
* Đăng nhập / Đăng ký
* Admin Dashboard

---

# 📌 Yêu cầu hệ thống

* Visual Studio 2022
* .NET 10
* SQL Server 2019+
* SSMS

---

