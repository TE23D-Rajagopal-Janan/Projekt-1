int hp = 20;
int maxHp = 20;

List<string> inventory = new List<string>(); // inventory 

Console.WriteLine("What is your Charecter name");
bool p1NameCheck = false;
string p1Name;
p1Name = Console.ReadLine();
int intNameCheckNumb = 0; // Just needed for parse to go out
p1NameCheck = int.TryParse(p1Name, out intNameCheckNumb);
while (p1Name == "" || p1NameCheck)
{
    if (p1NameCheck) // Check if input is a number
    {
        Console.WriteLine("Write your name (with letters!)");
    }
    Console.WriteLine("What is your Character name");
    p1Name = Console.ReadLine();
    p1NameCheck = int.TryParse(p1Name, out intNameCheckNumb);
}
Console.WriteLine($"Hi {p1Name}, you have just woken up in the middle of an island, having no memory of how you got here");
Console.Write("This is you healthbar = ");
HealthBar(hp, maxHp); // Shows out healthbar
Console.WriteLine("\nChoose A Direction To Go, Press They Key To Choose One Of The Following: \nForward (1) or back (2) (choose by typing on 1 or 2 into the console)");
string path;
while (true)
{
    path = Console.ReadLine();
    if (path == "1" || path == "2")
    {
        break; // Break while loop
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 1 or 2.");
    }
}
if (path == "1")
{
    Console.WriteLine("You Found A Rusty Sword");
    Console.WriteLine("The sword looks old, but still sharp enough to do more damage than you hands");
    inventory.Add("Rusty Sword");
    Console.WriteLine("Rusty Sword has been added to your inventory.");
    Inventory(inventory);
Console.WriteLine("You have encountered a goblin who seems weak however he seems eager to fight, \nDo you wanna fight (1) or try to run (2)");
}
else if (path == "2")
{
    Console.WriteLine("While turning your back you get attacked by a goblin, you lost 5 hp");
    hp -= 5;
    HealthBar(hp, maxHp);
Console.WriteLine("Do you wanna fight (1) or try to run (2)");
}
Console.WriteLine("Tip: You can get rewards from killing it");
while (true)
{
    path = Console.ReadLine();
    if (path == "1" || path == "2")
    {
        break; // Break while loop
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 1 or 2.");
    }
}
    int enemyHp = 15;
if (path == "1")
{
    hp = Combat("Goblin", hp, enemyHp, inventory, maxHp);
    Console.ReadLine();
}
Console.WriteLine("\nYou move deeper into the island...");
Console.WriteLine("A second goblin jumps out from a bush and attacks you!");
Console.WriteLine("\n Press 1 to start the fight");
while (true)
{
    path = Console.ReadLine();
    if (path == "1")
    {
        break; // Break while loop
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 1 to start the fight");
    }
}
enemyHp = 15;
hp = Combat("Goblin", hp, enemyHp, inventory, maxHp);

Inventory(inventory);
Console.ReadLine();
hp = Healing(hp, maxHp, inventory); 

Console.WriteLine("\nYou find a mysterious gate... A BOSS appears!");
enemyHp = 30;
hp = Combat("Island Guardian", hp, enemyHp, inventory, maxHp);

Console.WriteLine("\nYou defeated the boss! You are now the hero of the island!");
Console.WriteLine("THE END");

Console.ReadLine();
static void Inventory(List<string> inventory)
{
    Console.WriteLine("press 'i' to see your inventory or press Enter to skip");
    string inv = Console.ReadLine();
    while (true)
{
    if (inv == "i" || inv == "")
    {
        break; // Break while loop
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter i to see inventory or enter key to skip");
        inv = Console.ReadLine(); // need to be written in the loop to refresh the inv string, or else if i declar it in the loop i can't use the string in other loops
    }
}

    if (inv == "i")
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            Console.WriteLine("Your inventory contains:");
            foreach (string item in inventory)
            {
                Console.WriteLine("-" + item);
            }
            Console.WriteLine("press any key to move on");
            Console.ReadLine();
        }
    }
}

static void HealthBar(int hp, int maxHp)
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

static int Healing(int hp, int maxHp, List<string> inventory)
{
    if (inventory.Contains("Healing Potion"))
    {
        Console.WriteLine("Do you want to use a Healing Potion? (yes/no)");
        string usePotion = Console.ReadLine();
        while (true)
{
    if (usePotion == "yes" || usePotion == "no")
    {
        break; // Break while loop
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter i to see inventory or enter key to skip");
        usePotion = Console.ReadLine();
    }
}
        if (usePotion == "yes")
        {
            hp += 5;
            if (hp > maxHp) // if hp is above the max 
            {
                hp = maxHp;
            }
            inventory.Remove("Healing Potion");
            Console.WriteLine($"You used a Healing Potion and recovered 5 HP");
            Console.WriteLine($"Your HP is now: {hp}");
            Console.Write("hp ");
            HealthBar(hp, maxHp);
            Console.WriteLine("Press enter");
            Console.ReadLine();
        }
    }
    return hp;
}

static int Combat(string enemyName, int hp, int enemyHp, List<string> inventory,int  maxHp)
{
    int dmg;
    Console.WriteLine($"Fight with {enemyName} has started");
    while (hp > 0 && enemyHp > 0)
    {
        // Player attacks
        if (inventory.Contains("Rusty Sword"))
        {
            dmg = Random.Shared.Next(10, 15); // dmg with sword
            Console.WriteLine("You attack using (Rusty Sword)");
        }
        else
        {
            dmg = Random.Shared.Next(5, 10); // Regular damage
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
            Console.WriteLine("Press Enter to continue...");
            break; 
        }

        // Enemy attacks
        if (enemyName == "Island Guardian")
        {
            dmg = Random.Shared.Next(10, 15); // Random damage 
        }
        else{
        dmg = Random.Shared.Next(1, 7);
        }
        hp -= dmg;
        hp = Math.Max(0, hp);
        Console.WriteLine($"The enemy hits you for {dmg} damage! Your HP: {hp} hp");
        HealthBar(hp, maxHp);
        hp = Healing(hp, maxHp, inventory);


        if (hp <= 0)
        {
            Console.WriteLine("You Died");
            Console.ReadLine();
            Environment.Exit(0);
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    return hp;
}
