using MVVMSample.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMSample.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Book _selectedBook;
        public ObservableCollection<Book> Books { get; private set; }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBook)));
            }
        }

        public ICommand AddBookCommand { get; private set; }
        public ICommand RemoveBookCommand { get; private set; }

        public MainWindowViewModel()
        {
            Books = new ObservableCollection<Book>(Book.GetBooks());
            AddBookCommand = new DelegateCommand(AddBook);
            RemoveBookCommand = new DelegateCommand(RemoveBook, CanRemoveBook);
        }

        private void AddBook(object obj)
        {
            Books.Add(new Book() { 
                Author = "Author", 
                Title = "New book name" 
            });
        }

        private void RemoveBook(object obj)
        {
            Books.Remove((Book)obj);
        }

        private bool CanRemoveBook(object obj)
        {
            return obj as Book != null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
