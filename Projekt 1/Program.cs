﻿int enemyHp = 35;
int hp = 20;
string p1Name;
int dmg;
// player p1 = new();
// p1.hp = 100;
// p1.weapon = "sword";
// p1.minDamage = 3;
// p1.maxDamage = 7;

Console.WriteLine("What is your Charecter name");
bool p1NameCheck = false;
p1Name = Console.ReadLine(); 
int intNameCheck = 0;
p1NameCheck = int.TryParse(p1Name, out intNameCheck);
while (p1Name == "" || p1NameCheck)  
{
      if (p1NameCheck) // Check if input is a number
    {
        Console.WriteLine("Write your name (with letters!)");
    }
    Console.WriteLine("What is your Charecter name");
    p1Name = Console.ReadLine();   
    p1NameCheck = int.TryParse(p1Name, out intNameCheck);
}   

HealthBar(); // skriver ut helthbar
Console.WriteLine("You have just woken up in the middle of an island ");
Console.WriteLine("Choose a direction go either 1. forward or 2. back (choose by typing on 1 or 2)"); 
string path1; 
path1 = Console.ReadLine();
if (path1 == "1")
{
  Console.WriteLine("You found a rusty sword, whould you like to pick it up? (yes/no)");
  Console
}

Console.ReadLine();
 void HealthBar()
{
    Console.Write("[");  
    for (int i = 0; i < hp; i++)
    {
    Console.Write("█");
    }
    Console.Write("]");  
    Console.WriteLine();
}

 void combat()
{
    dmg = Random.Shared.Next(0, 100);
    if (dmg == 0)
    {
        dmg = 100;
    }

}
// class player 
// {
//     public int hp;
//     public string weapon;
//     public int minDamage;
//     public int maxDamage;
// }
