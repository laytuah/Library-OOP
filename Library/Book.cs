using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace LibraryOOP.Library
{
    class Book
    {
        private Guid _uniqueID { get; set; }
        private string _title { get; set; }
        private Author _author { get; set; }
        private string _category { get; set; }
        private bool _isAvailable {get; set;}
        private DateTime _borrowDate {get; set;}
        private DateTime _returnDate {get; set;}
        private DateTime _expectedAvailabilityDate {get; set;}
        public Book(string title, Author author, string category)
        {
            _uniqueID = Guid.NewGuid(); _title = title; _author = author; _category = category; _isAvailable = true;
        }
        public string Title(){
            return _title;
        }
        public bool IsAvailable(){
            return _isAvailable;
        }

        public void GiveBookOut(int numberOfDaysToBorrow){
            _isAvailable = false;
            _borrowDate = DateTime.UtcNow;
            _expectedAvailabilityDate = DateTime.UtcNow.AddDays(numberOfDaysToBorrow);
        }

        public void ReturnBookToShelf(){
         _isAvailable = true;
        _returnDate = DateTime.UtcNow;
        }

        public Guid uniqueID(){
            return _uniqueID;
        }

        public DateTime ExpectedAvailabilityDate(){
            return _expectedAvailabilityDate;
        }
    }
};