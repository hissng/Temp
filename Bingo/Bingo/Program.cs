using System;
Random rd = new();

string input;
int[] computerBingoArray = new int[25];
int[] playerBingoArray = new int[25];

for(int i = 0; i < 25; i++)
{
    computerBingoArray[i] = i + 1;
    playerBingoArray[i] = i + 1;
}


Console.Write("빙고게임");
Console.Write("\n\n컴퓨터보다 빠르게 3줄 빙고를 완성하세요.");
Console.Write("\n\n아무 키나 입력하여 게임을 시작하세요...");
input = Console.ReadLine();

while(true)
{
    Console.Clear();
    Console.Write("<게임 시작>");
    ShuffleArray(computerBingoArray, 1000);
    ShuffleArray(playerBingoArray, 1000);
}

void ShuffleArray(int[] array, int shuffleTimes)
{
    for (int i = 0; i < shuffleTimes; i++)
    {
        int firstNum = rd.Next(0, array.Length);
        int secondNum = rd.Next(0, array.Length);

        (array[firstNum], array[secondNum]) = (array[secondNum], array[firstNum]);
    }
}

void PrintBingoTable()
{
    Console.WriteLine("    플레이어 빙고판    " + "        " + "    컴퓨터 빙고판    ");
    for (int i = 0; i <= 20; i += 5)
    {
        Console.WriteLine($"{playerBingoArray[0+i]}  {playerBingoArray[1+i]}  {playerBingoArray[2+i]}  {playerBingoArray[3+i]}  {playerBingoArray[4+i]}" +
          "        " + $"{computerBingoArray[0 + i]}  {computerBingoArray[1 + i]}  {computerBingoArray[2 + i]}  {computerBingoArray[3 + i]}  {computerBingoArray[4 + i]}");
    }
    
}
