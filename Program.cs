
//Реализовать базу данных игроков и методы для работы с ней.
//У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool).
//Реализовать возможность добавления игрока, бана игрока по уникальный номеру, разбана игрока по уникальный номеру и удаление игрока.
//Создание самой БД не требуется, задание выполняется инструментами, которые вы уже изучили в рамках курса. Но нужен класс, который содержит игроков и её можно назвать "База данных".

namespace OOPThird3
{
    class DateBase
    {
        Player playerDate = new Player();
        Dictionary<int, Player> players = new Dictionary<int, Player>();
        Random rand = new Random();

        public void AddPlayer()
        {
            Console.WriteLine("Введите имя пользователя:");
            playerDate.namePlayer = Console.ReadLine();

            playerDate.levelPlayer = rand.Next(1, 100);
            playerDate.playerID = rand.Next(111111, 999999);
            playerDate.playerIndex = rand.Next(1, 100);

            players.Add(playerDate.playerIndex, new Player()
            {
                namePlayer = playerDate.namePlayer,
                levelPlayer = playerDate.levelPlayer,
                isPlaying = false,
                playerID = playerDate.playerID
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
                if (specialNumber == player.playerIndex || specialNumber == player.playerID)       // Не знаю как здесь исключить повторяющийся код!!
                {
                    player.isPlaying = true;
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
                if (specialNumber == player.playerIndex || specialNumber == player.playerID)   // Не знаю как здесь исключить повторяющийся код!!
                {
                    player.isPlaying = false;
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

        private void PlayerBusting()
        {
            foreach (KeyValuePair<int, Player> player in players)
            {
                Console.WriteLine($"Индекс: {player.Key}.\n " +
                    $"Имя игрока: {player.Value.namePlayer}.\n " +
                    $"Уровень игрока: {player.Value.levelPlayer}.\n " +
                    $"Заблокирован: {player.Value.isPlaying}.\n " +
                    $"Индивидуальный номер: {player.Value.playerID}.");
            }
        }
    }

    class Player
    {
        public string namePlayer { get; set; }

        public int levelPlayer { get; set; }
        public int playerID { get; set; }
        public int playerIndex { get; set; }

        public bool isPlaying { get; set; }

        public Player()
        {
            this.namePlayer = namePlayer;
            this.levelPlayer = levelPlayer;
            this.playerID = playerID;
            this.isPlaying = isPlaying;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            DateBase dateBase = new DateBase();
            Console.WriteLine("Выберите команду: \nДобавить игрока: 1. \nУдалить игрока: 2. \nЗабанить игрока: 3. " +
                "\nРазбанить игрока: 4. \nВывод всех игроков: 5.");


            while (true)
            {
                string choiceNumber = Console.ReadLine();
                if (int.TryParse(choiceNumber, out int _choiceNumber))

                    switch (_choiceNumber)
                    {
                        case (int)ResultChoice.AddPlayer:
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