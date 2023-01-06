// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using JeuPendu;
using System;


namespace Pendu
{

    class Program
    {
        static void Main(string[] args)
        {
          GameInstance game = new GameInstance();
            game.Play();
            
        }
    }
}
