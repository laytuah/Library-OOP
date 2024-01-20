class LibraryUsers
{
    private string _name { get; set; }
    private string _address { get; set; }
    private string _email { get; set; }

    private LibraryUsers(string name, string address, string email)
    {
        _name = name; _address = address; _email = email;
    }

}