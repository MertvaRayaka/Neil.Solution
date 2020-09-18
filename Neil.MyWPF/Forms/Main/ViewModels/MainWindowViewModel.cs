using Neil.MyWPF.Commands;
using Neil.MyWPF.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Neil.MyWPF
{
    //转换逻辑在ViewModel中实现
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CustomerModel customerObj = new CustomerModel();
        public event PropertyChangedEventHandler PropertyChanged;

        #region 属性-都以UI的命名方式约定
        public ICommand btnClick => new ButtonCommand(Caculate, customerObj.IsValid); //command 对象是通过以“ICommand”接口的形式暴露出来，这样才可以被 XAML 所使用

        public string TxtCustomerName
        {
            get { return customerObj.CustomerName; }
            set { customerObj.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return customerObj.Amount.ToString(); }
            set { customerObj.Amount = Convert.ToInt32(value); }
        }

        public string LblAmountColor
        {
            get
            {
                if (customerObj.Amount > 2000)
                    return "Blue";
                if (customerObj.Amount > 1500)
                    return "Red";
                return "Yellow";
            }
        }

        public bool IsMarried => customerObj.Married == "Married" ? true : false;

        public int TxtTax
        {
            get { return customerObj.Tax; }
        }
        #endregion

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Caculate()
        {
            customerObj.CaculateTax();
            OnPropertyChanged("TxtTax");
        }
    }
}
