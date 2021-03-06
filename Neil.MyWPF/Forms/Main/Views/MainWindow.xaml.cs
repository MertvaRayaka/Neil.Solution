﻿using Neil.MyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Neil.MyWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(async delegate
            {
                while (true)
                {
                    await Task.Delay(500);
                    Dispatcher.Invoke(delegate { lblTime.Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); });
                }
            });
        }
    }
}
