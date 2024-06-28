using System;

Random rd = new Random();
string input1 = "";
string input2 = "";
int attempt = 1;
string[] playerChoice;
string[] computerChoice;
int strike = 0;
int ball = 0;
int _out = 0;


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
input1 = Console.ReadLine();

while(true)
{
    computerChoice = ComputerChoice();
    while (true)
    {
        Console.Clear();
        Console.Write("\n\n<숫자야구 게임: 게임 시작>");
        Console.Write("\n\n\n\n    방금 컴퓨터가 0~9의 숫자 중 임의의 숫자를 정했습니다.");
        Console.Write("\n    0~9의 숫자 중 3개의 숫자를 차례대로 입력하세요.");
        Console.Write("\n    예시: 0, 1, 2 라면 012 입력.");
        Console.Write("\n\n{0}/5번째 시도. ", attempt);
        playerChoice = PlayerChoice();
        SBOCalc(computerChoice, playerChoice);

        Console.Clear();
        Console.Write("\n\n<숫자야구 게임: {0}/5번째 시도 결과>", attempt);
        Console.Write("\n\n\n\n현재까지 {0} 볼", ball);
        Console.Write("\n        {0} 스트라이크", strike);
        Console.Write("\n        {0} 아웃", _out);

        if(strike == 3)  // 게임 승리
        {
            Console.Write("\n\n{0}/5번째 시도만에 3스트라이크 달성, 플레이어 승리!", attempt);
            Console.Write("\n\n다시 플레이하려면 아무 키나 입력하세요.");
            Console.Write("\n\n\n\n입력: ");
            input1 = Console.ReadLine();
            break;
        }
  
        else if(attempt == 5)
        {

        }
        else
        {
            attempt++;
            Console.Write("\n\n다음 {0}/5번째 시도로 계속하려면 아무 키나 입력하세요.", attempt);
            Console.Write("\n\n\n\n입력: ");
            input1 = Console.ReadLine();
        }
    }
    

    

    
}

void SBOCalc(string[] comparison_A, string[] comparison_B)
{
    for(int i = 0; i < comparison_A.Length; i++)
    {
        for (int j = 0; j < comparison_B.Length; j++)
        {
            if (comparison_A[i] != comparison_B[j])
            {
                if(i+1 == comparison_A.Length && j+1 == comparison_B.Length)  // 다 돌렸는데도 다 다르면
                {
                    _out++;
                    break;
                }
                continue;
            }
            else if (comparison_B[i] == comparison_A[j])  // 같은 숫자가 하나라도 있으면
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
    string[] splitedChoice;

    while(true)
    {
        Console.Write("\n\n\n\n입력: ");
        choice = Console.ReadLine();

        splitedChoice = choice.Split("");

        if (splitedChoice.Length == 3)
        {
            for (int i = 0; i < splitedChoice.Length; i++)
            {
                if (0 <= int.Parse(splitedChoice[i]) && int.Parse(splitedChoice[i]) < 10)
                {
                    if(i == 2)
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
}

string[] ComputerChoice()
{
    string[] choice = null;
    for(int i = 0; i < 3; i++)  // 3자리를 만든다
    {
        choice[i] = rd.Next(0, 10).ToString();
        for (int j = 0; j < choice.Length-1; j++)  // 기존에 만든 만큼 검사
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

string GameSetting_Jaritsu(string choice)
{
    while (true)
    {
        Console.Clear();
        Console.Write("\n\n<게임 시작 전>");
        Console.Write("\n게임 설정을 시작합시다.");
        Console.Write("\n자릿수를 선택하세요. 입력 칸에 원하는 번호를 입력하세요.");
        Console.Write("\n\n    1. 3자리 (보통)");
        Console.Write("\n\n    2. 4자리 (어려움)");
        Console.Write("\n\n    3. 5자리 (매우 어려움)");
        Console.Write("\n\n\n\n입력: ");
        choice = Console.ReadLine();

        if(choice == "1"||choice == "2"||choice == "3")
        {
            return choice;
        }    
        else
        {
            InputErrorMessage();
            continue;
        }
    }
}

void InputErrorMessage()
{
    Console.Clear();
    Console.Write("\n\n잘못 입력하셨습니다.");
    Console.Write("\n아무 키나 입력하면 다시 돌아갑니다.");
    Console.Write("\n\n\n\n입력: ");
    input1 = Console.ReadLine();
}

