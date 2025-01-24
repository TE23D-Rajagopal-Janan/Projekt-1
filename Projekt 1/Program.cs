int enemyHp = 35; 
player p1 = new();
p1.hp = 100;
p1.weapon = "sword";
p1.minDamage = 3;
p1.maxDamage = 7;


Console.WriteLine("What is your Charecter name");
string p1Name = Console.ReadLine();
bool name = false;
int checkName = 0;
while (!name)
{
    Console.WriteLine("Write your name (with letters!)");
    name = int.TryParse(p1Name, out checkName);
    Console.ReadLine();
}



Console.ReadLine();

static void combat(player player )
{
    int attack = Random.Shared.Next(4);
    if (attack > 2)
    {
        Console.WriteLine("");
    }

}
class player 
{
    public int hp;
    public string weapon;
    public int minDamage;
    public int maxDamage;
}
