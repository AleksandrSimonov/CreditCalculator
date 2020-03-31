using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calculator.Credit
{
    public class CreditPayments
    {
        private double totalOverpayments = 0.0;
        public List<Models.Payment> Payments { get; }
        public double TotalOverpayments
        {
            get
            {
                return Math.Round(totalOverpayments, 2);
            }
            set
            {
                totalOverpayments = value;
            }
        }
        private void AddPayment(int numberPay, DateTime datePay, double payByBody, double payByPercent, double balance)
        {
            var payment = new Payment
            {
                NumberPay = numberPay,
                DatePay = datePay.ToShortDateString(),
                PayByBody = Math.Round(payByBody, 2),
                PayByPercent = Math.Round(payByPercent, 2),
                Balance = Math.Round(balance, 2)
            };

            TotalOverpayments += payment.PayByPercent;
            Payments.Add(payment);
        }
        private double ConvertToDouble(string numberStr)
        {
            numberStr = System.Text.RegularExpressions.Regex.Replace(numberStr, @"\s+", "");
            numberStr = System.Text.RegularExpressions.Regex.Replace(numberStr, @",", ".");

            bool result = double.TryParse(numberStr, NumberStyles.Float, new CultureInfo("en-us"), out double number);
            if (!result)
            {
                throw new ArgumentException("Поле заполнено неверно!");
            }
            else
            {
                return number;
            }
        }
        private int ConvertToInteger(string numberStr)
        {
            //numberStr = System.Text.RegularExpressions.Regex.Replace(numberStr, @"\s+", "");
            bool result = int.TryParse(numberStr, NumberStyles.Integer, new CultureInfo("en-us"), out int number);
            if (!result)
            {
                throw new ArgumentException("Поле заполнено неверно!");
            }
            else
            {
                return number;
            }
        }
        public CreditPayments(CalculateData data)
        {
            try
            {
                double creditSumm = ConvertToDouble(data.CreditSumm);
                if (creditSumm<=0)
                {
                    throw new ArgumentException("Поле заполнено неверно!");
                }

                int loanTerm = ConvertToInteger(data.LoanTerm);
                if (loanTerm <= 0)
                {
                    throw new ArgumentException("Поле заполнено неверно!");
                }
                double rate = ConvertToDouble(data.Rate);

                if(rate>100|| rate < 0)
                {
                    throw new ArgumentException("Поле заполнено неверно!");
                }

                TotalOverpayments = 0;
                Payments = new List<Payment>();
                Calculate(creditSumm, loanTerm, rate);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Поля заполнены неверно!");
            }
        }
        private void Calculate(double creditSumm, double loanTerm, double rate)
        {
            double rateInPeriod = rate / 1200.0;
            double temp = Math.Pow(1 + rateInPeriod, loanTerm);
            double K = rateInPeriod * temp / (temp - 1);

            double singlePayment = K * creditSumm;
            double balance = creditSumm;

            for (int j = 1; balance > 0; j++)
            {
                double payByPercent = balance * rateInPeriod;
                double payByBody = singlePayment - payByPercent;
                balance -= payByBody;
                this.AddPayment(j, DateTime.Now.AddMonths(j), payByBody, payByPercent, balance);
            }
        }
        public PaymentsTableData GetTableData()
        {
            var tableTada = new PaymentsTableData()
            {
                Payments = this.Payments,
                TotalOverpayments = this.TotalOverpayments
            };
            return tableTada;
        }
    }
}