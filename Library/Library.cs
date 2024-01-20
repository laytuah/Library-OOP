namespace LibraryOOP.Library
{
    class Library
    {
        private ICollection<Book> _books;
        public Library()
        {
            _books = new List<Book>();
            _books.Add(new Book("Title 1",new Author("Author 1","01/01/2000"),"Category 1"));
            _books.Add(new Book("Title 2",new Author("Author 2","02/02/2000"),"Category 2"));
            _books.Add(new Book("Title 3",new Author("Author 3","03/03/2000"),"Category 3"));
            _books.Add(new Book("Title 4",new Author("Author 4","04/04/2000"),"Category 4"));
            _books.Add(new Book("Title 5",new Author("Author 5","05/05/2000"),"Category 5"));
            _books.Add(new Book("Title 6",new Author("Author 6","06/06/2000"),"Category 6"));
            _books.Add(new Book("Title 7",new Author("Author 7","07/07/2000"),"Category 7"));
            _books.Add(new Book("Title 8",new Author("Author 8","08/08/2000"),"Category 8"));
            _books.Add(new Book("Title 9",new Author("Author 9","09/09/2000"),"Category 9"));
            _books.Add(new Book("Title 10",new Author("Author 10","10/10/2000"),"Category 10"));
        }

        public void AddNewBook(Book bookToAdd){
            _books.Add(bookToAdd);
        }

        public bool CheckBookAvalability(string title){
            Book bookToBorrow = _books.FirstOrDefault(b => b.Title().ToLower() == title.ToLower() && b.IsAvailable());
            if (bookToBorrow is null){
                return false;
            }
            return true;
        }

        public bool BorrowBook( string title){
            Book bookToBorrow = _books.FirstOrDefault(b => b.Title().ToLower() == title.ToLower() && b.IsAvailable());
            if(bookToBorrow is not null){
                bookToBorrow.GiveBookOut();
                return true;
            }
            return false;
        }

        public bool ReturnBook(string uniqueID){
            Book bookToReturn = _books.FirstOrDefault(b => b.uniqueID().ToString() == uniqueID);

            if(bookToReturn is not null){
                bookToReturn.ReturnBookToShelf();
            }
            return false;
        }
    }
}