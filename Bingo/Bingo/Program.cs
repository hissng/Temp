using System;
Random rd = new();

string input;
string[] computerBingoArray = new string[25];
string[] playerBingoArray = new string[25];

string[] computerBingoCheckArray = new string[25];
string[] playerBingoCheckArray = new string[25];

int computerBingoNum;
int playerBingoNum;

int rowAndColumn;
int row;
int column;
int computerCheckedNum;

Console.Write("빙고게임");
Console.Write("\n\n컴퓨터보다 빠르게 3줄 빙고를 완성하세요.");
Console.Write("\n\n아무 키나 입력하여 게임을 시작하세요...");
Console.Write("\n\n\n\n입력: ");
input = Console.ReadLine();

while(true)
{
    Reset();
    ShuffleArray(computerBingoArray, 1000);
    ShuffleArray(playerBingoArray, 1000);
    while(true)
    {
        Console.Clear();
        Console.Write("<게임 시작>");
        ShowBingoTable();
        Console.Write("\n\n체크할 칸을 고릅니다.");
        Console.Write("\n\n행, 열 순으로 숫자를 입력하세요. (예: 2번째 줄의 4번째 칸: 24)");
        Console.Write("\n\n\n\n입력: ");

        if (int.TryParse(Console.ReadLine(), out rowAndColumn) && 11 <= rowAndColumn && rowAndColumn < 56) // 입력값이 숫자고, 두자리 숫자면
        {
            input = rowAndColumn.ToString();
            row = int.Parse(input.Substring(0, 1));
            column = int.Parse(input.Substring(1, 1));
            if(1 > row || row > 5 || 1 > column || column > 5 || playerBingoCheckArray[(row - 1) * 5 + (column - 1)] == "V")  // 열과 행이 1미만 혹은 5초과거나 중복이면
            {
                InputErrorMessage();
                continue;
            }
        }
        else
        {
            InputErrorMessage();
            continue;
        }
        

        Console.Write($"\n\n{row}번째 줄의 {column}번째 칸을 체크합니다.");
        playerBingoNum = BingoCheck(playerBingoArray, playerBingoCheckArray, (row - 1) * 5 + (column - 1));
        Thread.Sleep(2000);

        Console.Write("\n\n컴퓨터도 랜덤으로 체크합니다.");
        computerCheckedNum = ComputerRandomSelect();
        computerBingoNum = BingoCheck(computerBingoArray, computerBingoCheckArray, computerCheckedNum);
        Thread.Sleep(2000);

        Console.Write($"\n\n현재까지 플레이어의 빙고 숫자는 {playerBingoNum}개,");
        Console.Write($"\n컴퓨터의 빙고 숫자는 {computerBingoNum}개 입니다.");

        if(playerBingoNum >= 3)  // 승리
        {
            Console.Write("\n\n축하합니다! 승리하셨습니다.");
            Console.Write("\n\n아무 키나 입력하여 다시시작하기...");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            break;
        }
        else if(computerBingoNum >= 3)  // 패배
        {
            Console.Write("\n\n컴퓨터가 먼저 3빙고를 달성하였습니다. 게임오버.");
            Console.Write("\n\n아무 키나 입력하여 다시시작하기...");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            break;
        }

        Console.Write("\n\n아무 키나 입력하여 다음 턴으로 넘어가세요...");
        Console.Write("\n\n\n\n입력: ");
        input = Console.ReadLine();

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

void ShowBingoTable()
{
    Console.WriteLine("\n\n  플레이어 빙고판  " + "        " + "  컴퓨터 빙고판  ");
    for (int i = 0; i <= 20; i += 5)
    {
        Console.WriteLine($"\n{playerBingoArray[0 + i]}  {playerBingoArray[1 + i]}  {playerBingoArray[2 + i]}  {playerBingoArray[3 + i]}  {playerBingoArray[4 + i]}" +
          "        " + $"{computerBingoArray[0 + i]}  {computerBingoArray[1 + i]}  {computerBingoArray[2 + i]}  {computerBingoArray[3 + i]}  {computerBingoArray[4 + i]}");
    }
}

void InputErrorMessage()
{
    Console.Write("\n\n잘못된 값을 입력하셨습니다. 입력조건을 다시 확인하세요.");
    Console.Write("\n\n아무 키나 입력하여 돌아갑니다...");
    input = Console.ReadLine();
}

int ComputerRandomSelect()
{
    int result;
    while(true)
    {
        result = rd.Next(computerBingoCheckArray.Length);
        if (computerBingoCheckArray[result] == "V")
        {
            continue;
        }
        else return result;
    }
    
}

int BingoCheck(string[] array, string[] checkArray, int arrayNum)
{
    int bingoNum = 0;
    array[arrayNum] += "V";
    checkArray[arrayNum] = "V";
    for(int i = 0; i < 25; i+=5) 
    {
        if (checkArray[i + 0] == "V" && checkArray[i + 1] == "V" && checkArray[i + 2] == "V" && checkArray[i + 3] == "V" && checkArray[i + 4] == "V")
        {
            bingoNum++;  // row 빙고
        }
    }

    for (int i = 0; i < 5; i++)
    {
        if (checkArray[i + 0] == "V" && checkArray[i + 5] == "V" && checkArray[i + 10] == "V" && checkArray[i + 15] == "V" && checkArray[i + 20] == "V")
        {
            bingoNum++;  // column 빙고
        }

    }

    if (checkArray[4] == "V" && checkArray[8] == "V" && checkArray[12] == "V" && checkArray[16] == "V" && checkArray[20] == "V")
    {
        bingoNum++;  // 오 → 왼 대각선 빙고
    }
    if (checkArray[0] == "V" && checkArray[6] == "V" && checkArray[12] == "V" && checkArray[18] == "V" && checkArray[24] == "V")
    {
        bingoNum++;  // 왼 → 오 대각선 빙고
    }

    return bingoNum;
}

void Reset()
{
    for (int i = 0; i < 25; i++)
    {
        if (i + 1 < 10)
        {
            computerBingoArray[i] = "0" + (i + 1).ToString();
            playerBingoArray[i] = "0" + (i + 1).ToString();
        }
        else
        {
            computerBingoArray[i] = (i + 1).ToString();
            playerBingoArray[i] = (i + 1).ToString();
        }
        computerBingoCheckArray[i] = "";
        playerBingoCheckArray[i] = "";
    }

    computerBingoNum = 0;
    playerBingoNum = 0;
}

