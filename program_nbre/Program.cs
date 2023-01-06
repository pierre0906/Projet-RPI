
namespace program_nbre
{
    internal class Program
    {

        //Console.WriteLine("Hello, World!");
        static void Main(string[] args)
        {
            Console.WriteLine("Saisissez un nombre :");
            var KeyboardEntry = Console.ReadLine();
            Console.WriteLine("Vous avez ecrit ");
            Console.WriteLine(KeyboardEntry);
           /* int i = 1;
            int j;
            int valeur;
            while (i <= 12)
            {
                Console.WriteLine("%d", i);
                j = 1;
                while (j <= 12)
                {
                    valeur = i * j;
                    Console.WriteLine("\t%d", valeur);
                    j++;
                }
                Console.WriteLine("\n");
                i++;
            }*/

        }
    }
}