using System;

namespace A4___Movie_Library_Assignment_LINZ
{
    public class GenreAdder
    {
        NLogger nLogger = new NLogger();
        public static int genreSelect;
        public string genreAdd()
        {

            int count = 0;
            string genreString = "";
            System.Console.WriteLine();
            string[] genreArray = {"Empty","Action", "Adventure", "Animation", "Children's",
                "Comedy", "Crime", "Documentary", "Drama", "Fantasy", "Film-Noir", "Horror",
                "Musical", "Mystery", "Romance", "Sci-Fi", "Thriller", "War", "Western", "(no genres listed)"};

            GenreDisplay genreDisplay = new GenreDisplay();
            genreDisplay.showGenres();
            System.Console.WriteLine("Enter number for a genre to add 1 through 19 you will add them one at a time.");
            System.Console.Write("When your input is complete, then 0 for done, and then the movie is added.\t");
            nLogger.nLog("Adding a genre");
            testInput();
            nLogger.nLog("Added genre number " + genreSelect + " to the movie");
            while (genreSelect > 0 || genreSelect < 20)
            {
                if (count == 0)
                {
                    genreString = genreString + genreArray[genreSelect];
                    count++;
                }
                System.Console.Write(genreArray[genreSelect] + " \n");
                System.Console.Write("\t(Enter number for another genre to add 1 through 19 or 0 when done:  ");
                testInput();
                if (genreSelect < 1 || genreSelect > 20)
                {
                    return genreString;
                }
                else
                {
                    nLogger.nLog("Added genre number " + genreSelect + " to the movie");
                    genreString = genreString + "|" + genreArray[genreSelect];
                }
            }
            return genreString;
        }
        int testInput()
        {
            while (!int.TryParse(Console.ReadLine(), out genreSelect))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                nLogger.nLog("Wrong input " + genreSelect + " given");
            }
            return genreSelect;
        }

    }
}