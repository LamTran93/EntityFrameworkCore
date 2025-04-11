<h1>EntityFramework Assignment</h1>

<h3>#1</h3>

The assignment #1 is in the EntityFrameworkCore project.

![image](https://github.com/user-attachments/assets/1d532081-452f-4d07-932f-6a392cf2f405)

To test the models, first replace the connection string "DefaultConnection" in appsetting.json. Then use the Package Manager Console (Visual Studio): <code>Update-database</code> or the .NET Core CLI:<code>dotnet ef database update</code>

<h3>#2</h3>

The assignment #2 is in the EntityFrameworkCore #2 project.

Project Structure:
![image](https://github.com/user-attachments/assets/c4300e2f-b761-4f60-a8c5-fea782d6247a)

- All models are in the Domain folder
- Repositories folder contain DbContext and all config
- Application folder contain logic
- Controllers folder contain Api expose
- Other folder holds dtos, exceptions...
