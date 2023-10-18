using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVVM
{
    public class Book : INotifyPropertyChanged
    {
        private string? _arc;
        private string? _author;
        private string? _age;
        private int _count;
        public string Arc
        {
            get { return _arc!; }
            set { _arc = value; OnPropertyChanged("Arc"); }
        }
        public string Author
        {
            get { return _author!; }
            set { _author = value; OnPropertyChanged("Author"); }
        }    
        public string Age
        {
            get { return _age!; }
            set { _age = value; OnPropertyChanged("Age"); }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; OnPropertyChanged("Count"); }
        }

        public Book(string arc, string author, int count, DateOnly date)
        {
            Arc = arc;
            Author = author;
            Age = date.ToString("dd.MM.yy");
            Count = count;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
