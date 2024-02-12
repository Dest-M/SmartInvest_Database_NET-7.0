using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;



namespace SmartInvest_DataBase.Models
{
    [PrimaryKey(nameof(id))]
    public class Customer
    {

        public int id { get; set; }
        public string FirstName;
        public string LastName;
        public string Email;



    }
}
