internal class Program
{
    private bool[,] circles_crossess = new bool[2,9];

    private bool sprawdzenie_wyniku(bool[,] circless_crossesss)
    {
       Program program = new Program();
        
        if (program.wygrana(circles_crossess) == 1)
        {
            Console.Clear();
            
            program.wypisywanie(circles_crossess);
            Console.WriteLine("Wygrana kolek!");
            return true;
        }
        else if (program.wygrana(circles_crossess) == 2)
        {
            Console.Clear();

            program.wypisywanie(circles_crossess);
            Console.WriteLine("Wygrana krzyzykow!");
            return true;
        }
        else if (program.remis(circles_crossess))
        {
            Console.Clear();

            program.wypisywanie(circles_crossess);
            Console.WriteLine("Remis!");
            return true;
        }

        return false;
    }

    private int wygrana(bool[,] circles_crossess)
    {
        for (int i=0; i<2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (circles_crossess[i,j]==true && circles_crossess[i, j+3] == true && circles_crossess[i, j+6] == true)
                {
                    return i+1;
                }
                else if (circles_crossess[i, j*3] == true && circles_crossess[i, j*3 + 1] == true && circles_crossess[i, j*3 + 2] == true)
                {
                    return i+1;
                }
            }

            if ((circles_crossess[i,0] && circles_crossess[i, 4] && circles_crossess[i, 8]) || (circles_crossess[i, 2] && circles_crossess[i, 4] && circles_crossess[i, 6]))
            {
                return i + 1;
            }
        }
        return 0;
    }

    private bool remis(bool[,] circles_crossess)
    {
        int suma = 0;
        for(int i=0; i<2;i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (circles_crossess[i,j] == true)
                {
                    suma++;
                }
            }
        }

        if(suma==9)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void wypisywanie(bool[,] circles_crossess)
    {
        for(int i=0; i<3; i++)
        {
            for(int j=0; j<3; j++)
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
                
                if(j!=2)
                {
                    Console.Write("|");
                }
                
            }
            Console.WriteLine("");
            if(i!=2)
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
            program.wypisywanie(program.circles_crossess);

            Console.WriteLine("Na jakim polu postawic kolko: ");
            bufor = Convert.ToUInt32(Console.ReadLine());

            while(!(bufor>0 && bufor<10))
            {
                Console.WriteLine("Nie ma takiego pola! Podaj inne: ");
                bufor = Convert.ToUInt32(Console.ReadLine());
            }

            program.circles_crossess[0, bufor-1] = true;

            if (program.sprawdzenie_wyniku(program.circles_crossess) == true) break;

            Console.WriteLine("Na jakim polu postawic krzyzyk: ");
            bufor = Convert.ToUInt32(Console.ReadLine());

            while (!(bufor > 0 && bufor < 10))
            {
                Console.WriteLine("Nie ma takiego pola! Podaj inne: ");
                bufor = Convert.ToUInt32(Console.ReadLine());
            }

            program.circles_crossess[1, bufor-1] = true;

            if (program.sprawdzenie_wyniku(program.circles_crossess) == true) break;

            Console.Clear();

        }
    }
}
