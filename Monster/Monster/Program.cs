using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

class Monster
{
    protected string name = "";
    protected int level = 0;
    protected int hp = 0;
}

class OrangeMushroom : Monster
{
    public OrangeMushroom(string name, int level, int hp)
    {
        Name = name;
        Level = level;
        Hp = hp;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }
    public int Level
    {
        get => level;
        private set => level = value;
    }
    public int Hp
    {
        get => hp;
        private set => hp = value;
    }
}

class Zombie : Monster
{
    public Zombie(string name, int level, int hp)
    {
        Name = name;
        Level = level;
        Hp = hp;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }
    public int Level
    {
        get => level;
        private set => level = value;
    }
    public int Hp
    {
        get => hp;
        private set => hp = value;
    }
}

class Dragon : Monster
{
    public Dragon(string name, int level, int hp)
    {
        Name = name;
        Level = level;
        Hp = hp;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }
    public int Level
    {
        get => level;
        private set => level = value;
    }
    public int Hp
    {
        get => hp;
        private set => hp = value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrangeMushroom orangeMushroom = new("주황버섯", 10, 100);
        Zombie zombie = new("좀비", 20, 300);
        Dragon dragon = new("드래곤", 30, 500);

        Console.WriteLine("\n몬스터 이름: " + orangeMushroom.Name);
        Console.WriteLine("몬스터 레벨: " + orangeMushroom.Level);
        Console.WriteLine("몬스터 체력: " + orangeMushroom.Hp);

        Console.WriteLine("\n몬스터 이름: " + zombie.Name);
        Console.WriteLine("몬스터 레벨: " + zombie.Level);
        Console.WriteLine("몬스터 체력: " + zombie.Hp);

        Console.WriteLine("\n몬스터 이름: " + dragon.Name);
        Console.WriteLine("몬스터 레벨: " + dragon.Level);
        Console.WriteLine("몬스터 체력: " + dragon.Hp);
    }
}



