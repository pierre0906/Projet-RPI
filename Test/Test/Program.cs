// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

namespace JeuTic
{

    class Program
    {
        // Créer les variables
        public static bool quitGate = false;  // permet de  quitter le jeu
        public static bool playerTurn = true; // Autour de joueur de jouer ou de l'ordinateur
        public static char[,] board;  //Plateau de jeu (tableau de caractères) sur stocké dans le board
        static void Main(string[] args)
        {
            // Boucle de jeu
            while (!quitGate)  // Boucle While, tant que le jeu tourne, on va exécuter notre code 
            {
                board = new char[3, 3]  // generer le plateau de 3 lignes et 3 colonnes
                {
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                };
                while (!quitGate)
                {
                    // Au tour du joueur
                    if (playerTurn)
                    {
                        PlayerTurn();
                        if (CheckLines('X'))   // Si l'ordinateur aligne trois même pièce
                        {
                            EndGame(" Vous avez gagné!");
                            break;
                        }
                    }
                    // Au tour de l'ordinateur
                    else
                    {
                        ComputerTurn();
                        if (CheckLines('O'))    // Si l'ordinateur aligne trois même pièce
                        {
                            EndGame(" Vous avez perdu!");
                            break;
                        }
                    }

                    // Changement de joueur
                    playerTurn = !playerTurn;

                    // Vérifier si match nul
                    if (CheckDraw())    // Draw: match nul
                    {
                        EndGame("Draw!");
                        break;
                    }

                }
                if (!quitGate)
                {
                    Console.WriteLine("Appuyer sur [Escape] pour quitter, [Enter pour rejouer.");
                Getkey:   //Création( une etiquette ) d'un endroit dans le code qui permet d'accéder avec un Go To
                    switch (Console.ReadKey(true).Key)  // Permet de récupérer la touche du clavier
                    {
                        // Rejouer
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:   // Permet à l'utilisateur d'utiliser la touche du clavier Echap
                            quitGate = true;
                            Console.Clear();    // Effacer tout ce qu'il y a à l'écran
                            break;             // Pour terminer mon instruction
                        default:          // Tester une autre touche de clavier
                            goto Getkey;     // Permet de repartir de l'endroit spécifier
                    }
                }
            }
        }  // Fin de fonction Main

        // Fonctions

        // Au tour du joueur
        public static void PlayerTurn()
        {
            // Où se trouve le joueur sur la grille?
            // Le curseur sera sur une ligne et une colonne
            var (row, column) = (0, 0);
            // Le joueur a t-il déplacer son curseur?
            bool moved = false;
            // Boucle pour déplacer le curseur à l'écran
            while (!quitGate && !moved)
            {
                Console.Clear();  // Nettoyer la console
                // Afficher la grille
                RenderBoard();
                Console.WriteLine();
                // Afficher les instructions 
                Console.WriteLine("Choisir une case valide puis apputer sur [Enter]");
                // Afficher le curseur
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
                // Attendre que l'utilisateur réalise une action (key)
                switch (Console.ReadKey(true).Key)  // Permet de récupérer la touche du clavier
                {
                    case ConsoleKey.Escape:   // Permet à l'utilisateur d'utiliser la touche du clavier Echap
                        quitGate = true;
                        Console.Clear();    // Effacer tout ce qu'il y a à l'écran
                        break;             // Pour terminer mon instruction

                    // Gérer les fleches du clavier
                    // Pour déplacer le curseur à l'écran
                    case ConsoleKey.RightArrow:
                        if(column >= 2)      // Si colonne est supérieure à 2
                        {
                            column = 0;    // Retour sur la premiere case
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;             // Terminer notre instruction
                    case ConsoleKey.LeftArrow:
                        if (column <= 0)      // Si colonne est plus petite ou égale = 0
                        {
                            column = 2;    // Retour sur la premiere case
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;             // Terminer notre instruction

                        // La flèche du haut
                    case ConsoleKey.UpArrow:
                        if (row <= 0)      // Si colonne est plus petite ou égale = 0
                        {
                            row = 2;    // Retour sur la premiere case
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    // Jouer dans la case actuelle
                    case ConsoleKey.Enter:
                        if(board[row, column] is ' ')
                        {
                            board[row, column] = 'X';
                            moved = true;
                        }
                        break;

                    // La flèche du bas
                    case ConsoleKey.DownArrow:
                        if (row >= 2)      // Si colonne est supérieure à 2
                        {
                            row = 0;    // Retour sur la premiere case
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                }
            }
        }

        // Au tour de l'ordinateur
        public static void ComputerTurn()
        {
            // Liste des cases vides
            var emptyBox = new List<(int X, int Y)>();

            // Double boucle pour parcourir les cases
            for (int i = 0; i < 3;  i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Vérifier si la case est vide
                    if (board[i, j] == ' ')
                    {
                        // Ajouter des coordonnées dans la case vide (i, j)
                        emptyBox.Add((i, j)); 
                    }
                }
            }
            // où est-ce que l'ordinateur va jouer?
            var (X, Y) = emptyBox[new Random().Next(0, emptyBox.Count)];  // Tirer au sort les éléments de la liste aléatoirement 
            board[X, Y] = 'O';    // Saisir le pion jouer par l'ordinateur
        }
        

        // Afficher le Plateau de jeu
        public static void RenderBoard()
        {
            Console.WriteLine();  // Créer un espace blanc
            Console.WriteLine($" {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}");
        }
        // Vérifier si un joueur a gagné

        public static bool CheckLines(char c) =>  // Fonction flechée
            board[0, 0] == c && board[1, 0] == c && board[2, 0] == c ||  // Permet de faire une vérification sur les trois lignes
            board[0, 1] == c && board[1, 1] == c && board[2, 1] == c ||
            board[0, 2] == c && board[1, 2] == c && board[2, 2] == c ||
            board[0, 0] == c && board[0, 1] == c && board[0, 2] == c ||    // Permet de faire une vérification sur les trois colonnes
            board[1, 0] == c && board[1, 1] == c && board[1, 2] == c ||
            board[2, 0] == c && board[2, 1] == c && board[2, 2] == c ||
            board[0, 0] == c && board[1, 1] == c && board[2, 2] == c ||   // Permet de faire une vérification sur les deux diagonales 
            board[2, 0] == c && board[1, 1] == c && board[0, 2] == c;

        // Vérifier si match nul
        public static bool CheckDraw() =>
            board[0, 0] != ' ' && board[1, 0] != ' ' && board[2, 0] != ' ' &&  // La case 1 est differente de la case 2
            board[0, 1] != ' ' && board[1, 1] != ' ' && board[2, 1] != ' ' && 
            board[0, 2] != ' ' && board[1, 2] != ' ' && board[2, 2] != ' ';


        //Fin de la partie

        public static void EndGame(string msg)
        {
            Console.Clear();
            RenderBoard();   // Vérifier le plateau
            Console.WriteLine(msg);   // Afficher le message vous avez gagné ou perdu
        }
    }


}

