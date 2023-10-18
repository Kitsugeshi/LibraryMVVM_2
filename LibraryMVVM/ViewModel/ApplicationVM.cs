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
    public class ApplicationVM : INotifyPropertyChanged
    {
        public ObservableCollection<Book>? Books { get; set; }
        public ObservableCollection<User>? Users { get; set; }
        public ObservableCollection<Book>? SelectedBooks { get; set; }
        private User? choouseUser;
        public User? ChoouseUser {
            get
            {
                return choouseUser; 
            }
            set
            {
                choouseUser = value!;
                OnPropertyChanged(nameof(ChoouseUser));
            }
        }
        private ObservableCollection<Book>? listBook;
        public ObservableCollection<Book>? ListBook
        {
            get
            {
                return listBook;
            }
            set
            {
                listBook = value!;
            }
        }
        public ObservableCollection<string> userName = new ObservableCollection<string>();


        public ApplicationVM()
        {
            Books = new ObservableCollection<Book>
            {
                new Book("0b", "Dostoevsky", 1, new DateOnly(2004,5,7)),
                new Book("1b", "Stoker", 3, new DateOnly(2003,6,27)),
                new Book("2b", "Lovecraft", 1, new DateOnly(2002,5,17)),
                new Book("3b", "Pushkin", 0, new DateOnly(1999,2,17))
            };


            Users = new ObservableCollection<User>
            {
                new User("0p","Ivan", "Ivanov", new ObservableCollection<Book>{ Books[0] }),
                new User("1p","Semen", "Ken"),
                new User("2p","Semen", "Kenn"),
                new User("3p","Semen", "Ken"),
                new User("4p","Vlad", "Drakula", new ObservableCollection<Book>{ Books[1], Books[2] })
            };

            foreach (var user in Users)
            {
                userName.Add(user.Id + " " + user.Name + " " + user.Surname);
            }
        }





    public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

//    books = new List<Book>
//            {
//                new Book("0b", "Dostoevsky", 1, new DateOnly(2004,5,7)),
//                new Book("1b", "Stoker", 3, new DateOnly(2003,6,27)),
//                new Book("2b", "Lovecraft", 1, new DateOnly(2002,5,17)),
//                new Book("3b", "Pushkin", 0, new DateOnly(1999,2,17))
//            };

//ListViewOfBooks.ItemsSource = books;
//users = new List<User>
//{
//                new User("0p","Ivan", "Ivanov", new List<Book>{ books![0] }),
//                new User("1p","Semen", "Ken"),
//                new User("2p","Semen", "Kenn"),
//    new User("3p","Semen", "Ken"),
//    new User("4p","Vlad", "Drakula", new List<Book>{ books![1], books![2] })
//};

//ListViewOfUsers.ItemsSource = users;

//List<string> userName = new List<string>();
//foreach (var item in users)
//{
//    userName.Add(item.Id + " " + item.Name + " " + item.Surname);
//}
//ComboBoxUsers.ItemsSource = userName;

//List<string> bookName = new List<string>();
//foreach (var item in books)
//{
//    bookName.Add(item.Arc + " " + item.Author + " " + item.Age.ToString());
//}
//ComboBoxBooks.ItemsSource = bookName;
//        }

//        private void ListViewOfUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
//{
//    User? _user = ListViewOfUsers.SelectedItem as User;

//    if (_user != null)
//    {
//        ListBoxBook.ItemsSource = _user.Books;
//    }
//}

//private void BorrowBook(object sender, RoutedEventArgs e)
//{
//    string? _user = ComboBoxUsers.SelectedItem as string;
//    string? _book = ComboBoxBooks.SelectedItem as string;
//    foreach (var user in users)
//    {
//        if (_user == (user.Id + " " + user.Name + " " + user.Surname))
//        {
//            foreach (var book in books)
//            {
//                if (_book == (book.Arc + " " + book.Author + " " + book.Age.ToString()))
//                {
//                    if (book.Count != 0)
//                    {
//                        user.AddBook(book);
//                        book.Count--;
//                        ListBoxBook.Items.Refresh();
//                        ListViewOfBooks.Items.Refresh();
//                    }
//                }
//            }
//        }
//    }
//}

//private void Find(object sender, RoutedEventArgs e)
//{
//    string findObj = FindTextBox.Text;
//    List<string> info = new List<string>();

//    List<User> findUsers = new List<User>();
//    List<Book> findBooks = new List<Book>();

//    string[] inf = findObj.Split(' ');
//    for (int i = 0; i <= inf.Length - 1; i++)
//    {
//        info.Add(inf[i]);
//    }

//    bool isFullName = true;
//    bool isID = true;
//    foreach (var user in users)
//    {
//        if (info.Contains(user.Id))
//        {
//            findUsers.Add(user);
//            isID = false;
//            break;
//        }
//    }
//    if (isID)
//    {
//        foreach (var user in users)
//        {
//            if (info.Contains(user.Name!) && info.Contains(user.Surname!))
//            {
//                findUsers.Add(user);
//                isFullName = false;
//            }
//            if (isFullName)
//            {
//                if (info.Contains(user.Name!) || info.Contains(user.Surname!))
//                {
//                    findUsers.Add(user);
//                }
//            }
//        }
//    }

//    FindResultUsers.ItemsSource = findUsers;

//    bool isIDb = true;
//    foreach (var book in books)
//    {
//        if (info.Contains(book.Arc))
//        {
//            findBooks.Add(book);
//            isID = false;
//            break;
//        }
//    }
//    if (isIDb)
//    {
//        foreach (var book in books)
//        {
//            if (info.Contains(book.Author!))
//            {
//                findBooks.Add(book);
//                isFullName = false;
//            }
//        }
//    }

//    FindResultBooks.ItemsSource = findBooks;
//}