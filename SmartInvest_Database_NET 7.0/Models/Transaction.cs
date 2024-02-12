using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInvest_DataBase.Models
{
    [PrimaryKey(nameof(id))]
    internal class Transaction
    {

        public int id;
        public int? EmployeeInChargeID;
        public int? CustomerID;
        public DateTime Date;
        public double Amount;
        
    }
}
