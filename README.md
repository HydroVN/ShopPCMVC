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

```text id="lqk8l4"
Tools → NuGet Package Manager → Manage NuGet Packages for Solution
```

Cài các package sau:

| Package                                     | Chức năng                |
| ------------------------------------------- | ------------------------ |
| Microsoft.EntityFrameworkCore               | Entity Framework Core    |
| Microsoft.EntityFrameworkCore.SqlServer     | Kết nối SQL Server       |
| Microsoft.EntityFrameworkCore.Tools         | Migration & Scaffold     |
| Microsoft.EntityFrameworkCore.Design        | Hỗ trợ thiết kế EF Core  |
| Microsoft.AspNetCore.Authentication.Cookies | Đăng nhập Authentication |

---

# ⚡ Cài nhanh bằng Package Manager Console

Mở:

```text id="t2j0av"
Tools → NuGet Package Manager → Package Manager Console
```

Chạy lần lượt:

```powershell id="gj42nn"
Install-Package Microsoft.EntityFrameworkCore
```

```powershell id="zwywyc"
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

```powershell id="b2rjlwm"
Install-Package Microsoft.EntityFrameworkCore.Tools
```

```powershell id="lgjlwm9"
Install-Package Microsoft.EntityFrameworkCore.Design
```

---

# 🛠️ Clone Project

```bash id="u9r9c4"
git clone https://github.com/your-username/your-project.git
```

---

# 📂 Mở Project

Mở file:

```text id="q5uqc5"
MVCQuanLyBanMayTinh.sln
```

bằng Visual Studio 2022.

---

# ⚙️ Cấu hình SQL Server

Mở file:

```text id="2d6g7g"
appsettings.json
```

Sửa chuỗi kết nối:

```json id="7o8v9y"
{
  "ConnectionStrings": {
    "ComputerShopDB": "Server=.;Database=ComputerShopDB;User Id=sa;Password=your_password;TrustServerCertificate=True;"
  }
}
```

Ví dụ:

```json id="v7yn7y"
{
  "ConnectionStrings": {
    "ComputerShopDB": "Server=.;Database=ComputerShopDB;User Id=sa;Password=123456;TrustServerCertificate=True;"
  }
}
```

---

# 🗄️ Scaffold Database

Mở Package Manager Console và chạy:

```powershell id="yjlwm7"
Scaffold-DbContext "Server=.;Database=ComputerShopDB;User Id=sa;Password=your_password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -DataAnnotations -Force
```

---

# ▶️ Chạy Project

Build project:

```bash id="bbjlwm"
dotnet build
```

Chạy project:

```bash id="6vjlwm"
dotnet run
```

Hoặc nhấn:

```text id="evj2t6"
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

```sql id="l2jlwm"
UPDATE Users
SET Role_Id = 1
WHERE Id = 1;
```

Ví dụ:

```sql id="qjlwm0"
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

```text id="8xjlwm"
├── Areas
│   └── Admin
├── Controllers
├── Data
├── Models
├── Views
├── wwwroot
├── appsettings.json
└── Program.cs
```

---

# 🔄 Các lệnh GitHub

## Khởi tạo Git

```bash id="52jlwm"
git init
```

---

## Thêm file

```bash id="jlwm11"
git add .
```

---

## Commit

```bash id="mjlwm2"
git commit -m "First commit"
```

---

## Kết nối GitHub

```bash id="pjlwm3"
git remote add origin https://github.com/username/repository.git
```

---

## Push code

```bash id="tjlwm4"
git branch -M main
git push -u origin main
```

---

# ❌ Nếu lỗi push GitHub

Chạy:

```bash id="rjlwm5"
git pull origin main --allow-unrelated-histories
```

Sau đó:

```bash id="jlwm66"
git push -u origin main
```

---

# 📌 File .gitignore

Tạo file:

```text id="djlwm7"
.gitignore
```

Nội dung:

```gitignore id="jlwm88"
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


