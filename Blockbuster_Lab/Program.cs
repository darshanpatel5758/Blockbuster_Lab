﻿using System;
using System.Collections.Generic;

namespace Blockbuster_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockbuster blockbuster = new Blockbuster();

            blockbuster.Movies.Add(new DVD("Spider-Man: Far From Home", Genre.Drama, 110));
            blockbuster.Movies.Add(new DVD("Avengers: Endgame", Genre.Comedy, 112));
            blockbuster.Movies.Add(new DVD("Captain Marvel", Genre.Horror, 90));
            blockbuster.Movies.Add(new VHS("Spider-Man: Homecoming", Genre.Romance, 160));
            blockbuster.Movies.Add(new VHS("Avengers: Infinity War", Genre.Action, 155));
            blockbuster.Movies.Add(new VHS("Black Panther", Genre.Romance, 90));


            foreach (Movie movie in blockbuster.Movies)
            {
                movie.Scenes.Add("Scene 1");
                movie.Scenes.Add("Scene 2");
                movie.Scenes.Add("Scene 3");
                movie.Scenes.Add("Scene 4");
            }

           

            

        }
    }

    public abstract class Movie    
    {
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int RunTime { get; set; }

        public List<string> Scenes = new List<string>();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Title} + {Category} + {RunTime}");
        }

        public void PrintScenes()
        {
            int i = 1;

            foreach (string Scence in Scenes)
            {
                Console.WriteLine($"[{i}] {Scence}");
                i++;
            }
        }

        public abstract void Play();
        public abstract void PlayWholeMovie();

    }

    public class VHS : Movie 
    {
        public VHS(string title, Genre category, int runtime)
        {
            Title = title;
            Category = category;
            RunTime = runtime;
        }
        public int CurrentTime = 1;

        public override void Play()
        {
            Console.WriteLine($"{Title} ---- {Scenes[CurrentTime]}");
            CurrentTime++;
        }

        public void Rewind()
        {
            CurrentTime = 1;
        }

        public override void PlayWholeMovie()
        {
            foreach (string scence in Scenes)
            {
                Console.WriteLine($"{scence}");
            }
        }
    }

    public class DVD : Movie
    {
        public DVD(string title, Genre category, int runtime)
        {
            Title = title;
            Category = category;
            RunTime = runtime;
        }
        public override void Play()
        {
            int userchoice = 0;

            Console.WriteLine("What scence would you like to watch?: ");
            PrintScenes();
            userchoice = int.Parse(Console.ReadLine());

            Console.WriteLine($"{Scenes[userchoice - 1]}");
        }

        public override void PlayWholeMovie()
        {
            foreach (string scence in Scenes)
            {
                Console.WriteLine($"{scence}");
            }
        }
    }

    public class Blockbuster    
    {
        
            public List<Movie> Movies = new List<Movie>();



            public void PrintMovies(List<Movie> listofmovies)
            {
                int i = 1;
                foreach (Movie movie in listofmovies)
                {
                    Console.WriteLine($"[{i}]{movie.Title}");
                    i++;
                }
            }

            public Movie CheckOut(List<Movie> listofmovies)
            {
                int userchoice = 0;

                Console.WriteLine("Which movie you want?:");
                PrintMovies(listofmovies);
                userchoice = int.Parse(Console.ReadLine());

                listofmovies[userchoice - 1].PrintInfo();

                return listofmovies[userchoice - 1];

            }


        



    }

    public enum Genre
    {
        Drama,
        Comedy,
        Horror,
        Romance,
        Action

    }
}
