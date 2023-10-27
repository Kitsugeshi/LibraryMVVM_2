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
        private string? selectedUser;
        public string? SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value!;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        private string? selectedBook;
        public string? SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value!;
                OnPropertyChanged(nameof(SelectedBook));
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
        private ObservableCollection<string> userName = new ObservableCollection<string>();
        public ObservableCollection<string> UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
        }
        private ObservableCollection<string> bookName = new ObservableCollection<string>();
        public ObservableCollection<string> BookName
        {
            get { return bookName; }
            set { bookName = value; OnPropertyChanged(nameof(BookName)); }
        }

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
                UserName.Add(user.Id + " " + user.Name + " " + user.Surname);
            }
            
            foreach (var book in Books)
            {
                BookName.Add(book.Arc + " " + book.Author + " " + book.Age);
            }

            SelectedUser = UserName[0];
            SelectedBook = BookName[0];
        }

        private RelayCommand? borrowBook;
        public RelayCommand BorrowBook
        {
            get
            {
                return borrowBook ??
                  (borrowBook = new RelayCommand(obj =>
                  {
                      foreach (var user in Users!)
                      {
                          if (SelectedUser == (user.Id + " " + user.Name + " " + user.Surname))
                          {
                              foreach (var book in Books!)
                              {
                                  if (SelectedBook == (book.Arc + " " + book.Author + " " + book.Age.ToString()))
                                  {
                                      if (book.Count != 0)
                                      {
                                          user.AddBook(book);
                                          book.Count--;
                                      }
                                  }
                              }
                          }
                      }
                  }));
            }
        }

        public string? FindObj { get; set; }
        private ObservableCollection<User> findUsers = new ObservableCollection<User>();
        private ObservableCollection<Book> findBooks = new ObservableCollection<Book>();
        public ObservableCollection<User> FindUsers
        {
            get
            {
                return findUsers;
            }
            set
            {
                findUsers = value;
            }
        }
        public ObservableCollection<Book> FindBooks
        {
            get
            {
                return findBooks;
            }
            set
            {
                findBooks = value;
            }
        }

        private RelayCommand? find;
        public RelayCommand Find
        {
            get
            {
                return find ??
                  (find = new RelayCommand(obj =>
                  {
                      FindUsers.Clear();
                      FindBooks.Clear();
                      List<string> info = new List<string>();

                      string[] inf = FindObj!.Split(' ');
                      for (int i = 0; i <= inf.Length - 1; i++)
                      {
                          info.Add(inf[i]);
                      }

                      bool isFullName = true;
                      bool isID = true;
                      foreach (var user in Users!)
                      {
                          if (info.Contains(user.Id))
                          {
                              FindUsers.Add(user);
                              isID = false;
                              break;
                          }
                      }
                      if (isID)
                      {
                          foreach (var user in Users)
                          {
                              if (info.Contains(user.Name!) && info.Contains(user.Surname!))
                              {
                                  FindUsers.Add(user);
                                  isFullName = false;
                              }
                              if (isFullName)
                              {
                                  if (info.Contains(user.Name!) || info.Contains(user.Surname!))
                                  {
                                      FindUsers.Add(user);
                                  }
                              }
                          }
                      }

                      bool isIDb = true;
                      foreach (var book in Books!)
                      {
                          if (info.Contains(book.Arc))
                          {
                              FindBooks.Add(book);
                              isID = false;
                              break;
                          }
                      }
                      if (isIDb)
                      {
                          foreach (var book in Books)
                          {
                              if (info.Contains(book.Author!))
                              {
                                  FindBooks.Add(book);
                                  isFullName = false;
                              }
                          }
                      }
                  }));
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
