using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JeuPendu
{
    public class GameInstance
    {
        private int MaxErrors { get; set; }  // Propriété MaxError accessible en lecture et écriture de type entier
        
        // On a deux listes 
        public List<char> Guesses { get; }  // Liste qui répresente des caractères trouvés

        public List<char> Misses { get; }

        // Liste des mots
        public List<Word> Words { get; }

        // Prorpiété mots à deviner
        public Word WordToGuess { get; }

        // Le programme va piocher dans la liste des mots
        private Random rnd;

        // Permet de savoir si l'utilisateur a gagné ou non
        private bool iswin { get; set; }

        // Une variable qui permet de travailler sur les lettres que l'utilisateur a trouvé
        private string currentWordGuessed;

        // Constructeur de GameInstance avec le nombre d'erreur
        public GameInstance(int maxErrors = 10)
        {
            rnd= new Random();   // Permet de generer un chiffre aléatoire
            this.MaxErrors = maxErrors;   // Initialiser notre variable erreur

            Words = new List<Word>
            {
                new Word("Programmation"),
                new Word("Pragmatique"),
                new Word("Essence"),
                new Word("Gestation"),
                new Word("Mutation"),
                new Word("Soleil"),
                new Word("Immeuble"),
            };

            // Initialiser les deux listes de char
            Guesses = new List<char>();
            Misses = new List<char>();
            // Il faut aller dans la liste pour trouver des indexes un element
            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine($"Le mot à deviner contient {WordToGuess.Length} letters"); // On peut afficher directement une variable dans une chaine des caractères
        }

        // Deuxième constructeur
        public GameInstance(List<Word> words, int maxErrors = 10 )  // L'utilisateur n'est pas obligé à saisir le nombre d'erreur
        {
            rnd = new Random();   // Permet de generer un chiffre aléatoire
            this.MaxErrors = maxErrors;   // Initialiser notre variable erreur
            Words = words;

            // Initialiser les deux listes de char
            Guesses = new List<char>();
            Misses = new List<char>();
            // Il faut aller dans la liste pour trouver des indexes un element
            WordToGuess = Words[rnd.Next(0, Words.Count)];

            Console.WriteLine($"Le mot à deviner contient {WordToGuess.Length} letters"); // On peut afficher directement une variable dans une chaine des caractères


            currentWordGuessed = PrintWordToGuess();
            
        }

        public void Play()  // Methode Play
        {
            // Tant que la partie n'est pas gagnée
           while (!iswin)
            {
                Console.WriteLine("Donnez moi une lettre :");
                char letter = char.ToUpper(Console.ReadKey(true).KeyChar);  // Permet de lire la touche que l'utilisateur à appuyer(True: pour ne pas afficher la touche sur laquelle l'utilisateur à appuyer)
                // Créer une variable de type entier
                int letterIndex = WordToGuess.GetIndexOf(letter);

                Console.WriteLine();

                Console.WriteLine($"[DEBUG] letterIndex : {letterIndex}");

                if (letterIndex != -1)  // Affichez -1 si les caractères n'existent pas
                {
                    Console.WriteLine($"Bravo,  vous avez trouvé la lettre: {letter}");
                    Guesses.Add(letter);  // Alors qu'on trouve une lettre dans la liste de mots, on ajoute une lettre
                }
                else
                {
                    Console.WriteLine($"la lettre: {letter} ne se trouve pas dans le mot ");
                    Misses.Add(letter);   // Dans liste d'erreur, on ajoute une lettre
                }
                if(Misses.Count > 0)

                // Afficher à l'utilisateur le nombre d'erreur qui a commise
                Console.WriteLine($"Erreurs ({Misses.Count}) : {string.Join(", ", Misses)}"); // On separe chaque élément de la liste par une virgule, et on l'affiche
            }
            currentWordGuessed = PrintWordToGuess();

            if (currentWordGuessed.IndexOf('_') == -1)
            {
                iswin = true;
                Console.WriteLine("Félication, vous avez gagné !");
                Console.ReadKey();
            }

            if (Misses.Count >= MaxErrors)

            {
                Console.WriteLine("Vous avez perdu !");
                Console.ReadKey();
                
            }
            
        }

        private string PrintWordToGuess()
        {
            string currentWordGuessed = "";

            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (Guesses.Contains(WordToGuess.Text[i]))
                {
                    currentWordGuessed += WordToGuess.Text[i];
                }
                else
                {
                    currentWordGuessed += "_";
                }
            }
            Console.WriteLine(currentWordGuessed);
            Console.WriteLine();
            
            return currentWordGuessed;  // Cette variable return permet de definir les condition de victoire
        }

    }
}
