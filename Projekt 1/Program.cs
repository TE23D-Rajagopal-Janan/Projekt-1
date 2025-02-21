int enemyHp = 35;
int hp = 20;
// player p1 = new();
// p1.hp = 100;
// p1.weapon = "sword";
// p1.minDamage = 3;
// p1.maxDamage = 7;


Console.WriteLine("What is your Charecter name");
bool p1NameCheck = false;
string p1Name = Console.ReadLine(); 
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

Console.WriteLine(HealthBar);

Console.ReadLine();

static void HealthBar()
{
    Console.Write("[");  
    for (int i = 0; i < hp; i++)
    {
    Console.Write("█");
    }
}

static void combat()
{
    int attack = Random.Shared.Next(4);

}
// class player 
// {
//     public int hp;
//     public string weapon;
//     public int minDamage;
//     public int maxDamage;
// }
