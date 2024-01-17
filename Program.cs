using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();

            initValues(ref lives, ref magic, ref health, r);
            Console.WriteLine($"Starting: Lives = {lives}; Magic = {magic}; Health = {health}");

            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }

       

        private static void initValues(ref int lives, ref int magic, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            magic = r.Next(15) + 5;
            health = r.Next(14) + 5;
            return;
        }

        private static int chooseDirection()
        { 
            Console.WriteLine("You've come to a crossroad: enter 1 to travel left and 2 to travel right.");

            int direction = int.Parse(Console.ReadLine());

            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
        private static void actions(int v, ref int lives, ref int magic, ref int health)
        {
            int num = v;
            switch (num)
            {

                // The first 4 cases should have negative consequences.
                case 0:
                    Console.WriteLine("You met three bears who were not happy that their porridge was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by flying monkeys and had to be rescued by a young girl and a dog");
                    Console.WriteLine("You lost 2 units of health and magic and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You saw the Grimm and froze in fear, allowing yourself to be attacked by scorpions.");
                    Console.WriteLine("You lose 3 units of health and 1 magic");
                    health -= 3;
                    magic -= 1;
                    break;

                case 3:
                    Console.WriteLine("A dragon attacked the road you're traveling and you had to save a family before you could continue.");
                    Console.WriteLine("You lose 3 units of health and magic, and 1 life");
                    health -= 3;
                    magic -= 3;
                    lives -= 1;
                    break;

                // The remaining 6 can have either positive or negative consequences (you can decide).
                case 4:
                    Console.WriteLine("You helped a fairy get back to its garden.");
                    Console.WriteLine("The fairy granted you 2 units of health and 1 life");
                    health += 2;
                    lives += 1;
                    break;

                case 5:
                    Console.WriteLine("You saved a fellow traveler from a headless horseman.");
                    Console.WriteLine("The traveler granted you 2 units of health, magic and lives");
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a women who lived in a house that resembled a shoe (she had a lot of kids).");
                    Console.WriteLine("You gain 3 units of health and magic");
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("You shared your lunch with a traveling family.");
                    Console.WriteLine("The parents granted you 3 units of magic");
                    magic += 3;
                    break;
                case 8:
                    Console.WriteLine("You tripped over a rock.");
                    Console.WriteLine("You lose 1 health and 1 magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 9:
                    Console.WriteLine("You found a stray cat and befriended it.");
                    Console.WriteLine("The cat was a secret wizard, and granted you 2 lives");
                    lives += 2;
                    break;
                default:
                    Console.WriteLine("You saved a unicorn from a mean wizard.");
                    Console.WriteLine("You gain 2 lives and 2 units of magic");
                    magic += 2;
                    lives += 2;
                    break;
            }
        }
        private static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            //1) Add 1 to the round variable
            round++;

            //2) Write out the round number
            Console.WriteLine($"\n~~~~~~~~~Round: {round}~~~~~~~~~~~~~~~\n");

            //3) Write out the values for lives, magic and health
            Console.WriteLine($"Lives: {lives}; Magic: {magic}; Health: {health}");

            //4) Check to see if the round variable >= 25.If it is true, then set win = true.
            if (round >= 25)
            {
                win = true;
            }

            //5) Return to the main methodround++;
            return;
        }  

    }
} 