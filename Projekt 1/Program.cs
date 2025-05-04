using System.Data;

int enemyHp = 15;
int hp = 30;
int maxHp = 30;
string p1Name;
int dmg;

List<string> inventory = new List<string>(); // inventory 

Console.WriteLine("What is your Charecter name");
bool p1NameCheck = false;
p1Name = Console.ReadLine(); 
int intNameCheck = 0; // Just needed for parse to go out
p1NameCheck = int.TryParse(p1Name, out intNameCheck);
while (p1Name == "" || p1NameCheck)  
{
      if (p1NameCheck) // Check if input is a number
    {
        Console.WriteLine("Write your name (with letters!)");
    }
    Console.WriteLine("What is your Character name");
    p1Name = Console.ReadLine();   
    p1NameCheck = int.TryParse(p1Name, out intNameCheck);
}   

Console.WriteLine("You Have Just Woken Up In The Middle Of An Island ");
Console.Write("This is you healthbar = "); 
HealthBar(); // Shows out healthbar
Console.WriteLine("\nChoose A Direction To Go, Press They Key To Choose One Of The Following: Forward (1) or back (2) (choose by typing on 1 or 2 into the console)"); 
string path; 
path = Console.ReadLine();
if (path == "1")
{
  Console.WriteLine("You Found A Rusty Sword");
  inventory.Add("Rusty Sword");
  Console.WriteLine("Rusty Sword has been added to your inventory.");
  Console.WriteLine("Press Enter To Continue");
  Console.ReadLine();
}
else if (path == "2")
{
    Console.WriteLine("While turning your back you get attacked by a goblin, you lost 10 hp");
      hp -= 10;
}
    Console.WriteLine("You have encountered a goblin who seems weak however he seems eager to fight, Do you wanna fight (1) or try to run (2)"); 
    Console.WriteLine("Tip: You can get rewards from killing it");
   path = Console.ReadLine(); 
   if (path == "1")
   {
    Combat("Goblin"); 
   }

Console.WriteLine("\nYou move deeper into the island...");
Console.WriteLine("A second goblin jumps out from a bush!");
enemyHp = 20;
Combat("Goblin");

Inventory();
Healing();

Console.WriteLine("\nYou find a mysterious gate... A BOSS appears!");
enemyHp = 50;
Combat("Island Guardian");

Console.WriteLine("\nYou defeated the boss! You are now the hero of the island!");
Console.WriteLine("THE END");

Console.ReadLine();
void Inventory()
{
    Console.WriteLine("press 'i' to see your inventory or press Enter to skip");
    string inv = Console.ReadLine();

    if (inv == "inv")
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            Console.WriteLine("Your inventory contains:");
            foreach  (string item in inventory)
            {
                Console.WriteLine(":" +item);
            }
        }
    }
}

 void HealthBar()
{
    Console.Write("[");  
    for (int i = 0; i < hp; i++)
    {
    Console.Write("█");
    }
    for (int i = hp; i < maxHp; i++)
    {
        Console.Write(" ");
    }
    Console.Write("]");  
    Console.WriteLine();
}
void Healing()
{
    if (inventory.Contains("Healing Potion"))
{
    Console.WriteLine("Do you want to use a Healing Potion? (yes/no)");
    string usePotion = Console.ReadLine();

    if (usePotion == "yes")
    {
        hp += 20;
        if (hp > maxHp) // if hp is above the max 
        {
            hp = maxHp;
        }
        inventory.Remove("Healing Potion");
        Console.WriteLine($"You used a Healing Potion and recovered 20 HP");
        Console.WriteLine($"Your HP is now: {hp}");
        Console.Write("hp ");
        HealthBar();
    }
}
}
 void Combat(string enemyName)
{
        while (hp > 0 && enemyHp > 0)
        {
            Console.WriteLine($"Fight with {enemyName} has started");
            // Player attacks
            if (inventory.Contains("Rusty Sword"))
            {
                dmg = Random.Shared.Next(10, 30); // dmg with sword
                Console.WriteLine("You attack using (Rusty Sword)");
            }
                else
                {
                    dmg = Random.Shared.Next(0, 20); // Regular damage
                     Console.WriteLine("You attack with your bare fists");
                }

            enemyHp -= dmg;
            enemyHp = Math.Max(0, enemyHp); // hp can't go under 0 
            Console.WriteLine($"You hit the enemy for {dmg} damage! {enemyName} HP: {enemyHp}");

            if (enemyHp <= 0)
            {
                Console.WriteLine($"You defeated the {enemyName}!");
                Console.WriteLine($"{enemyName} dropped a healing potion!");
                Console.WriteLine("Healing Potion have been added to your inventory");
                inventory.Add("Healing Potion");
                break;
            }

            // Enemy attacks
            dmg = Random.Shared.Next(3, 18); // Random damage 
            hp -= dmg;
            hp = Math.Max(0, hp);
            Console.WriteLine($"The enemy hits you for {dmg} damage! Your HP: {hp}");
            Console.Write("hp");
            HealthBar();

            if (hp <= 0)
            {
                Console.WriteLine("You Died");
                break;
            }

            // Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
}
