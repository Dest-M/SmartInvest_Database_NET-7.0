using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInvest_DataBase.Models
{
    [PrimaryKey (nameof(id))]
    public class Employee
    {
       
        public int id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Position;
        public double Salary;
    }
}
