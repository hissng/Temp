class Program
{
    static void Main(string[] args)
    {
        Monster orangeMushroom = new Monster();
        orangeMushroom.name = "주황버섯";
        orangeMushroom.level = 10;
        orangeMushroom.hp = 100;
        
        Monster blueMushroom = new Monster();
        blueMushroom.name = "파란버섯";
        blueMushroom.level = 20;
        blueMushroom.hp = 300
            ;
        Monster zombieMushroom = new Monster();
        zombieMushroom.name = "좀비버섯";
        zombieMushroom.level = 30;
        zombieMushroom.hp = 500;
        
        PrintMonster(orangeMushroom);
        PrintMonster(blueMushroom);
        PrintMonster(zombieMushroom);
        
    }

    static void PrintMonster(Monster monster)
    {
        Console.WriteLine("\n몬스터 이름: " + monster.name);
        Console.WriteLine("몬스터 레벨: " + monster.level);
        Console.WriteLine("몬스터 체력: " + monster.hp);
    }
    

    

}

class Monster
{
    public string name = "";
    public int level = 0;
    public int hp = 0;
}

