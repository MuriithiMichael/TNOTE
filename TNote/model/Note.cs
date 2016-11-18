using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TNote.model
{
    public class Note : INotifyPropertyChanged
    {
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                this.SetProperty(ref this._content, value);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                this.SetProperty(ref this._title, value);
            }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                this.SetProperty(ref this._category, value);
            }
        }
        private string _latitude;

        public string Latitude
        {
            get { return _latitude; }
            set
            {
                this.SetProperty(ref this._latitude, value);
            }
        }
        private string _longitude;
        public string Longitude
        {
            get { return _longitude; }
            set
            {
                this.SetProperty(ref this._longitude, value);
            }
        }
        private string _user;
        public string User
        {
            get { return _user; }
            set
            {
                this.SetProperty(ref this._user, value);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
