using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVVM
{
    public class User : INotifyPropertyChanged
    {
        private string? _id;
        private string? _name;
        private string? _surname;
        private ObservableCollection<Book>? _books;
        public string Id
        {
            get { return _id!; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public string Name
        {
            get { return _name!; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string Surname
        {
            get { return _surname!; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }
        public ObservableCollection<Book> Books
        {
            get { return _books!; }
            set { _books = value; OnPropertyChanged("Books"); }
        }
        public User(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Books = new ObservableCollection<Book>();
        }

        public User(string id, string name, string surname, ObservableCollection<Book>? list)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Books = list!;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
