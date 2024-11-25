﻿
//Реализовать базу данных игроков и методы для работы с ней.
//У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool).
//Реализовать возможность добавления игрока, бана игрока по уникальный номеру, разбана игрока по уникальный номеру и удаление игрока.
//Создание самой БД не требуется, задание выполняется инструментами, которые вы уже изучили в рамках курса. Но нужен класс, который содержит игроков и её можно назвать "База данных".

namespace OOPThird3
{
    class DateBase
    {
        public Player playerDate = new Player();
        Dictionary<int, Player> players = new Dictionary<int, Player>();

        public void AddPlayer()
        {
            players.Add(playerDate.PlayerIndex, new Player()
            {
                NamePlayer = playerDate.NamePlayer,
                LevelPlayer = playerDate.LevelPlayer,
                IsPlaying = false,
                PlayerID = playerDate.PlayerID
            });

            Console.WriteLine("Игрок добавлен в список.");
            Console.WriteLine();
        }

        public void BanPlayer()
        {
            PlayerBusting();
            Console.WriteLine();
            Console.WriteLine("Выберите игрока: Введите индекс игрока или индивидульаный номер.");

            int specialNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            foreach (var player in players.Values)
                if (specialNumber == player.PlayerIndex || specialNumber == player.PlayerID)       // Не знаю как здесь исключить повторяющийся код!!
                {
                    player.IsPlaying = true;
                }

            Console.WriteLine("Игрок забанин.");
        }

        public void UnbanPlayer()
        {
            PlayerBusting();
            Console.WriteLine();
            Console.WriteLine("Выберите игрока: Введите индекс игрока или индивидульаный номер.");

            int specialNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            foreach (var player in players.Values)
                if (specialNumber == player.PlayerIndex || specialNumber == player.PlayerID)   // Не знаю как здесь исключить повторяющийся код!!
                {
                    player.IsPlaying = false;
                }

            Console.WriteLine("Игрок разбанин.");
        }

        public void DeletPlayer()
        {
            PlayerBusting();
            Console.WriteLine();
            Console.WriteLine("Выберите игрока: Введите индекс игрока. " +
                "\nВнимание! Если игрок будет удален, всме достижение будут удалены!");

            int specialNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            players.Remove(specialNumber);
        }

        public void DisplayPlayer()
        {
            Console.WriteLine("Вывод игроков: ");
            Console.WriteLine();
            PlayerBusting();
        }

        void PlayerBusting()
        {
            foreach (KeyValuePair<int, Player> player in players)
            {
                Console.WriteLine($"Индекс: {player.Key}.\n " +
                    $"Имя игрока: {player.Value.NamePlayer}.\n " +
                    $"Уровень игрока: {player.Value.LevelPlayer}.\n " +
                    $"Заблокирован: {player.Value.IsPlaying}.\n " +
                    $"Индивидуальный номер: {player.Value.PlayerID}.");
            }
        }
    }

    class Player
    {
        private string namePlayer;

        private int levelPlayer;
        private int playerID;
        private int playerIndex;

        private bool isPlaying;

        public string NamePlayer { get { return namePlayer; } set { namePlayer = value; } }
        public int LevelPlayer { get { return levelPlayer; } set { levelPlayer = value; } }
        public int PlayerID { get { return playerID; } set { playerID = value; } }
        public int PlayerIndex { get { return playerIndex; } set { playerIndex = value; } }
        public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            DateBase dateBase = new DateBase();
            Random rand = new Random();

            Console.WriteLine("Команда: \nДобавить игрока - 1. \nУдалить игрока - 2. \nЗабанить игрока - 3. \nРазбанить игрока - 4. \nВыход из программы - 5. \nВывод списка игрока - 6.");

            while (true)
            {
                string choiceNumber = Console.ReadLine();
                if (int.TryParse(choiceNumber, out int _choiceNumber))

                    switch (_choiceNumber)
                    {
                        case (int)ResultChoice.AddPlayer:
                            Console.WriteLine("Введите имя пользователя:");
                            dateBase.playerDate.NamePlayer = Console.ReadLine();

                            dateBase.playerDate.LevelPlayer = rand.Next(1, 100);
                            dateBase.playerDate.PlayerID = rand.Next(111111, 999999);
                            dateBase.playerDate.PlayerIndex = rand.Next(1, 100);

                            dateBase.AddPlayer();
                            Console.WriteLine("Выберите команду");
                            break;

                        case (int)ResultChoice.DeletPlayer:
                            dateBase.DeletPlayer();
                            Console.WriteLine("Выберите команду");
                            break;

                        case (int)ResultChoice.BanPlayer:
                            dateBase.BanPlayer();
                            Console.WriteLine("Выберите команду");
                            break;

                        case (int)ResultChoice.UnbanPlayer:
                            dateBase.UnbanPlayer();
                            Console.WriteLine("Выберите команду");
                            break;

                        case (int)ResultChoice.DisplayPlayer:
                            dateBase.DisplayPlayer();
                            Console.WriteLine("Выберите команду");
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
            }

        }
    }

    enum ResultChoice
    {
        AddPlayer = 1,
        DeletPlayer = 2,
        BanPlayer = 3,
        UnbanPlayer = 4,
        DisplayPlayer = 5
    }

}