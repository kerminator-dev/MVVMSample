using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Model
{
    public class Book : INotifyPropertyChanged
    {
        private string _author = String.Empty;
        private string _title = String.Empty;

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Author)));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public static List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book() { Title = "Лев Толстой", Author = "Война и мир" },
                new Book() { Title = "Михаил Булгаков", Author = "Мастер и Маргарита" },
                new Book() { Title = "Стивен Кинг", Author = "Оно" }
            };
        }
    }
}
