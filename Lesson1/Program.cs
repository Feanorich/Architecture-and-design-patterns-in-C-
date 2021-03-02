#region Задание №3
//Дал осмысленные имена переменным. 
//Сократил запись суммирования в цикле.
//Развернул цикл задом-наперед, чтобы не перезаписывать много раз переменную с четным числом
//...кстати, в исходнике  было написано "меньше N", а программа может найти равное N
//(если само N четное). Не стал это менять, но если нужно именно "меньше", 
//то нужно добавить еще один if
#endregion

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Здравствуйте вас приветствует математическая программа");
        Console.WriteLine("Пожалуйста, введите число. ");

        String _incomingString = Console.ReadLine();

        if (_incomingString == "q")
        {
            return;
        }

        int _originalNumber = Int32.Parse(_incomingString);
        int _factorial = 1; 
        int _sum = 0;
        int _maxEvenNumber = 0;

        for (int i = _originalNumber; i >= 1; i--)
        {
            if (_maxEvenNumber == 0)
            {
                if (i % 2 == 0)
                {
                    _maxEvenNumber = i;
                }
            }

            _factorial *= i;
            _sum = _sum + i;
        }

        Console.WriteLine("Факториал равен: " + _factorial); 
        Console.WriteLine("Сумма от 1 до N равна: " + _sum);
        Console.WriteLine("Максимальное четное число, меньше либо равное N, равно: " + _maxEvenNumber);
        Console.ReadLine();
    }
}

