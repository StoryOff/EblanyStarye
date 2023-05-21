//инициализация переменных, тут не важно
int RoundCount = 0;
int SuccessCount = 0;
int FailCount = 0;
double SuccessChance;

//коробка 1 полностью верная, 2 наполовину верная, 3 полностю неверная. Их индексы 0/1/2
List<(int, int)> Balls = new List<(int, int)>
{
    (1, 1),
    (1, 0),
    (0, 0)
};

//запускаем бесконечный цикл выбора
ChooseBox();


void ChooseBox()
{
    //инициализация переменных, тут не важно
    Random rnd = new Random();
    int randNumber;

    // запуск бесконечного цикла
    while(true)
    {
        //выбираем рандом число от 0 до 2 (ошибки тут нет, в скобках 3 должно быть)
        randNumber = rnd.Next(3);

        //если первый шар верен, добавляем плюс к раундам
        if (Balls[randNumber].Item1 == 1)
        {
            RoundCount++;
        }
        //если не верен, пропускаем эту итерацию и переходим к следующей
        else continue;

        //если выбралась коробка с 2мя верными шарами, то добавляем +1 к победе
        if (Balls[randNumber].Item1 == 1 && Balls[randNumber].Item2 == 1)
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

