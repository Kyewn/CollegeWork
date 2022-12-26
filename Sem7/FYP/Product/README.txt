About the Project:
RojakJelah is a web-based application built with HTML, CSS, JS, C#, and MySQL. It is a Bahasa Rojak Translator developed primarily for users to translate English text to Bahasa Rojak and learn Bahasa Rojak.


Software Required to Run the Project:
1. Visual Studio 2019/2022
2. MySQL v8.0.30 (full MySQL package including MySQL Workbench)


Steps to Run the Project:
1. In MySQL Workbench, import the RojakJelah database dump.
- go to "Server" > "Data Import"
- select "Import from Self-Contained File"
- select the "RojakJelah MySQL Dump" dump file to be imported
- select the "Default Target Schema" you want to import the data into, or specify a new schema to import into by clicking "New"
- go to the "Import Progress" tab, click "Start Import" or "Import Again"

2. Open the RojakJelah project solution file in Visual Studio. Choose one of the following methods:
- directly open the RojakJelah.sln file from your File Explorer
- run Visual Studio, locate and open the RojakJelah.sln file

3. Change the project's database connection string.
- open the Web.config file
- locate the <connectionStrings> tag
- locate the "connectionString" attribute of the <add /> tag
- change the database name to the name of the MySQL database schema you imported the dump into earlier
- change the password to your MySQL connection password
- for example: connectionString="server=localhost;user=root;database=rojakjelah;port=3306;password=abc123"

4. Run the project.


Possible Errors When Running Project:
1. Reference errors or NuGet package errors.
These errors are caused by Visual Studio and there is nothing the project team can do about it as these errors are likely related to incorrect setup of project on your end, please try any of these methods below to resolve the errors:
- Clean and Rebuild solution
- delete "bin" and "obj" folders, then restart Visual Studio

2. Incorrect URL paths.
In some cases, when you click on the "Translator" tab, it might cause a bug in the URL where the path is doubled (e.g. https://localhost:44327/Translator/Translator). This is not intentional and will cause certain issues in the application, it is also caused by Visual Studio or IIS Express and the project team is unable to do anything about it. Please try the following steps to resolve this error:
- go to "Project" > "RojakJelah Properties"
- go to the "Web" tab
- change the number in "Project Url" to something other than the default number, 44327
- for example, change it to https://localhost:44326/
- click "Create Virtual Directory" and save the properties