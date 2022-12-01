using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laskbackensistauppgift
{
    class program
    {
        public static void Main(string[] args)
        {
            var laskapparat = new Laskapparat();
            laskapparat.Run();
            Console.WriteLine(true);
        }
        class Laskapparat
        {

            public string[] laskback = new string[20]; //Läskbacken som har plats för 22 flaskor
            int beraknade_flaskor = 0; //Antalet flaskor i läskbacken

            public int summa = 0; //summa för total kostnad av flaskor

            public void Run() //Metod som kör hela programmet

            {
                Console.WriteLine("Välkommen till min läskback. Du kommer få olika val");
                int meny = 0;

                do // köra igenom menyn då jag inte vet hur många gånger förväg menyn ska köras
                {
                    Console.WriteLine("Välj ditt alternativ som du kommer få");
                    Console.WriteLine("*************");

                    Console.WriteLine(" 1. Lägg till drycken.");
                    Console.WriteLine(" 2. Titta vad som finns inuti.");
                    Console.WriteLine(" 3. Beräkna läskbackens värde.");
                    Console.WriteLine(" 4. Sortera dryckerna. ");
                    Console.WriteLine(" 5. Avsluta programmet. \n");

                    try
                    {
                        meny = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch
                    {
                        Console.WriteLine("Bra att du svarade med en siffra");  //Catch för att fånga upp ett error ifall man inte svara med siffra
                    }
                    
                    switch (meny) //olika case med olika val
                    {
                        case 1:
                            Laggatilldryck();
                            break;
                        case 2:
                            Visainnehall();
                            break;
                        case 3:
                            Beraknavarde();
                            break;

                        case 4:
                            Sorteradryck();
                            break;

                        case 5:
                            Avsluta();
                            break;

                        default:
                            Console.WriteLine("Mata in rätt alt");
                            break;
                    }
                }
                while (meny != 5); //Menyn börjar om ifall 5 inte är valet
            }



            public void Laggatilldryck()

            {
                Console.WriteLine("Vad för dricka vill du lägga till?");
                if (beraknade_flaskor == 20)
                {
                    Console.WriteLine("Backen är full");
                    return;
                }

                Console.WriteLine("1. Cola ");
                Console.WriteLine("2. Sprite ");
                Console.WriteLine("3. Fanta ");
                Console.WriteLine("4. Loka ");
                Console.WriteLine("5. Cola-Zero ");

                int laskmeny = int.Parse(Console.ReadLine()); // läskmeny valet(strängen) läses in som en int

                string laskflaska = ""; //flaskans namn som väljs då i detta val läskflaskan inte tilldelas något. 


                {
                    switch (laskmeny)
                    {

                        case 1:
                            laskflaska = "Cola";
                            Console.WriteLine("Du valde att lägga till Cola");
                            break;


                        case 2:
                            laskflaska = "Sprite";
                            Console.WriteLine("Du valde att lägga till Sprite");
                            break;


                        case 3:
                            laskflaska = "Fanta";
                            Console.WriteLine("Du valde att lägga till Loka(vatten)");
                            break;

                        case 4:
                            laskflaska = "Loka";
                            Console.WriteLine("Du valde att lägga till Loka");
                            break;

                        case 5:
                            laskflaska = "Cola-Zero";
                            Console.WriteLine("Du valde att lägga till Cola-Zero");
                            break;

                        // Om en ogiltig dryck väljs så vill vi visa menyn igen
                        default:
                            laskflaska = "";
                            Console.WriteLine("Felaktig inmatning");
                            break;
                    }

                    Console.WriteLine("Hur många flaskor vill du lägga till i backen");
                    int totalt = int.Parse(Console.ReadLine());

                    if (beraknade_flaskor + totalt < 21) // Måste vara mindre än 22 flaskor för att kunna lägg till en flaska. 
                    {
                        for (int i = 0; i < totalt; i++)
                        {
                            laskback[beraknade_flaskor] = laskflaska;
                            beraknade_flaskor++;
                        }
                        int återstaende = laskback.Length - beraknade_flaskor;

                        Console.WriteLine("Du valde att lägga till {0} styck {1}", totalt, laskflaska);
                    }
                }
            }

            public void Visainnehall()
            {
                foreach (var dricka in laskback)
                {
                    if (dricka != null)
                        Console.WriteLine(dricka);
                    else
                        Console.WriteLine("ledig plats, fyll på med fler läsk");
                }
            }

            public void Beraknavarde() //beräkna värdet i apparaten
            {



                string dryck = Console.ReadLine();
                int laskkostnad = 10;
                int summa = laskkostnad * beraknade_flaskor;


                if (dryck == "Cola" || dryck == "Sprite") //testar med att använda denna if metod med ||
                {
                    laskkostnad = 10;
                }
                else if (dryck == "Loka")
                {
                    laskkostnad = 10;
                }
                else if (dryck == "Fanta")
                {
                    laskkostnad = 10;
                }
                else if (dryck == "Cola zero")
                {
                    laskkostnad = 10;
                }


                Console.WriteLine("Priset är " + summa + "kr");
            }
        
   
            
            public void Sorteradryck()
            {
                var names = new List<string> { "Cola", "Cola-Zero", "Sprite", "Loka", "Fanta" };
                names.Sort();
                foreach(var name in names)  //foreach loop för att den ska köras igenom lika många gånger som saker finns
                {
                    Console.WriteLine(name);
                }
                
            }
            public void Avsluta()
            {
                Console.Write("Tryck på valfri knapp...");
                Console.ReadKey();
            }
                 
            }
        }
    }

       
    


