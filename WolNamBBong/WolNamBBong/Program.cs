
using System;

Random rd = new();
string input = "";
int money = 0;
float victoryMultiple = 0;
int[] cardsArray = new int[52];
for (int i = 0; i < cardsArray.Length; i++)  // 카드 배열에 값 부여
{
    cardsArray[i] = i;
}
int[] twoCardsArray = new int[2];

Console.Write("\n레드독(월남뽕) 게임");
Console.Write("\n\n<게임 규칙>");
Console.Write("\n\n    1. 먼저 기본 베팅을 한다.");
Console.Write("\n    2. 베팅 후 두 장의 카드가 공개된다.");
Console.Write("\n    3. 플레이어는 한 장의 카드를 받는다.");
Console.Write("\n    4. 베팅을 확대하거나 유지한다.");
Console.Write("\n    5. 플레이어의 카드 숫자가 앞서 공개된 두 장의 카드 숫자 사이에 있으면 플레이어 승리로 설정된 배수를 받는다.");
Console.Write("\n    6. 숫자 사이에 없으면 플레이어 패배로 베팅금액을 잃는다.");
Console.Write("\n      ※ 제로 스프레드: 앞서 공개한 두 장의 카드 숫자의 중간이 없으면(연속된 숫자면) 게임을 다시 시작한다.");
Console.Write("\n      ※ 페어: 앞서 공개한 두 장의 카드 숫자가 같고, 플레이어 카드 숫자까지 같으면, 플레이어는 베팅금액의 11배를 받는다. 틀리면 다시 시작한다.");
Console.Write("\n\n계속하려면 아무 키나 누르세요...");
Console.Write("\n\n\n\n입력: ");
input = Console.ReadLine();

while(true)
{
    Console.Clear();
    Console.Write("\n\n<난이도 설정하기>");
    Console.Write("\n\n난이도를 설정하세요. 원하는 난이도의 번호를 입력하세요.");
    Console.Write("\n\n    1. 기본금액: 20,000원  /  승리배수: 2배 (쉬움)");
    Console.Write("\n    2. 기본금액: 10,000원  /  승리배수: 1.5배 (보통)");
    Console.Write("\n    3. 기본금액: 5,000원  /  승리배수: 1.2배 (어려움)");
    Console.Write("\n\n\n\n입력: ");
    input = Console.ReadLine();
    if(input == "1")
    {
        money = 20000;
        victoryMultiple = 2.0f;
    }
    else if(input == "2")
    {
        money = 10000;
        victoryMultiple = 1.5f;
    }
    else if(input == "3")
    {
        money = 5000;
        victoryMultiple = 1.2f;
    }
    else
    {
        InputErrorMessage();
        continue;
    }

    while(true)
    {
        Console.Write("\n\n<게임 시작>");
        Console.Write($"\n\n먼저 기본 베팅을 시작합니다. 베팅 금액을 적으세요. (현재 소유금액: {money}");
        Console.Write("\n\n\n\n입력: ");
        input = Console.ReadLine();

        Console.Write("\n\n이제 딜러가 무작위로 두 장의 카드를 공개합니다. 두 장의 카드는 다음과 같습니다.");
        twoCardsArray = ReturnRandomCards(2);
        Console.Write("\n\n     - " + ReturnCardName(twoCardsArray[0]));
        Console.Write("\n     - " + ReturnCardName(twoCardsArray[1]));

        Console.Write("\n\n방금 플레이어에게 한 장의 카드를 건넸습니다.");

        Console.Write("\n\n\n\n입력: ");
        input = Console.ReadLine();

    }

}

int[] ReturnRandomCards(int cardsAmount)
{
    int[] valuesForRandom = cardsArray;
    int shuffleTimes = 1000;
    int firstNum = 0;
    int secondNum = 0;
    int tempNum = 0;
    int[] result = new int[cardsAmount];
    
    for(int i = 0; i < shuffleTimes; i++)
    {
        firstNum = rd.Next(0, valuesForRandom.Length);
        secondNum = rd.Next(0, valuesForRandom.Length);
        tempNum = valuesForRandom[firstNum];
        valuesForRandom[firstNum] = valuesForRandom[secondNum];
        valuesForRandom[secondNum] = tempNum;
    }

    for(int i = 0; i < result.Length; i++)
    {
        result[i] = valuesForRandom[i];
    }

    return result;
}

string ReturnCardName(int cardNumber)
{
    string cardType = "";
    string cardNum = "";
    string result = "";

    if (cardNumber / 13 == 0) cardType = "♣ 클로버";
    else if (cardNumber / 13 == 1) cardType = "♥ 하트";
    else if (cardNumber / 13 == 2) cardType = "◆ 다이아";
    else if (cardNumber / 13 == 3) cardType = "♠ 스페이드";

    cardNum = (cardNumber % 13 + 1).ToString();
    if (cardNum == "1") cardNum = "A";
    else if (cardNum == "11") cardNum = "J";
    else if (cardNum == "12") cardNum = "Q";
    else if (cardNum == "13") cardNum = "K";

    result = cardType + " " + cardNum;
    return result;
}

void InputErrorMessage()
{
    Console.Write("\n\n잘못 입력하셨습니다. 입력 조건을 다시 확인하세요.");
    Console.Write("\n아무 키나 입력하면 다시 돌아갑니다.");
    Console.Write("\n\n\n\n입력: ");
    input = Console.ReadLine();
}
