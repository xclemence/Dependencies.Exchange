﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dependencies.Exchange.Graph.Fwk
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        protected ObservableObject() { }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (object.Equals(field, value))
                return false;

            field = value;
            RaisePropertyChanged(propertyName);

            return true;
        }
    }
}
