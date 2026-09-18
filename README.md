Clone code về máy.Tạo Database & Chạy file SQL:Mở SQL Server Management Studio (SSMS), tạo Database tên là: CustomerManagementDb.Mở và chạy (Execute) file CustomerManagement.Api/Data/Data_CEP.sql (file đã gửi kèm) vào database vừa tạo.Cấu hình appsettings.json (trong project CustomerManagement.Api):Sửa lại chuỗi kết nối ConnectionStrings theo tên Server SQL trên máy sếp:JSON"AllowedHosts": "*",
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=CustomerManagementDb;Trusted_Connection=True;TrustServerCertificate=True"
}
(Ghi chú: Nếu máy sếp dùng SQL Express thì thay localhost thành .\SQLEXPRESS).Cấu hình Startup Projects:Nhấp chuột phải vào Solution $\rightarrow$ chọn Properties.Chọn Startup Project $\rightarrow$ tích Multiple startup projects.Chuyển các project cần chạy (như API / Web UI) sang Start $\rightarrow$ nhấn Apply $\rightarrow$ OK.Chạy dự án: Nhấn F5 hoặc nút Start trên Visual Studio.
