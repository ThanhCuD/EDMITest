# EDMITest
1. First you must use Sql management studio to run the script.sql file.
2. Change the EdmiDbContext in ConnectionStrings in file appsettings.json suitable with database you just create the structure :
"EdmiDbContext": "Server=[YourServerName];Initial Catalog=[NameDatabse];Persist Security Info=False;User ID=[user Name];Password=[Pass world];MultipleActiveResultSets=False;" 
example : "EdmiDbContext": "Server=DANHTHUCVIDAI1\\DANHTHUCVIDAI1;Initial Catalog=EDMI;Persist Security Info=False;User ID=sa;Password=abdef12;MultipleActiveResultSets=False;"
3. Run project
