internal class Program
{
    private bool[,] circles_crossess = new bool[2, 9];

    private bool sprawdzenie_pola(ref uint bufor, int circle_or_cross)
    {
        if (bufor > 0 && bufor < 10)
        {
            if (circles_crossess[0, bufor - 1] == false && circles_crossess[1, bufor - 1] == false)
            {
                circles_crossess[circle_or_cross, bufor - 1] = true;
                return true;
            }
            else
            {
                Console.WriteLine("Na tym polu juz sie cos znajduje! Wybierz inne: ");
                bufor = Convert.ToUInt32(Console.ReadLine());
                return sprawdzenie_pola(ref bufor, circle_or_cross);
            }
        }
        else
        {
            Console.WriteLine("Nie ma takiego pola! Podaj inne: ");
            bufor = Convert.ToUInt32(Console.ReadLine());
            return sprawdzenie_pola(ref bufor, circle_or_cross);
        }
    }

    private bool sprawdzenie_wyniku()
    {
        Program program = new Program();

        if (program.wygrana() == 1)
        {
            Console.Clear();

            program.wypisywanie();
            Console.WriteLine("Wygrana kolek!");
            return true;
        }
        else if (program.wygrana() == 2)
        {
            Console.Clear();

            program.wypisywanie();
            Console.WriteLine("Wygrana krzyzykow!");
            return true;
        }
        else if (program.remis())
        {
            Console.Clear();

            program.wypisywanie();
            Console.WriteLine("Remis!");
            return true;
        }

        return false;
    }

    private int wygrana()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (circles_crossess[i, j] == true && circles_crossess[i, j + 3] == true && circles_crossess[i, j + 6] == true)
                {
                    return i + 1;
                }
                else if (circles_crossess[i, j * 3] == true && circles_crossess[i, j * 3 + 1] == true && circles_crossess[i, j * 3 + 2] == true)
                {
                    return i + 1;
                }
            }

            if ((circles_crossess[i, 0] && circles_crossess[i, 4] && circles_crossess[i, 8]) || (circles_crossess[i, 2] && circles_crossess[i, 4] && circles_crossess[i, 6]))
            {
                return i + 1;
            }
        }
        return 0;
    }

    private bool remis()
    {
        int suma = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (circles_crossess[i, j] == true)
                {
                    suma++;
                }
            }
        }

        if (suma == 9)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void wypisywanie()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (circles_crossess[0, j + (3 * i)] == true)
                {
                    Console.Write("O");
                }
                else if (circles_crossess[1, j + (3 * i)])
                {
                    Console.Write("X");
                }
                else { Console.Write(" "); }

                if (j != 2)
                {
                    Console.Write("|");
                }

            }
            Console.WriteLine("");
            if (i != 2)
            {
                Console.WriteLine("-----");
            }
        }
    }

    private static void Main(string[] args)
    {
        Program program = new Program();
        uint bufor = 0;
        while (true)
        {
            program.wypisywanie();

            Console.WriteLine("Na jakim polu postawic kolko: ");
            bufor = Convert.ToUInt32(Console.ReadLine());

            program.sprawdzenie_pola(ref bufor, 0);

            if (program.sprawdzenie_wyniku() == true) break;

            Console.WriteLine("Na jakim polu postawic krzyzyk: ");
            bufor = Convert.ToUInt32(Console.ReadLine());

            program.sprawdzenie_pola(ref bufor, 1);

            if (program.sprawdzenie_wyniku() == true) break;

            Console.Clear();

        }
    }
}
