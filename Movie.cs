using System;
using System.IO;


public class Program
{
    public static void Main(string[] args)
    {
        Movie[] objMovies = new Movie[1];
       

        int choice;
        //menu
        do
        {
            Console.WriteLine("1. loading data");
            Console.WriteLine("2. Display All Movies");
            Console.WriteLine("3. add a movie");
            Console.WriteLine("4. Exit");
            Console.Write("make a choice from 1-4: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    loadData(ref objMovies);
                    break;
                case 2:
                    displayAllMovies(objMovies);
                    break;
                case 3:
                    addMovie(ref objMovies);
                    break;
                default:

                    break;
            }

            Console.Clear();

        } while (choice != 4);
        
    }
        
     public static void loadData(ref Movie[] objMovies)
    {
        StreamReader reader = new StreamReader("Movies.txt");
        int size = Convert.ToInt32(reader.ReadLine());
        objMovies = new Movie[size];


        for (int index = 0; index < size; index++)
        {
            objMovies[index] = new Movie();
            objMovies[index].Title = reader.ReadLine();
            objMovies[index].Director = reader.ReadLine();
            objMovies[index].Year = Convert.ToInt32(reader.ReadLine());
        }

        reader.Close();

        Console.WriteLine("Data loaded: press any key to contunue");
        Console.ReadKey();
    }   
        public static void displayAllMovies(Movie[] objMovies)
    {
        Console.Clear();

        for (int index = 0; index < objMovies.Length; index++)
        {
          objMovies[index].DisplayInformation();

           
        }
        Console.WriteLine("press any key to contunue");
        Console.ReadKey();
    }
        public static void addMovie(ref Movie[] objMovies)
    {
        StreamWriter writer = new StreamWriter("Movies.txt");
        writer.WriteLine(objMovies.Length + 1);
        
        
        //create new object
        Movie temp = new Movie();
        
        
        //collect data from user
        Console.Write("Enter Title: ");
        temp.Title = Console.ReadLine();

        Console.Write("Enter Name Of Director: ");
        temp.Director = Console.ReadLine();

        Console.Write("Enter year: ");
        temp.Year = Convert.ToInt32(Console.ReadLine());

        //write the new data to text file
        writer.WriteLine(temp.Title);
        writer.WriteLine(temp.Director);
        writer.WriteLine(temp.Year);

        //put old movies into text file

        for(int index = 0; index < objMovies.Length; index++)
        {
            writer.WriteLine(objMovies[index].Title);
            writer.WriteLine(objMovies[index].Director);
            writer.WriteLine(objMovies[index].Year);
        }

        //close the file
        writer.Close();

        //update our array
        loadData(ref objMovies); 
    }
        }

