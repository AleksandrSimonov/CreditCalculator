using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class Payment
    {
        public int NumberPay { get; internal set; }
        public string DatePay { get; internal set; }
        public double PayByBody { get; internal set; }
        public double PayByPercent { get; internal set; }
        public double Balance { get; internal set; }
    }
}