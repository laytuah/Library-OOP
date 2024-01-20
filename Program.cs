using System.Transactions;
using LibraryOOP.Library;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();
        
        while(true){  
        OptionSelection();

        var optionSelectedInString = Console.ReadLine();
        var canParseOption = Int32.TryParse(optionSelectedInString, out var optionSelectedParsed);

        if(!canParseOption ){
            OptionSelection("invalid selection, Please enter a valid one.\n");
        }else{
            if(optionSelectedParsed == 1){
                Console.WriteLine("Please enter the title of the book you want to borrow");
                var titleOfBookToBorrow = Console.ReadLine();
                var bookAvailable = library.CheckBookAvalability(titleOfBookToBorrow);
                if(!bookAvailable){
                DisplayError("Sorry, the book you have requested is currently unavailable");
                return;
                }
                var bookBorrowed = library.BorrowBook(titleOfBookToBorrow);
                if(bookBorrowed){
                    DisplaySuccess("Congratulations, you can now have the book for the next 1 week");
                }else{
                    DisplayError("System Error!!!");
                }
            }else if(optionSelectedParsed == 2){
                //Console.WriteLine("Please enter the uniqueID of the book you want to return");
                //var uniqueIDOfReturn = Console.ReadLine();
                Console.WriteLine("Please enter the titlt of the book you want to return");
                var titleOfBookToReturn = Console.ReadLine();
                var bookAvailable = library.CheckBookAvalability(titleOfBookToReturn);
                if(!bookAvailable){
                    var bookReturned = library.ReturnBook(titleOfBookToReturn);
                    if(bookReturned){
                    DisplaySuccess("Congratulations, you have succesfully returned the book");
                    }else{
                    DisplayError("System Error!!!");
                    }
                }
                DisplayError("Sorry, the book you are trying to return is already on shelve");
                return;  
            }
        }
        } 
         
    }

    static void OptionSelection(string message = ""){
        if(!String.IsNullOrEmpty(message)){
            Console.Clear();
            Console.WriteLine(message);
        }
        Console.WriteLine("WECOME TO OUR LIBRARY.\n");
        Console.WriteLine("Please select an option.\n");
        Console.WriteLine("1. To borrow a book.\n");
        Console.WriteLine("2. To return a book.\n");
    }

    static void DisplaySuccess(string message){
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void DisplayError(string message){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

