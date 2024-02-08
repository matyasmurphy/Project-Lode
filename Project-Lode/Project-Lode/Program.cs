using System;

namespace Project_Lode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                int[,] hraciPole = new int[9, 9];

             

                bool zasah = false;
                bool znova;
            do
            {
                int pos1 = vyberPos1_1(0);
                int pos2 = vyberPos2_1(0);

                int pos1_2 = vyberPos1_2(0, pos1);
                int pos2_2 = vyberPos2_2(0, pos2);

                int pos1_3 = vyberPos1_3(0, pos1, pos1_2);
                int pos2_3 = vyberPos2_3(0, pos2, pos2_2);

                randomGenerator2D(hraciPole);

                Console.WriteLine("TEST");
                vypisLode(pos1, pos2, hraciPole);
                vypisLode_2(pos1_2, pos2_2, hraciPole);
                vypisLode_3(pos1_3, pos2_3, hraciPole);
                vypisPole2D(hraciPole);
                Console.WriteLine();
                Console.WriteLine($"R1:{pos1 + 1},S1:{pos2 + 1}");
                Console.WriteLine($"R2:{pos1_2 + 1},S2:{pos2_2 + 1}");
                Console.WriteLine($"R3:{pos1_3 + 1}, S2: {pos2_3 + 1}");
                Console.WriteLine();
                DelLode(pos1, pos2, hraciPole);
                DelLode_2(pos1_2, pos2_2, hraciPole);
                delLode_3(pos1_3, pos2_3, hraciPole);
                vypisPole2D(hraciPole);

                while (zasah == false)
                {
                    hledejLod(hraciPole, pos1, pos2, pos1_2, pos2_2, pos1_3, pos2_3);
                    vypisPole2D(hraciPole);
                    zasah = konec(hraciPole, zasah, pos1, pos2, pos1_2, pos2_2, pos1_3, pos2_3);
                }

                Console.WriteLine($"Chces opakovat? y/n");
                znova = (Console.ReadKey(true).KeyChar != 'y') ? false : true;
                zasah = false;
                Console.Clear();
            } while (znova);
            
        }
        static void randomGenerator2D(int[,] hraciPole)
        {
            Random random = new Random();
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {
                    hraciPole[s, r] = random.Next(0, 0);
                }
            }
        }
        static void vypisPole2D(int[,] hraciPole)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($" |A| B| C| D| E| F| G| H| I|");
            Console.ForegroundColor = ConsoleColor.White;
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                if (r == 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{r + 1}|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{r + 1}|");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    if (hraciPole[r, s] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{hraciPole[r, s]}| ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (hraciPole[r, s] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{hraciPole[r, s]}| ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (hraciPole[r, s] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"{hraciPole[r, s]}| ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write($"{hraciPole[r, s]}| ");
                    }
                }
                Console.WriteLine();
            }
        }

        static int vyberPos1_1(int pos1)
        {
            Random randomPos1 = new Random();
            pos1 = randomPos1.Next(0, 9);
            return pos1;
        }

        static int vyberPos2_1(int pos2)
        {
            Random randomPos2 = new Random();
            pos2 = randomPos2.Next(0, 9);

            while (pos2 >= 5)
            {
                pos2 = randomPos2.Next(0, 9);
            }
            return pos2;
        }

        static void vypisLode(int pos1, int pos2, int[,] hraciPole)
        {
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    if (r == pos1 && s == pos2)
                    {
                        hraciPole[r, s] = 1;
                        for (int i = 0; i < 4; i++)
                        {
                            hraciPole[r, s] = 1;
                            s++;
                        }
                    }
                    else
                    {
                        hraciPole[r, s] = 0;
                    }
                }
            }
        }

        static void DelLode(int pos1, int pos2, int[,] hraciPole)
        {
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    hraciPole[r, s] = 0;
                }
            }
        }
        static void hledejLod(int[,] hraciPole, int pos1, int pos2, int pos1_2, int pos2_2, int pos1_3, int pos2_3)
        {
            Console.WriteLine($"Najdi lod");
            Console.Write($"Radek: ");
            int radek; //= int.Parse(Console.ReadLine());
            while (!int.TryParse(Console.ReadLine(), out radek))
            {
                Console.WriteLine("Musi to byt cislo");
                Console.Write("Radek: ");
            }

            if (radek > 9)
            {
                while (radek >= 10)
                {
                    Console.WriteLine("Cislo je moc velke");
                    Console.Write("Radek: ");
                    while (!int.TryParse(Console.ReadLine(), out radek))
                    {
                        Console.WriteLine("Cislo je moc velke");
                        Console.Write("Radek: ");
                    }
                }
            }
            if (radek < 0)
            {
                while (radek <= -1)
                {
                    Console.WriteLine("Cislo je moc male");
                    Console.Write("Radek: ");
                    while (!int.TryParse(Console.ReadLine(), out radek))
                    {
                        Console.WriteLine("Cislo je moc male");
                        Console.Write("Radek: ");
                    }
                }
            }

            radek = radek - 1;
            ////////////////////////////////////////////////////////////////////////
            Console.Write($"Sloupec: ");
            int sloupec; //= int.Parse(Console.ReadLine());
            while (!int.TryParse(Console.ReadLine(), out sloupec))
            {
                Console.WriteLine("Musi to byt cislo");
                Console.Write("Sloupec: ");
            }

            if (sloupec > 9)
            {
                while (sloupec >= 10)
                {
                    Console.WriteLine("Cislo je moc velke");
                    Console.Write("Sloupec: ");
                    while (!int.TryParse(Console.ReadLine(), out sloupec))
                    {
                        Console.WriteLine("Cislo je moc velke");
                        Console.Write("Sloupec: ");
                    }
                }
            }
            if (sloupec < 0)
            {
                while (sloupec <= -1)
                {
                    Console.WriteLine("Cislo je moc male");
                    Console.Write("Sloupec: ");
                    while (!int.TryParse(Console.ReadLine(), out sloupec))
                    {
                        Console.WriteLine("Cislo je moc male");
                        Console.Write("Sloupec: ");
                    }
                }
            }

            sloupec = sloupec - 1;
            ////////////////////////////////////////////////////////////////////////
            Console.Clear();
            Console.WriteLine($"{radek + 1}, {sloupec + 1}");

            if (hraciPole[radek, sloupec] == 2)
            {
                Console.WriteLine("Lod uz byla zasazena");
            }
            else if (radek == pos1 && sloupec == pos2 || radek == pos1 && sloupec == pos2 + 1 || radek == pos1 && sloupec == pos2 + 2 || radek == pos1 && sloupec == pos2 + 3 || radek == pos1_2 && sloupec == pos2_2 || radek == pos1_2 + 1 && sloupec == pos2_2 || radek == pos1_2 + 2 && sloupec == pos2_2 || radek == pos1_3 && sloupec == pos2_3 || radek == pos1_3 + 1 && sloupec == pos2_3 || radek == pos1_3 + 1 && sloupec == pos2_3 + 1 ||radek == pos1_3 + 1 && sloupec == pos2_3 - 1)
            {
                Console.WriteLine("Zasah");
                hraciPole[radek, sloupec] = 2;
            }
            else
            {
                Console.WriteLine("Mimo");
            }
        }
        static bool konec(int[,] hraciPole, bool zasah, int pos1, int pos2, int pos1_2, int pos2_2, int pos1_3, int pos2_3)
        {
            if (hraciPole[pos1, pos2] == 2 && hraciPole[pos1, pos2 + 1] == 2 && hraciPole[pos1, pos2 + 2] == 2 && hraciPole[pos1, pos2 + 3] == 2 && hraciPole[pos1_2, pos2_2] == 2 && hraciPole[pos1_2 + 1, pos2_2] == 2 && hraciPole[pos1_2 + 2, pos2_2] == 2 && hraciPole[pos1_3,pos2_3] == 2 && hraciPole[pos1_3 + 1, pos2_3] == 2 && hraciPole[pos1_3 + 1, pos2_3 + 1] == 2 && hraciPole[pos1_3 + 1, pos2_3 - 1] == 2)
            {
                zasah = true;
            }
            else
            {
                zasah = false;
            }
            return zasah;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static int vyberPos1_2(int pos1_2, int pos1)
        {
            Random randomPos1 = new Random();
            pos1_2 = randomPos1.Next(0, 9);

            while (pos1_2 >= 6)
            {
                pos1_2 = randomPos1.Next(0, 9);
            }

            while (pos1_2 == pos1)
            {
                pos1_2 = randomPos1.Next(0, 9);
                while (pos1_2 >= 6)
                {
                    pos1_2 = randomPos1.Next(0, 9);
                }
            }
            return pos1_2;
        }

        static int vyberPos2_2(int pos2_2, int pos2)
        {
            Random randomPos2 = new Random();
            pos2_2 = randomPos2.Next(0, 9);

            while (pos2_2 >= 5)
            {
                pos2_2 = randomPos2.Next(0, 9);
            }
            while (pos2_2 == pos2 || pos2_2 == pos2 + 1 || pos2_2 == pos2 + 2 || pos2_2 == pos2 + 3)
            {
                pos2_2 = randomPos2.Next(0, 9);
                while (pos2_2 >= 5)
                {
                    pos2_2 = randomPos2.Next(0, 9);
                }
            }
            return pos2_2;
        }
        static void vypisLode_2(int pos1_2, int pos2_2, int[,] hraciPole)
        {
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    if (r == pos1_2 && s == pos2_2)
                    {
                        hraciPole[r, s] = 1;
                        for (int i = 0; i < 3; i++)
                        {
                            hraciPole[r, s] = 1;
                            r++;

                        }
                    }
                }
            }
        }

        static void DelLode_2(int pos1_2, int pos2_2, int[,] hraciPole)
        {
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    hraciPole[r, s] = 0;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static int vyberPos1_3(int pos1_3, int pos1_2, int pos1)
        {
            Random randomPos1 = new Random();
            pos1_3 = randomPos1.Next(0, 8);

            while (pos1_3 == pos1 || pos1_3 == pos1_2 || pos1_3 +1 == pos1 || pos1_3 + 1 == pos1_2)
            {
                pos1_3 = randomPos1.Next(0, 8);
            }
            return pos1_3;
        }

        static int vyberPos2_3(int pos2_3, int pos2_2, int pos2)
        {
            Random randomPos2 = new Random();
            pos2_3 = randomPos2.Next(1, 8);
            while (pos2_3 == pos2 || pos2_3 == pos2 + 1 || pos2_3 == pos2 + 2 || pos2_3 == pos2 + 3 || pos2_3 == pos2_2 || pos2_3 + 1 == pos2_2 || pos2_3 + 2 == pos2_2 || pos2_3 + 3 == pos2_2 || pos2_3 + 1 == pos2 || pos2_3 -1 == pos2)
            {
                pos2_3 = randomPos2.Next(1, 8);
            }
            return pos2_3;
        }

        static void vypisLode_3(int pos1_3, int pos2_3, int[,] hraciPole)
        {
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    if (r == pos1_3 && s == pos2_3)
                    {
                        hraciPole[r, s] = 1;
                        hraciPole[r + 1, s] = 1;
                        hraciPole[r + 1, s + 1] = 1;
                        hraciPole[r + 1, s - 1] = 1;
                    }
                }
            }
        }

        static void delLode_3(int pos1_3, int pos2_3, int[,] hraciPole)
        {
            for (int r = 0; r < hraciPole.GetLength(0); r++)
            {
                for (int s = 0; s < hraciPole.GetLength(1); s++)
                {

                    if (r == pos1_3 && s == pos2_3)
                    {
                        hraciPole[r, s] = 0;
                    }
                }
            }
        }
    }
}