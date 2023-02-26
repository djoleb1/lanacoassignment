using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Cardgame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pravimo array 'karte' koji sadrzi karte i instanciramo 3 igraca i dajemo svakom odredjeni broj karata

            string[] karte = { "Q List", "Q Srce", "Q Tref", "Q Romb", "K List", "K Srce", "K Tref", "K Romb", "J List", "J Tref", "J Srce", "J Romb", "2 Tref",};
            string[] igracJedan = new string[4];
            string[] igracDva = new string[4];
            string[] igracTri = new string[5];
            var sviIgraci = new[] { igracJedan, igracDva, igracTri }; 

            //Funkcija promijesajKarte nam preko Random() mijesa indexe karata u arrayu 'karte'

            void promijesajKarte()
            {
                int zadnjiIndex = karte.Count() - 1;
                while (zadnjiIndex > 0)
                {
                    string tempValue = karte[zadnjiIndex];
                    int randomIndex = new Random().Next(0, zadnjiIndex);
                    karte[zadnjiIndex] = karte[randomIndex];
                    karte[randomIndex] = tempValue;
                    zadnjiIndex--;
                }
            }

            promijesajKarte();

            //Petlja koja nam dodijeljuje karte po redoslijedu, sada izmijesanog spila karata

            for (int i = 0; i < 4; i++)
            {
                igracJedan[i] = karte[i];
                igracDva[i] = karte[i+4];
            }

            for (int i = 0; i <5; i++)
            {
                igracTri[i] = karte[i + 8];
            }

            
            int brojPoteza = 0;
            string pobjednik = null;

            void prikaziKarte()
            {
                Console.WriteLine($"Karte od igraca broj 1: " + string.Join(", ", igracJedan));
                Console.WriteLine("_________________________");

                Console.WriteLine($"Karte od igraca broj 2: " + string.Join(", ", igracDva));
                Console.WriteLine("_________________________");

                Console.WriteLine($"Karte od igraca broj 3: " + string.Join(", ", igracTri));
                Console.WriteLine("_________________________");
            }

           
            prikaziKarte();

            while (pobjednik == null)
            {
                // Pocinje igrac broj 3, jer ima 5 karata
                brojPoteza++;
                Console.WriteLine($"Igrac broj 3 je na potezu.");
                Console.WriteLine($"Karte od igraca broj 3: " + string.Join(", ", igracTri));
                Console.WriteLine("_________________________");

                Console.Write("Izaberi kartu koju ces proslijediti: ");
                string kartaZaProslijediti = Console.ReadLine();
                Console.WriteLine("_________________________");
                


                if (!igracTri.Contains(kartaZaProslijediti))
                {
                    while (!igracTri.Contains(kartaZaProslijediti))
                    {
                        Console.WriteLine($"Nemas {kartaZaProslijediti} kartu!");
                        Console.Write("Izaberi kartu koju ces proslijediti: ");
                        kartaZaProslijediti = Console.ReadLine();
                    }
                }else if (kartaZaProslijediti == "2 Tref" && brojPoteza % 3 != 0)
                    {
                        Console.WriteLine("2 Tref kartu mozes proslijediti samo svaki 3 red");
                        Console.Write("Izaberi kartu koju ces proslijediti: ");
                        kartaZaProslijediti = Console.ReadLine();
                    }



                Console.Write($"{kartaZaProslijediti}\n");
                

                Console.Write("Izaberi igraca kojem ces proslijediti kartu (1/2): ");
                int igracKojemProsljedjuje = int.Parse(Console.ReadLine());
                while (igracKojemProsljedjuje != 1 && igracKojemProsljedjuje != 2)
                {
                    Console.Write($"Igrac {igracKojemProsljedjuje} ne postoji!");
                    Console.Write("Izaberi igraca kojem ces proslijediti kartu (1/2): ");
                    igracKojemProsljedjuje = int.Parse(Console.ReadLine());
                }

                Console.Write($"{igracKojemProsljedjuje}\n");
                
                //Dodajemo izabranu kartu u spil igraca kojem je igrac 3 odredio
                igracTri = igracTri.Where(karta => karta != kartaZaProslijediti).ToArray();
                if (igracKojemProsljedjuje == 1)
                {
                    igracJedan = igracJedan.Concat(new[] { kartaZaProslijediti }).ToArray();
                }else if (igracKojemProsljedjuje == 2)
                {
                    igracDva = igracDva.Concat(new[] { kartaZaProslijediti }).ToArray();
                }

                prikaziKarte();

                //Igrac 2
                
                Console.WriteLine($"Igrac broj 2 je na potezu.");
                Console.WriteLine($"Karte od igraca broj 2: " + string.Join(", ", igracDva));
                Console.WriteLine("_________________________");

                Console.Write("Izaberi kartu koju ces proslijediti: ");
                kartaZaProslijediti = Console.ReadLine();
                Console.WriteLine("_________________________");

                if (!igracDva.Contains(kartaZaProslijediti))
                {
                    while (!igracDva.Contains(kartaZaProslijediti))
                    {
                        Console.WriteLine($"Nemas {kartaZaProslijediti} kartu!");
                        Console.Write("Izaberi kartu koju ces proslijediti: ");
                        kartaZaProslijediti = Console.ReadLine();
                    }
                }
                else if (kartaZaProslijediti == "2 Tref" && brojPoteza % 3 != 0)
                {
                    Console.WriteLine("2 Tref kartu mozes proslijediti samo svaki 3 red");
                    Console.Write("Izaberi kartu koju ces proslijediti: ");
                    kartaZaProslijediti = Console.ReadLine();
                }



                Console.Write($"{kartaZaProslijediti}\n");

                Console.Write("Izaberi igraca kojem ces proslijediti kartu (1/3): ");
                igracKojemProsljedjuje = int.Parse(Console.ReadLine());
                while (igracKojemProsljedjuje != 1 && igracKojemProsljedjuje != 3)
                {
                    Console.Write($"Igrac {igracKojemProsljedjuje} ne postoji!");
                    Console.Write("Izaberi igraca kojem ces proslijediti kartu (1/3): ");
                    igracKojemProsljedjuje = int.Parse(Console.ReadLine());
                }

                Console.Write($"{igracKojemProsljedjuje}\n");

                igracDva = igracDva.Where(karta => karta != kartaZaProslijediti).ToArray();
                if (igracKojemProsljedjuje == 1)
                {
                    igracJedan = igracJedan.Concat(new[] { kartaZaProslijediti }).ToArray();
                }
                else if (igracKojemProsljedjuje == 3)
                {
                    igracTri = igracTri.Concat(new[] { kartaZaProslijediti }).ToArray();
                }

                prikaziKarte();
                //Igrac 1
                Console.WriteLine($"Igrac broj 1 je na potezu.");
                Console.WriteLine($"Karte od igraca broj 1: " + string.Join(", ", igracJedan));
                Console.WriteLine("_________________________");

                Console.Write("Izaberi kartu koju ces proslijediti: ");
                kartaZaProslijediti = Console.ReadLine();
                Console.WriteLine("_________________________");

                if (!igracJedan.Contains(kartaZaProslijediti))
                {
                    while (!igracJedan.Contains(kartaZaProslijediti))
                    {
                        Console.WriteLine($"Nemas {kartaZaProslijediti} kartu!");
                        Console.Write("Izaberi kartu koju ces proslijediti: ");
                        kartaZaProslijediti = Console.ReadLine();
                    }
                }
                else if (kartaZaProslijediti == "2 Tref" && brojPoteza % 3 != 0)
                {
                    Console.WriteLine("2 Tref kartu mozes proslijediti samo svaki 3 red");
                    Console.Write("Izaberi kartu koju ces proslijediti: ");
                    kartaZaProslijediti = Console.ReadLine();
                }

                Console.Write($"{kartaZaProslijediti}\n");

                Console.Write("Izaberi igraca kojem ces proslijediti kartu (2/3): ");
                igracKojemProsljedjuje = int.Parse(Console.ReadLine());
                while (igracKojemProsljedjuje != 2 && igracKojemProsljedjuje != 3)
                {
                    Console.Write($"Igrac {igracKojemProsljedjuje} ne postoji!");
                    Console.Write("Izaberi igraca kojem ces proslijediti kartu (2/3): ");
                    igracKojemProsljedjuje = int.Parse(Console.ReadLine());
                }

                Console.Write($"{igracKojemProsljedjuje}\n");

                igracJedan = igracJedan.Where(karta => karta != kartaZaProslijediti).ToArray();
                if (igracKojemProsljedjuje == 2)
                {
                    igracDva = igracDva.Concat(new[] { kartaZaProslijediti }).ToArray();
                }
                else if (igracKojemProsljedjuje == 3)
                {
                    igracTri = igracTri.Concat(new[] { kartaZaProslijediti }).ToArray();
                }

                prikaziKarte();

                foreach(string provjerikarte in igracJedan)
                {
                    if (igracJedan.Count(c => c[0] == provjerikarte[0]) == 4 && igracJedan.Length == 4)
                    {
                        pobjednik = "1";
                    } 
                }

                foreach (string provjerikarte in igracDva)
                {
                    if (igracDva.Count(c => c[0] == provjerikarte[0]) == 4 && igracDva.Length == 4)
                    {
                        pobjednik = "2";
                    }
                }

                foreach (string provjerikarte in igracTri)
                {
                    if (igracTri.Count(c => c[0] == provjerikarte[0]) == 4 && igracTri.Length == 4)
                    {
                        pobjednik = "3";
                    }
                }
                
            }

            Console.WriteLine("-------------------------------------------");
            prikaziKarte();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Igra je zavrsena nakon {brojPoteza} poteza");
           
            Console.WriteLine($"Pobjednik je igrac {pobjednik}! ");
            Console.WriteLine("-------------------------------------------");

            Console.ReadLine();
            
        }
    }
}
