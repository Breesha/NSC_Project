# NSC Project

This README will contain the step by step guide on how to create a linked table Entity Framework with a WPF front end.

This project is a booking system for the NSC (National Sport Centre) on the Isle of Man.

## Step 1 - Repo

1. GitHub create a repo
2. Using PowerShell, locate the folder that you want the project to be saved to
   1. cd <*paste location here*>
3. Clone the repository
   1. Copy the link from GitHub and paste it into PowerShell
   2. git clone <*paste*>



## Step 2 - SQL

1. Open VS without project
2. New SQL Query
3. View > SQL Server Object Explorer
4. Create new database
   1. SQL Server > localdb\MSS... > Databases
   2. Right click databases folder and select add database
   3. Name - here NSC
5. In the new SQL Query start with USE <*database name*>;
6. Create tables and run then add drop tables at the start
7. Add the appropriate data once created and run without problems



## Step 3 - Create Project

1. Visual Studios create new project
2. Console App .NET Core named NSC
3. Check the folder is the correct GitHub repo folder
4. Delete any classes etc so it's just the solution



## Step 4 - Model Layer

1. Right click solution in Solution Explorer
2. Add > New project
3. Select same Console App .NET Core
4. Name NSC_Model
5. Packages
   1. Microsoft.EntityFrameworkCore
   2. Microsoft.EntityFrameworkCore.Sqlserver
   3. Microsoft.EntityFrameworkCore.Tools



## Step 5 - Connection String

1. SQL Server Object Explorer
2. Click NSC Database
3. Properties box - copy whole connection string
4. NSC_Model page - Package manager console
   1. Scaffold-DbContext '<*connection string*>' Microsoft.EntityFrameworkCore.SqlServer



## Step 6 - Business Layer

1. Solution RClick > Add > New project
2. Select same Console App .NET Core
3. Name NSC_Business
4. Dependencies - Model
5. Packages - None
6. RClick NSC_Business > Add > Class
   1. Create CRUDManager but can add more if needed
7. CRUD - public class CRUDM



## Step 7 - Test Layer

1. Solution RClick > Add > New project
2. Select NUnit Project .NET Core
3. Packages - should already be there
   1. NUnit
   2. NUnit3TestAdapter
   3. Microsoft.NET.Test.Sdk
4. Dependencies
   1. Model
   2. Business
5. Already has class called UnitTest1
6. Using ... ;
   1. NSC_Model
   2. NSC_Business
   3. NUnit.Framework
   4. System.Linq
   5. System
7. Change class name but leave namespace
8. Add `CRUDMembers _crudMembers = new CRUDMembers();` underneath class name
9. Create a `[Teardown]`
10. Add another class within the UnitTest1 for the Booking Tests and follow the same steps