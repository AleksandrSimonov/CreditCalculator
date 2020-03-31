using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class PaymentsTableData
    {
        public List<Payment> Payments { get; internal set; }
        public double TotalOverpayments { get; internal set; }
    }
}