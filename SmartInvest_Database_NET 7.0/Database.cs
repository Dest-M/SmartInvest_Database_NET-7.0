using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using SmartInvest_DataBase.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SmartInvest_DataBase
{
    internal class Database : DbContext
    {
        string CustomersGet = @"SELECT * FROM Customers;";
        string EmployeesGet = @"SELECT * FROM Employees;";
        string TransactionsGet = @"SELECT * FROM Transactions;";
        IServiceProvider ServiceProvider { get; set; }


        public DbSet<Customer> _customerList => Set<Customer>();
        public DbSet<Employee> _employeeList => Set<Employee>();
        public DbSet<Transaction> _transactionList => Set<Transaction>();
        int? customerCurrentId = 1;
        int? employeeCurrentId = 1;
        int? transactionCurrentId = 1;
        public Database() => Database.EnsureCreated();


        public Database(string conStr, DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(conStr);
            using SqliteConnection connection = new SqliteConnection(conStr);
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = CustomersGet;

                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.id = Convert.ToInt32(reader["id"]);
                    customer.FirstName = reader["FirstName"].ToString();
                    customer.LastName = reader["LastName"].ToString();
                    customer.Email = reader["Email"].ToString();

                    _customerList.Add(customer);

                }
                reader.Close();

                command.CommandText = EmployeesGet;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.id = Convert.ToInt32(reader["id"]);
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.Email = reader["Email"].ToString();
                    employee.Position = reader["Position"].ToString();
                    employee.Salary = Convert.ToDouble(reader["Salary"]);

                    _employeeList.Add(employee);

                }

                reader.Close();


                command.CommandText = TransactionsGet;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Transaction transaction = new Transaction();
                    transaction.id = Convert.ToInt32(reader["id"]);
                    transaction.EmployeeInChargeID = Convert.ToInt32(reader["EmployeeInChargeID"]);
                    transaction.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    transaction.Date = Convert.ToDateTime(reader["datetime"]);
                    transaction.Amount = Convert.ToDouble(reader["Amount"]);

                    _transactionList.Add(transaction);

                }
                reader.Close();

            }
            try
            {
                customerCurrentId = _customerList.Select(x => x.id).Max();
                employeeCurrentId = _employeeList.Select(x => x.id).Max();
                customerCurrentId = _transactionList.Select(x => x.id).Max();
            }
            catch
            {
                customerCurrentId = 0;
                employeeCurrentId = 0;
                transactionCurrentId = 0;
            }
        }

        public int getCustomerId()
        {
            customerCurrentId++;
            return Convert.ToInt32(customerCurrentId);
        }
        public void addCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }


        public int getEmployeeId()
        {
            employeeCurrentId++;
            return Convert.ToInt32(employeeCurrentId);
        }

        public void addEmployee(Employee employee)
        {
            _employeeList.Add(employee);
        }


        public int getTransactionId()
        {
            transactionCurrentId++;
            return Convert.ToInt32(transactionCurrentId);
        }
        public void addTransaction(Transaction transaction)
        {
            _transactionList.Add(transaction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=db.sqlite");
            }

        }
    }

}
