

namespace A4___Movie_Library_Assignment_LINZ
{
    class ActionSelected : IMenus, IActionSelected
    {
        public void selectAction()
        {
            NLogger nLogger = new NLogger();
            string select = "";
            System.Console.WriteLine("\n   ~~~~Movie Library Database~~~~ \n");
        andAgain:
            System.Console.Write("Enter: \n1 List movies \n2 Add new Movie \n3 Exit\t\t\t");
            select = System.Console.ReadLine();
            switch (select)
            {
                case "1":
                case "l": // the letter is more intuitive
                    nLogger.nLog("LIST at Select Action ");
                    ListMovie listMovie = new ListMovie();
                    listMovie.listMovieProcess();
                    break;
                case "2":
                case "a":
                    nLogger.nLog("ADD at Select Action ");
                    AddMovie addMovie = new AddMovie();
                    addMovie.addMovieProcess();
                    break;
                case "3":
                case "e":
                    nLogger.nLog("EXIT at Select Action ");
                    Exit exit = new Exit();
                    exit.exitTest();
                    break;
                default:
                    System.Console.WriteLine("Not a valid input, Enter 1 2 or 3");
                    nLogger.nLog("Wrong input at Select Action ");
                    goto andAgain;

            }


        }

    }
}