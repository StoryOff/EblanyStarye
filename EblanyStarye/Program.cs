//инициализация переменных, тут не важно
int RoundCount = 0;
int SuccessCount = 0;
int FailCount = 0;
double SuccessChance;

//коробка 1 полностью верная, 2 наполовину верная, 3 полностю неверная. Их индексы 0/1/2
List<List<int>> Balls = new List<List<int>>
{
  new List<int> { 1, 1 },
  new List<int> { 1, 0 },
  new List<int> { 0, 0 },
};

//запускаем бесконечный цикл выбора
ChooseBox();


void ChooseBox()
{
    //инициализация переменных, тут не важно
    Random rnd = new Random();
    int randBoxNumber;
    int randBallNumber;


    // запуск бесконечного цикла
    while (true)
    {
        //выбираем рандом число от 0 до 2 (ошибки тут нет, в скобках 3 должно быть), обозначающее выбор коробки
        randBoxNumber = rnd.Next(3);

        //выбираем рандом число от 0 до 1 обозначающее выбор шара в коробке.
        randBallNumber = rnd.Next(2);

        //если вытащенный шар верен, добавляем плюс к раундам
        if (Balls[randBoxNumber][randBallNumber] == 1)
        {
            RoundCount++;
        }
        //если не верен, пропускаем эту итерацию и переходим к следующей
        else continue;

        //если выбралась коробка с 2мя верными шарами, то добавляем +1 к победе
        if (Balls[randBoxNumber][0] == 1 && Balls[randBoxNumber][1] == 1)
        {
            SuccessCount++;
        }

        //если оба шара не верны, добавляем +1 к поражению
        else
        {
            FailCount++;
        }

        //рассчитываем шанс
        SuccessChance = (double)SuccessCount / (double)RoundCount * 100;

        //тут просто логируем инфу для отображения, не важно уже что там
        LogInfo();
    }
}

void LogInfo()
{
    Console.WriteLine(BuildMessage());
}

string BuildMessage()
{
    return $"Total rounds: {RoundCount}. Success rounds: {SuccessCount}. Fail rounds: {FailCount}. Succsess Rate: {SuccessChance}%";
}

