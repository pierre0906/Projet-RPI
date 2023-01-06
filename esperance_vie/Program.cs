// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Cache;

namespace EspaceDeNom


{

    class Program

    {

        static void Main(string[] args)

        {
            Console.WriteLine("Veillez rentrer votre nom");
            var KeyboardEntry = Console.ReadLine();
            Console.WriteLine("Votre nom est: ");
            Console.WriteLine(KeyboardEntry);
            string nom = Console.ReadLine();

            Console.WriteLine("Veillez rentrer votre age");
            Console.WriteLine(KeyboardEntry);
            Console.WriteLine("Votre age est: ");
            int age = new int();
    
            Console.WriteLine("Nom " + nom + " Age " + age);
            Console.In.ReadLine();

        }

    }

}
