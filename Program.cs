using System.Transactions;
using LibraryOOP.Library;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();
        
        while(true)
        {  
            OptionSelection();

            var optionSelectedInString = Console.ReadLine();
            var canParseOption = Int32.TryParse(optionSelectedInString, out var optionSelectedParsed);

            if(!canParseOption ){
                DisplayError("invalid input format, please enter 1 to borrow a book and 2 to return a borrowed book.\n");
            }else{
                    if(optionSelectedParsed == 1)
                    {
                        Console.WriteLine("Please enter the title of the book you want to borrow");
                        var titleOfBookToBorrow = Console.ReadLine();
                        Console.WriteLine("How many days are you keeping this book for?");
                        var numberOfDaysToBorrowString = Console.ReadLine();
                        var canParseNumberOfDays = Int32.TryParse(numberOfDaysToBorrowString, out var numberOfDaysToBorrowParsed);
                            if(!canParseNumberOfDays){
                                DisplayError("Error!!! Please select the number between 1 and 30");
                                return;
                            }
                        var bookAvailable = library.CheckBookAvalability(titleOfBookToBorrow);
                        if(!bookAvailable)
                        {
                            DisplayError($"Sorry, the book you have requested is currently unavailable, it will be available on {library.ExpectedbookavailabilityDate(titleOfBookToBorrow)}");
                        }else{
                                var bookBorrowed = library.BorrowBook(titleOfBookToBorrow,numberOfDaysToBorrowParsed);
                            if(bookBorrowed){
                                DisplaySuccess($"Congratulations, you can now have the book for {numberOfDaysToBorrowParsed} days");
                                Console.WriteLine($"The UniqueID of the borrowed book is:  {library.uniqueIDOfBorrowedBook(titleOfBookToBorrow)}");
                            }else{
                                DisplayError("System Error!!!");
                            }
                        }
                        
                    }else if(optionSelectedParsed == 2){
                            Console.WriteLine("Please enter the uniqueID of the book you want to return");
                            var uniqueIDOfBookToReturn = Console.ReadLine();
                            var bookAvailable = library.CheckBookAvalability(uniqueIDOfBookToReturn);
                            if(!bookAvailable){
                            var bookReturned = library.ReturnBook(uniqueIDOfBookToReturn);
                                if(bookReturned){
                                DisplaySuccess("Congratulations, you have succesfully returned the book");
                                }else{
                                DisplayError("System Error!!!");
                                }
                            }  
                        }else{
                            DisplayError("Invalid selection, please enter 1 to borrow a book and 2 to return a borrowed book");
                        }
                }
        } 
    }

    static void OptionSelection(string message = ""){
        Console.WriteLine("WELCOME TO OUR LIBRARY.\n");
        Console.WriteLine("Please select an option.\n");
        Console.WriteLine("1. To borrow a book.\n");
        Console.WriteLine("2. To return a book.\n");
    }

    static void DisplaySuccess(string message){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void DisplayError(string message){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

