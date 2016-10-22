﻿using FootballMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMaster.ViewModel
{
    class MyViewModel : INotifyPropertyChanged
    {
        MyModel model;

        public MyViewModel(MyModel model)
        {
            this.model = model;
        }

        #region event triggered
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion
    }
}
