using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPendu
{
    public class Word
    {
        public string Text { get; set; }   // Création d'une propriété de type string pour le text en lecture(get) et écriture(set)
        public int Length { get; }   // La taille du text seulement en lecture

        public Word(string text)     // Constructeur Word
        {
            Text = text.ToUpper();   // Mettre le text en majuscule
            Length = text.Length;  // La taille de notre text
           
        }
        // Methode qui permet de récupérer l'index d'un caractère text
        public int GetIndexOf(char letter)
        {
            return Text.IndexOf(letter);
        }
    }
}
