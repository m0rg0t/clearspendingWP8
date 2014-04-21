﻿
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;

namespace ClearSpendingSearchWP8.Pages.Commands
{
    public class SendAnEmailCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.To = "m0rg0t.Anton@gmail.com";
            emailTask.Show();
        }
    }
}
