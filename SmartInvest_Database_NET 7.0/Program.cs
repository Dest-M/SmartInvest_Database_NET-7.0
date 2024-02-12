using System.Data;
using System.Data.Common;
using System.Diagnostics.Contracts;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SmartInvest_DataBase;
using static System.Net.WebRequestMethods;


// Company Name:        SmartInvest
//
//Table 1:              Customers
//Table 2:              Employees
//Table 3:              Transactions


string conStr = @"Data Source = SmartInvestSQL.sql";
string filename = @"SmartInvestSQL.sql";
string CustomersCreate = @"CREATE TABLE Customers(
                       id INTEGER PRIMARY KEY AUTOINCREMENT,
                       FirstName text,
                       LastName text,
                       Email text
                           );";
string EmployeeCreate = @"CREATE TABLE Employees(
                       id INTEGER PRIMARY KEY AUTOINCREMENT,
                       FirstName text,
                       LastName text,
                       Email text,
                       Position text,
                       Salary double
                           );";
string TransactionsCreate = @"CREATE TABLE Transactions(
                       id INTEGER PRIMARY KEY AUTOINCREMENT,
                       EmployeeInChargeID int,
                       CustomerID int,
                        Date datetime,
                        Amount double,
                       FOREIGN KEY(EmployeeInChargeID) REFERENCES Employees(id),
                       FOREIGN KEY(CustomerID) REFERENCES Customers(id)
                           );";


DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();


if (!System.IO.File.Exists(filename))
{
    System.IO.File.Create(filename).Close();


    using SqliteConnection connection = new SqliteConnection(conStr);

    connection.Open();
    using (var command = connection.CreateCommand())
    {
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = CustomersCreate;
        command.ExecuteNonQuery();
        command.CommandText = EmployeeCreate;
        command.ExecuteNonQuery();
        command.CommandText = TransactionsCreate;
        command.ExecuteNonQuery();



        connection.Close();
    }

};
Database database = new Database(conStr, dbContextOptionsBuilder);
Fill fill = new Fill();
bool endflag = false;
Console.WriteLine("Welcome");
while (!endflag)
{
    Console.WriteLine("Avaliable tables:\n1  Customer\n2  Employee\n3  Transaction\n---------------\nAvaliable actions:\n1  - Enter a new row into a table\n3 - Exit Program");
    int choice = fill.dumbChoiceCheck(3);
    switch (choice)
    {
        case 1:
            enterTablechoice();
            break;
        case 2:
            enterTablechoice();
            break;
        case 3:
            endflag = true;
            break;
        default:
            break;

    }



}

void enterTablechoice()
{
    Console.WriteLine("Avaliable tables:\n1  Customer\n2  Employee\n3  Transaction");
    int choice = fill.dumbChoiceCheck(3);
    switch (choice)
    {
        case 1:
            fill.fillCustomer(database);
            break;
        case 2:
            fill.fillEmployee(database);
            break;
        case 3:
            fill.fillTransaction(database);
            break;
        default:
            break;

    }
}


