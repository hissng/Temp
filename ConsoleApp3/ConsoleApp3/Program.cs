using System;

Random rd = new Random();
string input = "";
string[] playerChoice = {"", "", ""};
string[] computerChoice = { "", "", "" };
int attempt = 1;
int strike = 0;
int ball = 0;
int _out = 0;

List<List<string>> lastResult = new List<List<string>>();


Console.Write("숫자야구 게임");
Console.Write("\n\n<게임 방법>");
Console.Write("\n    1. 3~4자리의 숫자를 임의로 정한 뒤, 서로에게 3~4자리의 숫자를 불러서 결과를 확인한다.");
Console.Write("\n    2. 그 결과를 토대로 상대가 적은 숫자를 예상한 뒤 맞힌다.");
Console.Write("\n    3. 사용되는 숫자는 0에서 9까지 서로 다른 숫자이다.");
Console.Write("\n    4. 숫자는 맞지만 위치가 틀렸을 때는 볼(B).");
Console.Write("\n    5. 숫자와 위치가 전부 맞으면 스트라이크(S).");
Console.Write("\n    6. 숫자와 위치가 전부 틀리면 아웃(OUT).");
Console.Write("\n    7. 5번의 기회안에 3S를 달성하면 승리.");
Console.Write("\n\n\n\n\n\n시작하려면 아무 키나 입력하세요.");
Console.Write("\n\n\n\n입력: ");
input = Console.ReadLine();

while(true)
{
    attempt = 1;
    ball = 0;
    strike = 0;
    _out = 0;
    lastResult.Clear();
    computerChoice = ComputerChoice();
    while (true)
    {
        Console.Clear();
        Console.Write("\n\n<숫자야구 게임: 게임 시작>");
        Console.Write("\n\n\n\n    방금 컴퓨터가 0~9의 숫자 중 임의의 숫자를 정했습니다.");
        Console.WriteLine("컴퓨터 선택: " + computerChoice[0]);
        Console.WriteLine("컴퓨터 선택: " + computerChoice[1]);
        Console.WriteLine("컴퓨터 선택: " + computerChoice[2]);
        Console.Write("\n    0~9의 숫자 중 3개의 숫자를 차례대로 입력하세요.");
        Console.Write("\n    예시: 0, 1, 2 라면 012 입력.");
        Console.Write("\n\n{0}/5번째 시도. ", attempt);
        playerChoice = PlayerChoice();
        BSOCalc(computerChoice, playerChoice);
        ResultCalc();

        Console.Clear();
        Console.Write("\n\n<숫자야구 게임: {0}/5번째 시도 결과>", attempt);
        Console.Write("\n\n\n\n        {0} 볼", lastResult[attempt - 1][0]);
        Console.Write("\n        {0} 스트라이크", lastResult[attempt - 1][1]);
        Console.Write("\n        {0} 아웃", _out);

        if(strike == 3)  // 게임 승리
        {
            Console.Write("\n\n{0}/5번째 시도만에 3스트라이크 달성, 플레이어 승리!", attempt);
            Console.Write("\n\n\n<최종 결과>");
            ResultPrint();
            Console.Write("\n\n다시 플레이하려면 아무 키나 입력하세요.");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            break;
        }
  
        else if(attempt == 5)  // 게임 패배
        {
            Console.Write("\n\n{0}/5번째 시도에도 3스트라이크 달성 실패, 플레이어 패배!", attempt);
            Console.Write("\n\n\n<최종 결과>");
            ResultPrint();
            Console.Write("\n\n다시 플레이하려면 아무 키나 입력하세요.");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            break;
        }

        else
        {
            attempt++;
            Console.Write("\n\n다음 {0}/5번째 시도로 계속하려면 아무 키나 입력하세요.", attempt);
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
        }
    }
    
}

void BSOCalc(string[] computerArray, string[] playerArray)
{
    for(int i = 0; i < computerArray.Length; i++)
    {
        for (int j = 0; j < playerArray.Length; j++)
        {
            if (computerArray[i] != playerArray[j])
            {
                if(i+1 == computerArray.Length && j+1 == playerArray.Length)  // 다 돌렸는데도 다 다르면
                {
                    if(strike == 0 && ball == 0)
                    {
                        _out++;
                    }
                    break;
                }
                continue;
            }
            else if (computerArray[i] == playerArray[j])  // 같은 숫자가 하나라도 있으면
            {
                if(i == j)  // 근데 자릿수까지 똑같으면
                {
                    strike++;
                    break;
                }
                else  // 자릿수는 다르면
                {
                    ball++;
                    break;
                }
            }
        }
    }
}


string[] PlayerChoice()
{
    string choice;
    string[] splitedChoice = { "", "", "" };

    while(true)
    {
        try
        {
            Console.Write("\n\n\n\n입력: ");
            choice = Console.ReadLine();

            if(choice.Length == 3)
            {
                splitedChoice = SplitStringByLength(choice, splitedChoice.Length);
                for (int i = 0; i < splitedChoice.Length; i++)
                {
                    if (0 <= int.Parse(splitedChoice[i]) && int.Parse(splitedChoice[i]) < 10)
                    {
                        if (i == 2)
                        {
                            return splitedChoice;
                        }
                    }
                    else  // 입력값이 숫자가 아니라면
                    {
                        InputErrorMessage();
                        continue;
                    }
                }
            }

            else  // 입력값이 3자리가 아니라면
            {
                InputErrorMessage();
                continue;
            }
        }
        catch
        {
            InputErrorMessage();
            continue;
        }
        
    }
}

string[] ComputerChoice()
{
    string[] choice = { "", "", "" };
    for(int i = 0; i < 3; i++)  // 3자리를 만든다
    {
        choice[i] = rd.Next(0, 10).ToString();
        for (int j = 0; j < i; j++)  // 기존에 만든 만큼 검사
        {
            if (choice[i] != choice[j])  // 기존에 만든 거랑 다르면 통과
            {
                continue;
            }
            else  // 기존에 만든 거랑 같으면 다시 랜덤값 삽입
            {
                i--;
                break;
            }
        }
    }
    
    return choice;
}

string[] SplitStringByLength(string s, int length)
{
    string[] result = new string[length];
    for(int i = 0; i < length; i++)
    {
        result[i] = s.Substring(i, 1);
    }
    return result;
}

void ResultCalc()
{
    List<string> BSOList = new List<string>();
    BSOList.Add(ball.ToString());
    BSOList.Add(strike.ToString());
    BSOList.Add(_out.ToString());
    lastResult.Add(BSOList);
    if(strike < 3)  // 3스트라이크 아니면 초기화
    {
        ball = 0;
        strike = 0;
    }
}

void ResultPrint()
{
    for (int i = 0; i < attempt; i++)
    {
        Console.Write("\n\n{0}번째 시도 결과: {1} 볼, {2} 스트라이크, {3} 아웃", 
            i+1, lastResult[i][0], lastResult[i][1], lastResult[i][2]);
    }
}

void InputErrorMessage()
{
    Console.Clear();
    Console.Write("\n\n잘못 입력하셨습니다.");
    Console.Write("\n0~9의 숫자 중 3개의 숫자를 차례대로 입력해야 합니다.");
    Console.Write("\n예시: 0, 1, 2 라면 012 입력.");
    Console.Write("\n아무 키나 입력하면 다시 돌아갑니다.");
    Console.Write("\n\n\n\n입력: ");
    input = Console.ReadLine();
}



