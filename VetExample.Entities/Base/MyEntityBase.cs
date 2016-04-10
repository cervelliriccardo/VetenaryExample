using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VetExample.Entities.Base
{
    /// <summary>
    /// Abstract class inherited from the entity model, it provides events for PropertyChanging and PropertyChanged
    /// </summary>
    public abstract class MyEntityBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        [Category("ClassEvent")]
        [Description("Notify property changed")]
        public event PropertyChangedEventHandler PropertyChanged;

        [Category("ClassEvent")]
        [Description("Notify property changeding")]
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanged([CallerMemberName] String caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        protected void OnPropertyChanging([CallerMemberName] String caller = null)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(caller));
            }
        }       
    }
}

