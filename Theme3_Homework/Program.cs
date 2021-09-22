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

            /* РЕШЕНИЕ */
            Random rand = new Random();
            int userTry;
            int otvet=0;
            int playersCount = 2;   //количество игроков

            ///<summary>
            ///Функция проверки корректности числа CheckNumber
            /// </summary>
            bool CheckNumber(int number)                                                
            {
                if (number >= 1 && number <= 4) return true;
                else { Console.WriteLine("Введите другое число!"); return false; }
            }

            ///<summary>
            ///Функция проверки, что игра не завершилась
            /// </summary>
            int CheckGameNumber(int gamenumber)
            {
                if (gamenumber > 0) return 0;
                else if (gamenumber == 0) { Console.WriteLine("ПОБЕДА!!!"); return 1; }
                else { Console.WriteLine("НИЧЬЯ :("); return 2; }
            }

            //правила
            Console.WriteLine("\t\t ***Игра на два игрока***");
            Console.WriteLine("\t\t ***ПРАВИЛА***");
            Console.WriteLine("Загадывается число от 12 до 120, причём случайным образом.Назовём его gameNumber");
            Console.WriteLine("Игроки по очереди выбирают число от одного до четырёх");
            Console.WriteLine("После каждого хода число игрока вычитается из gameNumber, а само gameNumber выводится на экран");
            Console.WriteLine("Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем");

            //Начало Игры
            do
            {       /*-------Задание параметров игры------------*/
                string[] playerName = new string[playersCount];   //опеределяем массив с именами игроков

                //задаем имена игроков
                for (int i = 0;i< playersCount;i++)
                {
                    Console.WriteLine($"\nВведите имя {i+1} игрока:");
                    playerName[i] = Console.ReadLine();
                }

                int gameNumber = rand.Next(12, 120);         //компьютер загадывает число
                Console.WriteLine($"Компьютер загадал число {gameNumber}");


                /*----------начало игры----------*/
                while (gameNumber > 0)     // до тех пор, пока gameNumber больше нуля
                {
                    
                    for (int j=0;j<playersCount;j++)      //игроки ходят по очереди
                    {
                       Console.WriteLine($"**Игрок {playerName[j]} выбирает число:");

                        //ввод числа до тех пор, пока не введено "правильное" число
                        do
                        {
                            userTry = Convert.ToInt32(Console.ReadLine());
                        }
                        while (CheckNumber(userTry) == false);

                        //вычитание согласно правилам
                        gameNumber = gameNumber - userTry;         
                        Console.WriteLine($"\t\t GameNumber = {gameNumber}\n");

                        //Проверка на предмет выигрыша
                        if (CheckGameNumber(gameNumber) == 1)       //CheckGameNumber ==1  -- победа
                        {
                            Console.WriteLine($"Поздравляю игрока {playerName[j]}!! Если хотите сыграть еще раз, введите '1':");
                            otvet = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        else if (CheckGameNumber(gameNumber) == 2)   //CheckGameNumber ==2  -- ничья
                        {
                            Console.WriteLine($"Если хотите сыграть еще раз, введите '1':");
                            otvet = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        break;
                    }
          
                }

            } while (otvet == 1); //прдолжать, если после окончания игры вводят "1"

            Console.WriteLine("ИГРА ОКОНЧЕНА");

        }

    }
}
