namespace Ads
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args) 
        {
            int amountOfUsers = rnd.Next(4, 10);//изначальный размер списка юзеров 
            List<User> users = new List<User>();

            int loginLength, nameLength, premiumHaving;//для случайной генерации значений полей класса User
            
            //заполнение списка юзеров
            while (amountOfUsers > 0)
            {
                loginLength = rnd.Next(5, 15);
                nameLength = rnd.Next(2, 11);
                premiumHaving = rnd.Next(0, 2);
                users.Add(CreateUser(loginLength, nameLength, premiumHaving));
                amountOfUsers--;
            }

            //приветствие юзеров
            foreach(User user in users)
            {
                GreetUser(user);
            }
        }

        static User CreateUser(int login, int name, int premium)
        {
            string _login = string.Empty;
            string _name = string.Empty;
            bool _premium = default;

            int letterOrDigit, letterCase;

            //создаём логин
            for (int i = 0; i < login; i++)
            {
                letterOrDigit = rnd.Next(0, 2);
                //в логин добавляется цифра
                if(letterOrDigit == 0)
                {
                    _login += (char)rnd.Next(48, 58);
                }
                //в логин добавляется буква
                else
                {
                    //выбирается регистр
                    //0 - нижний, 1 - верхний
                    letterCase = rnd.Next(0, 2);
                    if(letterCase == 0)
                    {
                        _login += (char)rnd.Next(97, 123);
                    }
                    else
                    {
                        _login += (char)rnd.Next(65, 91);
                    }
                }
            }

            //создаём имя
            for(int i = 0; i < name; i++)
            {
                if(i == 0)
                {
                    //добавляется буква в верхнем регистре
                    _name += (char)rnd.Next(65, 91);
                }
                else
                {
                    //добавляется буква в нижнем регистре
                    _name += (char)rnd.Next(97, 123);
                }
            }

            //задаём наличие премиума
            if(premium != 0)
            {
                _premium = true;
            }

            return new User(_login, _name, _premium);
        }

        static void ShowAds(int randomAd)
        {
            switch(randomAd)
            {
                case 0:
                    Console.WriteLine("Посетите наш новый сайт с бесплатными играми https://free.games.for.a.fool.com");
                    Thread.Sleep(3000);
                    break;

                case 1:
                    Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
                    Thread.Sleep(3000);
                    break;
            }
            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            Thread.Sleep(3000);
        }

        static void GreetUser(User user)
        {
            if(user.IsPremiun == true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Здравствуй, {user.Name}!");
                Console.ResetColor();
            }
            else
            {
                ShowAds(rnd.Next(0, 2));
                Console.WriteLine($"Здравствуй, {user.Name}!");
            }
        }
    }
}