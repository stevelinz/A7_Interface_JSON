using System;

namespace A4___Movie_Library_Assignment_LINZ
{
    public class GenreAdder
    {
      NLogger nLogger = new NLogger();
       public  string genreAdd()
            {
                int genreSelect = 0;
                int count = 0;
                string genreString = "";
                string[] genreArray = {"Empty","Action", "Adventure", "Animation", "Children's",
                "Comedy", "Crime", "Documentary", "Drama", "Fantasy", "Film-Noir", "Horror",
                "Musical", "Mystery", "Romance", "Sci-Fi", "Thriller", "War", "Western", "(no genres listed)"};

                GenreDisplay genreDisplay = new GenreDisplay();
                genreDisplay.showGenres();
                System.Console.WriteLine("Enter number for a genre to add 1 through 19 you will add them one at a time.");
                System.Console.WriteLine("When your input is complete, then 0 for done, and then the movie is added.\n\n");
                nLogger.nLog("Adding a genre");
                genreSelect = Convert.ToInt32(Console.ReadLine());

                while (genreSelect > 0 || genreSelect < 20)
                {
                    if (count == 0)
                    {
                        genreString = genreString + genreArray[genreSelect];
                        count++;
                    }
                    System.Console.Write(genreArray[genreSelect] + " \n\n");
                    System.Console.WriteLine("Enter number for a genre to add 1 through 19, ");
                    System.Console.WriteLine("or 0 when  done and then the movie is added.");

                    genreSelect = Convert.ToInt32(Console.ReadLine());
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
       
    }
}