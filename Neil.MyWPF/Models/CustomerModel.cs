using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neil.MyWPF.Models
{
    class CustomerModel
    {
        public int Amount { get; set; } = 4000;

        public string CustomerName { get; set; }

        public string Married { get; set; }

        /// <summary>
        /// 税金=20(金额>2000)
        /// 税金=10(金额<=2000)
        /// </summary>
        public int Tax { get; set; }

        public void CaculateTax()
        {
            if (Amount > 2000)
                Tax = 20;
            else if (Amount > 1000)
                Tax = 10;
            else
                Tax = 5;
        }

        public bool IsValid() => Amount <= 0 ? false : true;
    }
}
