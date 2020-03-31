using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class CalculateData
    {
        [Required]
        public string CreditSumm { get; set; }
        [Required]
        public string LoanTerm { get; set; }
        [Required]
        public string Rate { get; set; }
    }
}