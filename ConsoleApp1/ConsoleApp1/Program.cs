using System;

Random rd = new Random();
string input = "";
int round = 1;
string playerOutput = "";
string computerOutput = "";
string result = "";
List<string> resultList = new List<string>();

Console.WriteLine("가위바위보 게임");
Console.WriteLine("\n\n\n\n\n\n\n시작하려면 아무 키나 입력하십시오.");
Console.WriteLine("\n\n\n입력: ");
input = Console.ReadLine();

while (true)
{
    Console.Clear();
    Console.WriteLine("가위바위보를 시작합니다.");
    Console.WriteLine("\n\n{0}라운드. 가위 바위 보!", round);
    Console.WriteLine("\n\n어떤 것을 낼지 선택하세요.");
    Console.WriteLine("\n\n1. 가위");
    Console.WriteLine("\n2. 바위");
    Console.WriteLine("\n3. 보");
    Console.WriteLine("\n\n\n입력: ");
    input = Console.ReadLine();

    if (input == "1" || input == "2" || input == "3")
    {
        playerOutput = PlayerOutput(input);
        computerOutput = ComputerOutput();
        result = RandomResult(playerOutput, computerOutput);
        Console.WriteLine("\n\n\n\n 플레이어의 선택: " + playerOutput);
        Console.WriteLine("\n 컴퓨터의 선택: " + computerOutput);
        Console.WriteLine("\n\n 이번 라운드는 " + result + "!!!");
        resultList.Add(result);
    }
    else
    {
        Console.WriteLine("\n잘못 입력했습니다. 다시 입력하세요.");
        Console.WriteLine("\n아무 키나 입력해서 다시하기: ");
        input = Console.ReadLine();
        continue;
    }

    if (round <= 2)
    {
        round++;
        Console.WriteLine("\n\n 이제 {0}번째 라운드가 시작됩니다.", round);
        Console.WriteLine("\n아무 키나 입력해서 시작하기: ");
        input = Console.ReadLine();
    }
    else
    {
        Console.WriteLine("\n\n 게임 끝! 최종 결과는: ");
        Console.WriteLine("\n\n ");
        for (int i = 0; i < round; i++)
        {
            Console.WriteLine(resultList[i]);
        }
        Console.WriteLine("\n\n 다시 시작하려면 아무 키나 입력하세요: ");
        input = Console.ReadLine();
        round = 1;
        resultList.Clear();
    }

}


string RandomResult(string playerInput, string computerOutput)
{
    if (playerInput == computerOutput)
    {
        return "무승부";
    }

    if (playerInput == "가위")
    {
        if (computerOutput == "보")
        {
            return "승";
        }
        else if (computerOutput == "바위")
        {
            return "패";
        }
    }

    else if (playerInput == "바위")
    {
        if (computerOutput == "가위")
        {
            return "승";
        }
        else if (computerOutput == "보")
        {
            return "패";
        }
    }

    else if (playerInput == "보")
    {
        if (computerOutput == "바위")
        {
            return "승";
        }
        else if (computerOutput == "가위")
        {
            return "패";
        }
    }
    return "RandomResult Error";

}

string PlayerOutput(string playerInput)
{
    if (playerInput == "1")
    {
        return "가위";
    }
    else if (playerInput == "2")
    {
        return "바위";
    }
    else if (playerInput == "3")
    {
        return "보";
    }
    else
    {
        return "PlayerOutput Error";
    }
}

string ComputerOutput()
{
    int output = rd.Next(1, 4);

    if (output == 1)
    {
        return "가위";
    }
    else if (output == 2)
    {
        return "바위";
    }
    else if (output == 3)
    {
        return "보";
    }
    return "ComputerOutput Error";
}

