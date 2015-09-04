using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AmbifluxAdmin.ViewModel
{
  public class ViewModelBase : INotifyPropertyChanged
  {
  public event PropertyChangedEventHandler PropertyChanged;

  protected virtual void RaisePropertyChanged(string propertyName){
     // Best practice.  Take a copy of the event handler before checking for null.
     // In this way if the PropertyChanged property is somehow set to null after the null check we
     // won't cause an exception.
     var handler = PropertyChanged;
     if(handler != null){
       handler(this, new PropertyChangedEventArgs(propertyName));
     }
  }
}

}
