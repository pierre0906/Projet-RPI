// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
static void Main(string[] args)
{
    int NbValeurs;

    Console.WriteLine("Combiens de valeurs (de type entiers) souhaitez vous saisir?");

    NbValeurs = Convert.ToInt16(Console.ReadLine());

    int[] tab = new int[NbValeurs];

    Console.WriteLine("Saisissez votre suite de valeurs:");

    // Pour autant de fois NbValeurs, on va demander a l'utilisateur d'entrer un nombre
    for (int i = 0; i < NbValeurs; i++)
    {
        tab[i] = Convert.ToInt16(Console.ReadLine()); // On rentre le nombre écrit par l'utilisateur pour l'index i, qui est incrémenté a chaque fois
    }

    // On affiche ça hors boucle pour présenter les nombres qui vont suivre
    Console.WriteLine("Vos valeurs sont:");

    // Pour autant de NbValeurs, que l'on a précedemment entré
    // A noter que tu peux utiliser tab.Lenght au lieu de NbValeurs
    for (int i = 0; i < NbValeurs; i++)
    {
        Console.WriteLine("case {0} : {1}", i, tab[i]); // On affiche l'index, puis le nombre en parcourant le tableau
    }

    Console.ReadKey();
}
