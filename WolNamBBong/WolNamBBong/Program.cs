
using System;

Random rd = new();
string input = "";
int money = 0;
float victoryMultiple = 0;
int playerCardNum = 0;
int[] cardsArray = new int[52];
int[] shuffledCardsArray = new int[52];
for (int i = 0; i < cardsArray.Length; i++)  // 카드 배열에 값 부여
{
    cardsArray[i] = i;
    shuffledCardsArray[i] = i;
}
int initBetMoney = 0;
int secondBetMoney = 0;
int allBetMoney = 0;
int firstCardOrder = -3;
int secondCardOrder = -2;
int playerCardOrder = -1;
bool isPair = false;

Console.Write("\n레드독(월남뽕) 게임");
Console.Write("\n\n<게임 규칙>");
Console.Write("\n\n    1. 먼저 기본 베팅을 한다.");
Console.Write("\n    2. 베팅 후 두 장의 카드가 공개된다.");
Console.Write("\n    3. 플레이어는 한 장의 카드를 받는다. (이때 플레이어는 카드를 알지 못한다)");
Console.Write("\n    4. 베팅을 확대하거나 유지한다.");
Console.Write("\n    5. 플레이어의 카드 숫자가 앞서 공개된 두 장의 카드 숫자 사이에 있으면 플레이어 승리로 설정된 배수를 받는다.");
Console.Write("\n    6. 숫자 사이에 없으면 플레이어 패배로 베팅금액을 잃는다.");
Console.Write("\n      ※ 제로 스프레드: 앞서 공개한 두 장의 카드 숫자의 중간이 없으면(연속된 숫자면) 게임을 다시 시작한다.");
Console.Write("\n      ※ 페어: 두 장의 카드 숫자가 같고, 플레이어 카드 숫자까지 같으면, 플레이어는 베팅금액의 11배를 받는다.");
Console.Write("\n      ※       틀리면 다시 시작한다.");
Console.Write("\n\n계속하려면 아무 키나 누르세요...");
Console.Write("\n\n\n\n입력: ");
input = Console.ReadLine();

while (true)
{
    Console.Clear();
    Reset();
    Console.Write("\n\n<난이도 설정하기>");
    Console.Write("\n\n난이도를 설정하세요. 원하는 난이도의 번호를 입력하세요.");
    Console.Write("\n\n    1. 기본금액: 20,000원  /  승리배수: 2배 (쉬움)");
    Console.Write("\n    2. 기본금액: 10,000원  /  승리배수: 1.5배 (보통)");
    Console.Write("\n    3. 기본금액: 5,000원  /  승리배수: 1.2배 (어려움)");
    Console.Write("\n\n\n\n입력: ");
    input = Console.ReadLine();
    if (input == "1")
    {
        money = 20000;
        victoryMultiple = 2.0f;
    }
    else if (input == "2")
    {
        money = 10000;
        victoryMultiple = 1.5f;
    }
    else if (input == "3")
    {
        money = 5000;
        victoryMultiple = 1.2f;
    }
    else
    {
        InputErrorMessage();
        continue;
    }

    while (true)
    {
        Console.Clear();
        firstCardOrder += 3;
        secondCardOrder += 3;
        playerCardOrder += 3;
        Console.Write("\n\n<게임 시작>");
        Console.Write($"\n\n먼저 기본 베팅을 시작합니다. 베팅 금액을 적으세요. (현재 소유금액: {money})");
        Console.Write("\n\n\n\n입력: ");

        if (!int.TryParse(Console.ReadLine(), out initBetMoney) || initBetMoney > money)  // 입력값이 소유금액보다 크거나, 숫자가 아니라면
        {
            InputErrorMessage();
            continue;
        }

        Console.Clear();
        Console.Write("\n\n이제 딜러가 무작위로 두 장의 카드를 공개합니다. 두 장의 카드는 다음과 같습니다.");
        ShuffleCards();
        OrderCardNum(shuffledCardsArray, firstCardOrder, 2);

        Console.Write("\n\n     - " + ReturnCardName(shuffledCardsArray[firstCardOrder]));
        Console.Write("\n     - " + ReturnCardName(shuffledCardsArray[secondCardOrder]));

        Thread.Sleep(2000);
        if ((shuffledCardsArray[firstCardOrder] % 13) + 1 == (shuffledCardsArray[secondCardOrder] % 13))  // 둘이 연속된 숫자라면: 제로 스프레드
        {
            Console.Write("\n\n제로 스프레드 입니다! 규칙에 따라 게임을 다시 시작합니다.");
            Console.Write("\n\n아무 키나 입력하여 다시 시작하세요.");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            continue;
        }

        else if ((shuffledCardsArray[firstCardOrder] % 13) == (shuffledCardsArray[secondCardOrder] % 13))  // 둘이 같은 숫자라면: 페어
        {
            Console.Write("\n\n페어 입니다! 플레이어의 카드 숫자와 같으면 베팅금액의 11배를 얻습니다.");
            Console.Write("\n\n플레이어 카드 숫자가 다르면 게임을 다시 시작합니다.");
            isPair = true;
            Thread.Sleep(3000);
        }

        playerCardNum = shuffledCardsArray[playerCardOrder];
        while (true)
        {
            Console.Clear();
            Console.Write("\n\n앞서 공개된 두 장의 카드는 다음과 같습니다.");
            Console.Write("\n\n     - " + ReturnCardName(shuffledCardsArray[firstCardOrder]));
            Console.Write("\n     - " + ReturnCardName(shuffledCardsArray[secondCardOrder]));
            Console.Write("\n\n방금 플레이어에게 한 장의 카드를 건넸습니다.");
            Console.Write("\n\n추가 베팅을 시작합니다. 베팅 금액을 적으세요.");
            Console.Write("\n\n\n\n입력: ");

            if (!int.TryParse(Console.ReadLine(), out secondBetMoney) || initBetMoney + secondBetMoney > money)  // 입력값이 소유금액보다 크거나, 숫자가 아니라면
            {
                InputErrorMessage();
                continue;
            }

            allBetMoney = initBetMoney + secondBetMoney;
            Console.Write($"\n\n베팅이 끝났습니다. 총 베팅 금액은 {allBetMoney} 입니다. ");
            break;
        }
        Console.Clear();
        Console.Write("\n\n앞서 공개된 두 장의 카드는 다음과 같습니다.");
        Console.Write("\n\n     - " + ReturnCardName(shuffledCardsArray[firstCardOrder]));
        Console.Write("\n     - " + ReturnCardName(shuffledCardsArray[secondCardOrder]));
        Console.Write("\n\n플레이어가 받은 카드를 공개합니다.");
        Console.Write("\n\n플레이어의 카드는...");
        Thread.Sleep(3000);
        Console.Write("\n\n     - " + ReturnCardName(playerCardNum) + " 입니다.");

        if (isPair)
        {
            if (playerCardNum % 13 == shuffledCardsArray[firstCardOrder] % 13)
            {
                Console.Write("\n\n플레이어의 카드 숫자가 페어 카드와 같습니다!");
                Console.Write("\n\n총 베팅 금액의 11배를 지급합니다.");
                Console.Write($"\n\n지급 금액: {allBetMoney * 11}");
                Console.Write($"\n총 소유 자금: {money} + {allBetMoney * 11} = {money += allBetMoney * 11}");
                Console.Write("\n\n계속하려면 아무 키나 누르세요...");
                Console.Write("\n\n\n\n입력: ");
                input = Console.ReadLine();
                continue;
            }

            else
            {
                Console.Write("\n\n플레이어의 카드 숫자와 페어 카드가 다릅니다.");
                Console.Write("\n\n규칙에 따라 게임을 다시 시작합니다..");
                Console.Write("\n\n계속하려면 아무 키나 누르세요...");
                Console.Write("\n\n\n\n입력: ");
                input = Console.ReadLine();
                continue;
            }
        }


        if (shuffledCardsArray[firstCardOrder] % 13 < playerCardNum % 13 && playerCardNum % 13 < shuffledCardsArray[secondCardOrder] % 13)  // 플레이어 카드 숫자가 두 카드 숫자 사이에 있으면: 승리
        {
            Console.Write("\n\n플레이어의 카드 숫자가 두 카드 숫자 사이에 있습니다!");
            Console.Write($"\n\n플레이어 승리! 총 베팅 금액의 {victoryMultiple}배를 지급합니다.");
            Console.Write($"\n\n지급 금액: {Convert.ToInt32(allBetMoney * victoryMultiple)}");
            Console.Write($"\n총 소유 자금: {money} + {Convert.ToInt32(allBetMoney * victoryMultiple)} = {money += Convert.ToInt32(allBetMoney * victoryMultiple)}");

            if (playerCardOrder >= cardsArray.Length)  // 게임 오버: 카드 다씀
            {
                Console.Write("\n\n더이상 플레이할 수 있는 카드가 없습니다. 게임 끝!");
                Console.Write("\n\n게임을 다시 하려면 아무 키나 누르세요...");
                Console.Write("\n\n\n\n입력: ");
                input = Console.ReadLine();
                break;
            }

            Console.Write("\n\n계속하려면 아무 키나 누르세요...");
            Console.Write("\n\n\n\n입력: ");
            input = Console.ReadLine();
            continue;
        }

        else  // 그 외: 패배
        {
            Console.Write("\n\n플레이어의 카드 숫자가 두 카드 숫자 사이에 없습니다.");
            Console.Write($"\n\n플레이어 패배. 총 베팅 금액({allBetMoney})을 잃습니다.");
            Console.Write($"\n총 소유 자금: {money} - {allBetMoney} = {money -= allBetMoney}");
            if (money > 0)
            {
                Console.Write("\n\n계속하려면 아무 키나 누르세요...");
                Console.Write("\n\n\n\n입력: ");
                input = Console.ReadLine();
                continue;
            }
            else if (money <= 0)  // 게임 오버: 돈 없음
            {
                Console.Write("\n\n더이상 소유 자금이 없습니다. 게임오버.");
                Console.Write("\n\n게임을 다시 하려면 아무 키나 누르세요...");
                Console.Write("\n\n\n\n입력: ");
                input = Console.ReadLine();
                break;
            }
            else if (playerCardOrder >= cardsArray.Length)  // 게임 오버: 카드 다씀
            {
                Console.Write("\n\n더이상 플레이할 수 있는 카드가 없습니다. 게임 끝!");
                Console.Write("\n\n게임을 다시 하려면 아무 키나 누르세요...");
                Console.Write("\n\n\n\n입력: ");
                input = Console.ReadLine();
                break;
            }    
        }
    }
}


void ShuffleCards()
{
    int shuffleTimes = 1000;
    int firstNum = 0;
    int secondNum = 0;
    int tempNum = 0;

    for (int i = 0; i < shuffleTimes; i++)
    {
        firstNum = rd.Next(0, shuffledCardsArray.Length);
        secondNum = rd.Next(0, shuffledCardsArray.Length);
        tempNum = shuffledCardsArray[firstNum];
        shuffledCardsArray[firstNum] = shuffledCardsArray[secondNum];
        shuffledCardsArray[secondNum] = tempNum;
    }
}

void OrderCardNum(int[] cardArray, int start, int length)
{
    int tempNum = 0;

    for (int i = start; i < start + length; i++)
    {
        for (int j = start; j < start + length; j++)  // 작은 건 앞으로, 큰 건 뒤로 보내기
        {
            if (i < j && cardArray[i] % 13 > cardArray[j] % 13)
            {
                tempNum = cardArray[i];
                cardArray[i] = cardArray[j];
                cardArray[j] = tempNum;
            }
        }
    }
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

void Reset()
{
    money = 0;
    victoryMultiple = 0;
    playerCardNum = 0;
    cardsArray = new int[52];
    shuffledCardsArray = new int[52];
    for (int i = 0; i < cardsArray.Length; i++)  // 카드 배열에 값 부여
    {
        cardsArray[i] = i;
        shuffledCardsArray[i] = i;
    }
    initBetMoney = 0;
    secondBetMoney = 0;
    allBetMoney = 0;
    int firstCardOrder = 0;
    int secondCardOrder = 1;
    int playerCardOrder = 2;
    isPair = false;
}

void InputErrorMessage()
{
    Console.Write("\n\n잘못 입력하셨습니다. 입력 조건을 다시 확인하세요.");
    Console.Write("\n아무 키나 입력하면 다시 돌아갑니다.");
    Console.Write("\n\n\n\n입력: ");
    input = Console.ReadLine();
}
