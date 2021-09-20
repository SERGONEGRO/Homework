using System;

namespace Theme3_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1.Создание игры на два игрока


            //Что нужно сделать
            //Разработайте простую игру на два игрока.Правила игры:

            //Загадывается число от 12 до 120, причём случайным образом.Назовём его gameNumber.
            //Игроки по очереди выбирают число от одного до четырёх.Пусть это число обозначается как userTry.
            //UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.
            //Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.
            //Перед началом игры вам необходимо вывести её правила на экран. После того как игроки ознакомились
            //с правилами, необходимо сделать так, чтобы игроки могли представиться. Каждый игрок должен видеть,
            //когда его ход, а когда ход оппонента, поэтому перед ходом игрока выводится его имя и приглашение к 
            //вводу.И, само собой, после окончания игры стоит поздравить победителя и предложить реванш.


            //Добавьте уровни сложности, чтобы улучшить игру. Если ранее число gameNumber генерировалось в жёстко
            //заданном диапазоне, то теперь данный диапазон вводится с клавиатуры. Также предусмотрите ввод максимально
            //и минимально возможного значения для userTry. 
            //Помимо добавления уровней сложности вы можете добавить возможность играть в неё трём, четырём или пяти игрокам.

                        /* РЕШЕНИЕ */
            Random rand = new Random();
            int gameNumber=4;
            string username1;
            string username2;
            int otvet = 0;
            int gameNumberMin=12 ; int gameNumberMax=120;
            int playersCount=2;
            string[] playerName = new string[playersCount]; //массив с именами игроков, по умолчанию 2 значения
            int[] userTry = new int[playersCount];          //массив с числами игроков, по умолчанию 2 значаения
            int mode;         //режим игры
           

            //Начало Игры
            do
            {
                //Ввод количества игроков и проверка, что игроков 2-5
                Console.WriteLine("\nВведите Количество игроков (от 2 до 5)");
                do
                {
                    playersCount = Convert.ToInt32(Console.ReadLine());
                }
                while (CheckNumber(playersCount,2,5) == false);

                //заполняем массив именами игроков
                for (int i = 0; i < playerName.Length; i++)
                {
                    Console.WriteLine($"\nВведите имя {i+1} игрока:") ;
                    playerName[i] = Console.ReadLine();
                }

                //задание сложности игры
                Console.WriteLine("Введите режим игры: ");
                Console.WriteLine("1 - генерация gamenumber случайно, 2 - задать диапазон, 3 - задать вручную."  );
                do
                {
                    mode = Convert.ToInt32(Console.ReadLine());
                }
                while (CheckNumber(mode, 1, 3) == false);

                //задание числа в зависимости от сложности
                if (mode==1) gameNumber = rand.Next(12, 121);           //компьютер загадывает число
                else if (mode == 2)                                     // режим задания диапазона
                {
                    Console.WriteLine("Задайте минимальное значение ( от 4 до 150):");
                    do
                    {
                        gameNumberMin = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(gameNumberMin, 4, 150) == false);
                    Console.WriteLine("Задайте Максимальное значение ( от 5 до 150):");
                    do
                    {
                        gameNumberMax = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(gameNumberMax, 5, 150) == false);
                }
                else                                                         //режим задания числа руками
                {
                    Console.WriteLine("Задайте число ( от 4 до 150):");
                    do
                    {
                        gameNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(gameNumber, 4, 150) == false);
                }
                

                

                while (gameNumber >= 0)
                {
                    for (int j=0, j<playersCount;j++)
                    //Ход 1 игрока

                    Console.WriteLine($"**Игрок {username1} выбирает число:");

                    //ввод числа до тех пор, пока не введено "правильное" число
                    do
                    {
                        userTry1 = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(userTry1) == false); 

                    gameNumber = gameNumber - userTry1;          //вычитание согласно правилам
                    Console.WriteLine($"\t\t GameNumber = {gameNumber}\n");

                    //Проверка на предмет выигрыша
                    if (CheckGameNumber(gameNumber) == 1)       //CheckGameNumber ==1  -- победа
                    {
                        Console.WriteLine($"Поздравляю игрока {username1}!! Если хотите сыграть еще раз, введите '1':");
                        otvet = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    else if (CheckGameNumber(gameNumber) == 2)   //CheckGameNumber ==2  -- ничья
                    {
                        Console.WriteLine($"Если хотите сыграть еще раз, введите '1':");
                        otvet = Convert.ToInt32(Console.ReadLine());
                        break;
                    }


                    //Ход 2 игрока

                    Console.WriteLine($"**Игрок {username2} выбирает число:");

                    //ввод числа до тех пор, пока не введено "правильное" число
                    do
                    {
                        userTry2 = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(userTry2) == false);

                    gameNumber = gameNumber - userTry2;                 //вычитание согласно правилам
                    Console.WriteLine($"GameNumber = {gameNumber}\n");

                    //Проверка на предмет выигрыша
                    if (CheckGameNumber(gameNumber) == 1)               //CheckGameNumber ==1  -- победа
                    {
                        Console.WriteLine($"Поздравляю игрока {username2}!! Если хотите сыграть еще раз, введите '1':");
                        otvet = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    else if (CheckGameNumber(gameNumber) == 2)          //CheckGameNumber ==2  -- ничья
                    {
                        Console.WriteLine($"Если хотите сыграть еще раз, введите '1':");
                        otvet = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                }


            } while (otvet == 1); //прдолжать, если после окончания игры вводят "1"

            Console.WriteLine("ИГРА ОКОНЧЕНА");


            ///<summary>
            ///Функция проверки корректности числа CheckNumber
            /// </summary>
            bool CheckNumber(int number, int min, int max)
            {
                if (number >= min && number <= max) return true;
                else { Console.WriteLine("Введите другое число!"); return false; }
            }

            ///<summary>
            ///Функция проверки, что игра не завершилась
            /// </summary>
            int CheckGameNumber(int gamenumber1)
            {
                if (gamenumber > 0) return 0;
                else if (gamenumber == 0) { Console.WriteLine("ПОБЕДА!!!"); return 1; }
                else { Console.WriteLine("НИЧЬЯ :("); return 2; }
            }

            //правила печать правил
            void PrintRules(int gamenumberMin, int gamenumberMax, int playerscount)
            {
                Console.WriteLine($"\t\t ***Игра для {playerscount} игроков***");
                Console.WriteLine("\t\t ***ПРАВИЛА***");
                Console.WriteLine($"Загадывается число от {gamenumberMin} до {gamenumberMax}.Назовём его gameNumber");
                Console.WriteLine("Игроки по очереди выбирают число от одного до четырёх");
                Console.WriteLine("После каждого хода число игрока вычитается из gameNumber, а само gameNumber выводится на экран");
                Console.WriteLine("Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем");
            }


        }



    }
}
