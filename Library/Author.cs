using System.Net;

namespace LibraryOOP.Library
{
    class Author
    {
        private string _name { get; set; }
        private string _dob { get; set; }

        public Author(string name, string dob)
        {
            _name = name; _dob = dob;
        }
    }
}