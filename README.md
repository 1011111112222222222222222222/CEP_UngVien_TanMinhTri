1/clone code về 
2.1:mở sql sever tạo database có tên là CustomerManagementDb
2.2: chạy sql ở CustomerManagement.Api/Data/Data_CEP.sql
3/ sửa appsettings.json 
phần   "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=của máy cá nhân của sếp sau khi chạy file sql;Database=CustomerManagementDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  4/mở configure Staup project: chọn Multi staup project phần action chọn hết start ->>apply--> ok
  5/ nhấn f5 hay start trong visual studio để chạy 
