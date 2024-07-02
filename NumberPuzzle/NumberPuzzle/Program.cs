using System;
Random rd = new();

string input;
string[] numberArray = new string[25];
string[] victoryArray = new string[25];

int playerArrayNumber;
bool isVictory = false;

ConsoleKeyInfo key;

Console.Write("숫자 퍼즐게임");
Console.Write("\n\n랜덤하게 생성된 5x5 숫자테이블을 순서에 맞게 완성시키세요.");
Console.Write("\n\n키보드 화살표를 이용해 이동할 수 있습니다.");
Console.Write("\n\n아무 키나 입력하여 게임을 시작하세요...");
Console.Write("\n\n\n\n입력: ");
input = Console.ReadLine();

while (true)
{
    Reset();
    ShuffleArray(numberArray, 1000);
    playerArrayNumber = 0;

    while (true)
    {
        Console.Clear();
        Console.Write("<게임 시작>");
        ShowTable();
        Console.Write($"\n\n플레이어의 숫자는 {numberArray[playerArrayNumber]} 입니다.");
        Console.Write("\n\n키보드 화살표를 이용해 이동하세요.");
        
        key = Console.ReadKey(true);

        if(key.Key == ConsoleKey.LeftArrow)
        {
            if(playerArrayNumber != 0 && playerArrayNumber != 5 && playerArrayNumber != 10 && playerArrayNumber != 15 && playerArrayNumber != 20)
            {
                (numberArray[playerArrayNumber - 1], numberArray[playerArrayNumber]) = (numberArray[playerArrayNumber], numberArray[playerArrayNumber - 1]);
                playerArrayNumber--;
                continue;
            }
        }
        else if (key.Key == ConsoleKey.RightArrow)
        {
            if (playerArrayNumber != 4 && playerArrayNumber != 9 && playerArrayNumber != 14 && playerArrayNumber != 19 && playerArrayNumber != 24)
            {
                (numberArray[playerArrayNumber + 1], numberArray[playerArrayNumber]) = (numberArray[playerArrayNumber], numberArray[playerArrayNumber + 1]);
                playerArrayNumber++;
                continue;
            }
        }
        else if (key.Key == ConsoleKey.UpArrow)
        {
            if (playerArrayNumber != 0 && playerArrayNumber != 1 && playerArrayNumber != 2 && playerArrayNumber != 3 && playerArrayNumber != 4)
            {
                (numberArray[playerArrayNumber - 5], numberArray[playerArrayNumber]) = (numberArray[playerArrayNumber], numberArray[playerArrayNumber - 5]);
                playerArrayNumber -= 5;
                continue;
            }
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            if (playerArrayNumber != 20 && playerArrayNumber != 21 && playerArrayNumber != 22 && playerArrayNumber != 23 && playerArrayNumber != 24)
            {
                (numberArray[playerArrayNumber + 5], numberArray[playerArrayNumber]) = (numberArray[playerArrayNumber], numberArray[playerArrayNumber + 5]);
                playerArrayNumber += 5;
                continue;
            }
        }

        for(int i = 0; i < numberArray.Length; i++)
        {
            if(numberArray[i] == victoryArray[i])
            {
                isVictory = true;
            }
            else
            {
                isVictory = false;
                break;
            }
        }

        if(isVictory)
        {
            Console.WriteLine("게임 승리!");
            Console.Write("\n\n아무 키나 입력하여 다시 시작하기...");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            break;
        }
    }
}

void ShuffleArray(string[] array, int shuffleTimes)
{
    for (int i = 0; i < shuffleTimes; i++)
    {
        int firstNum = rd.Next(0, array.Length);
        int secondNum = rd.Next(0, array.Length);

        (array[firstNum], array[secondNum]) = (array[secondNum], array[firstNum]);
    }
}

void ShowTable()
{
    Console.WriteLine("\n\n");
    for (int i = 0; i <= 20; i += 5)
    {
        Console.WriteLine($"{numberArray[0 + i]}  {numberArray[1 + i]}  {numberArray[2 + i]}  {numberArray[3 + i]}  {numberArray[4 + i]}");
    }
}

void Reset()
{
    for (int i = 0; i < 25; i++)
    {
        if (i + 1 < 10)
        {
            numberArray[i] = "0" + (i + 1).ToString();
            victoryArray[i] = "0" + (i + 1).ToString();
        }
        else
        {
            numberArray[i] = (i + 1).ToString();
            victoryArray[i] = (i + 1).ToString();
        }
    }
}

