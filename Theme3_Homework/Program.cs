using System;

namespace Theme3_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            
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

            //Так как не всегда удаётся найти второго игрока, предусмотрите возможность игры с компьютером. Причём компьютер
            //может быть как лёгкий, которого совсем просто обыграть, так и сложный, для победы над которым игроку придётся подумать.

            /* РЕШЕНИЕ */
            Random rand = new Random();
            int gameNumber=4;
            int otvet = 0;
            int gameNumberMin=12 ; int gameNumberMax=120;
            int playersCount;                             //число игроков, по умолчанию 2
            int userTry;
            int userTryMin = 1; int userTryMax = 4;       //диапазон UserTry по умолчанию 
            int mode;         //режим игры
           

                                        
            do
                                    /*------------------задание правил игры----------------------*/

            {
                //Ввод количества игроков и проверка, что игроков 2-5
                Console.WriteLine("\nВведите Количество игроков (от 2 до 5)");
                do
                {
                    playersCount = Convert.ToInt32(Console.ReadLine());
                }
                while (CheckNumber(playersCount,2,5) == false);

                string[] playerName = new string[playersCount]; //массив с именами игроков, по умолчанию 2 значения

                //заполняем массив именами игроков
                for (int i = 0; i < playerName.Length; i++)
                {
                    Console.WriteLine($"\nВведите имя {i+1} игрока. cEasy - легкий компьютер, cHard - сложный компьютер:") ;
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
                    Console.WriteLine("Задайте минимальное значение ( от 4 до 120):");
                    do
                    {
                        gameNumberMin = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(gameNumberMin, 4, 120) == false);
                    Console.WriteLine("Задайте Максимальное значение ( от 5 до 120):");
                    do
                    {
                        gameNumberMax = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(gameNumberMax, 5, 120) == false);
                    gameNumber = rand.Next(gameNumberMin, gameNumberMax);    //задание числа в нужном диапазоне
                }
                else                                                         //режим задания числа руками
                {
                    Console.WriteLine("Задайте число ( от 4 до 120):");
                    do
                    {
                        gameNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(gameNumber, 4, 120) == false);
                }

                //Если нужно задать интервал Usertry:
                Console.WriteLine("Если нужно задать диапазон userTry, введите 'да':");
                string otvetDiapazon = Console.ReadLine();
                if (otvetDiapazon == "да")
                {
                    Console.WriteLine("Введите минимальное значение UserTry (от 1 до 4):");
                    do
                    {
                        userTryMin = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(userTryMin, 1, 4) == false);
                    Console.WriteLine("Введите Максимальное значение UserTry (от 5 до 10):");
                    do
                    {
                        userTryMax = Convert.ToInt32(Console.ReadLine());
                    }
                    while (CheckNumber(userTryMax, 5, 10) == false);
                }

                PrintRules(gameNumberMin, gameNumberMax, playersCount);      //печать правил
                Console.WriteLine($"\t\t --->GameNumber = {gameNumber}<---\n");


                /*----------------Начало игры---------------------*/

                while (gameNumber > 0)
                {
                    for (int j = 0; j < playersCount; j++)
                    {
                        Console.WriteLine($"**Игрок {playerName[j]} выбирает число:");

                        //Если комп легкий
                        if (playerName[j].Equals("cEasy"))
                        {
                            userTry = rand.Next(userTryMin, userTryMax);
                            Console.WriteLine($"Компьютер выбрал число {userTry}");

                        }
                        //Если комп сложный
                        else if(playerName[j].Equals("cHard"))
                        {
                            //Если комп может завершить игру 1 ходом, то он выигрывает
                            if (gameNumber<=userTryMax) userTry = gameNumber;
                            else userTry = rand.Next(userTryMin, userTryMax);
                            Console.WriteLine($"Компьютер выбрал число {userTry}");
                        }
                        //Если человек: ввод числа до тех пор, пока не введено "правильное" число
                        else
                        {
                            do
                            {
                                userTry = Convert.ToInt32(Console.ReadLine());
                            }
                            //+проверка, что userTry в нужном диапазоне, и что оно не больше чем оставшееся gameNumber
                            while (CheckNumber(userTry, userTryMin, userTryMax) == false || CheckNumber(userTry, 0, gameNumber) == false);
                        }

                        gameNumber = gameNumber - userTry;          //вычитание согласно правилам
                        Console.WriteLine($"\t\t --->GameNumber = {gameNumber}<---\n");

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
                if (gamenumber1 > 0) return 0;
                else if (gamenumber1 == 0) { Console.WriteLine("ПОБЕДА!!!"); return 1; }
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
