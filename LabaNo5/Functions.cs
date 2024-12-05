using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LabaNo5
{
    internal class Functions
    {
        List<Eksponati> Eksponatis { get; set; }
        List<Posyetyityelyi> Posyetyityelyis { get; set; }
        List<Bileti> Biletis { get; set; }

        public void ReadDb() //Чтение базы данных
        {
            Eksponatis = ReadEksp();
            Posyetyityelyis = ReadPos();
            Biletis = ReadBilet();
        }

        public void ShowDb() //Просмотр базы данных.
        {
            Console.WriteLine("Экспонаты");
            foreach (Eksponati item in Eksponatis)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Посетители");
            foreach (Posyetyityelyi item in Posyetyityelyis)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Билеты");
            foreach (Bileti item in Biletis)
            {
                Console.WriteLine(item);
            }
        }

        public void DeleteElement() // Удаление элемента по ключу
        {
            Console.WriteLine("Выберите таблицу для удаления элемента (1 - Экспонаты, 2 - Посетители, 3 - Билеты):");
            string choice = Console.ReadLine();
            Console.WriteLine("Введите ID элемента для удаления:");
            if (!int.TryParse(Console.ReadLine(), out int id)) //принимаем ввод id у пользователя
            {
                Console.WriteLine("Некорректный ID.");
                return;
            }

            switch (choice)
            {
                case "1":
                    int CountEksp = Eksponatis.Count;
                    Eksponatis = Eksponatis.Where(e => e.EkspId != id).ToList(); //выбирам все элементы, у которых id =! id введенному пользователем.
                                                                                 //преобразуем обратно в список с помошью ToList
                    if (Eksponatis.Count < CountEksp) //если элемент удалился 
                        Console.WriteLine("Элемент удален из Экспонатов.");//пишем что удалился
                    else //иначе 
                        Console.WriteLine("Элемент с указанным ID не найден.");//пишем что не удалилися
                    break;
                case "2":
                    int initialCountPosyetyityelyis = Posyetyityelyis.Count;
                    Posyetyityelyis = Posyetyityelyis.Where(p => p.PosId != id).ToList();//выбирам все элементы, у которых id =! id введенному пользователем
                                                                                         //преобразуем обратно в список с помошью ToList
                    if (Posyetyityelyis.Count < initialCountPosyetyityelyis)
                        Console.WriteLine("Элемент удален из Посетителей.");
                    else
                        Console.WriteLine("Элемент с указанным ID не найден.");
                    break;
                case "3":
                    int initialCountBiletis = Biletis.Count;
                    Biletis = Biletis.Where(b => b.TiketId != id).ToList();//выбирам все элементы, у которых id =! id введенному пользователем
                                                                           //преобразуем обратно в список с помошью ToList
                    if (Biletis.Count < initialCountBiletis)
                        Console.WriteLine("Элемент удален из Билетов.");
                    else
                        Console.WriteLine("Элемент с указанным ID не найден.");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
            SaveDb();
        }

        public void UpdateElement() // Корректировка элемента по ключу
        {
            Console.WriteLine("Выберите таблицу для корректировки элемента (1 - Экспонаты, 2 - Посетители, 3 - Билеты):");
            string choice = Console.ReadLine();
            Console.WriteLine("Введите ID элемента для корректировки:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ID.");
                return;
            }

            switch (choice)
            {
                case "1":
                    Eksponati eksp = Eksponatis.FirstOrDefault(e => e.EkspId == id); //выбираем первый элемент, удовлетварающий условие где его id = id введенному пользователем
                    if (eksp != null)
                    {
                        Console.WriteLine("Введите название экспоната:");
                        eksp.EkspName = Console.ReadLine();
                        Console.WriteLine("Введите эпоху экспоната:");
                        eksp.Epoha = Console.ReadLine();
                        Console.WriteLine("Экспонат обновлен.");
                    }
                    else
                    {
                        Console.WriteLine("Экспонат с указанным ID не найден.");
                    }
                    break;
                case "2":
                    Posyetyityelyi pos = Posyetyityelyis.FirstOrDefault(p => p.PosId == id); //выбираем первый элемент, удовлетварающий условие где его id = id введенному пользователем
                    if (pos != null)
                    {
                        Console.WriteLine("Введите имя посетителя:");
                        pos.PosName = Console.ReadLine();
                        Console.WriteLine("Введите возраст посетителя:");
                        pos.Age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите город проживания:");
                        pos.City = Console.ReadLine();
                        Console.WriteLine("Посетитель обновлен.");
                    }
                    else
                    {
                        Console.WriteLine("Посетитель с указанным ID не найден.");
                    }
                    break;
                case "3":
                    Bileti bileti = Biletis.FirstOrDefault(b => b.TiketId == id);//выбираем первый элемент, удовлетварающий условие где его id = id введенному пользователем
                    if (bileti != null)
                    {
                        Console.WriteLine("Введите дату билета через '.' в формате 01.01.2000: ");
                        bileti.Date = Console.ReadLine();
                        Console.WriteLine("Введите стоимость билета:");
                        bileti.Cost = int.Parse(Console.ReadLine());
                        Console.WriteLine("Билет обновлен.");
                    }
                    else
                    {
                        Console.WriteLine("Билет с указанным ID не найден.");
                    }
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
            SaveDb();
        }

        public void AddElement() // Добавление элемента
        {
            Console.WriteLine("Выберите таблицу для добавления элемента (1 - Экспонаты, 2 - Посетители, 3 - Билеты):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите ID экспоната:");
                    if (!int.TryParse(Console.ReadLine(), out int newEkspId))
                    {
                        Console.WriteLine("Некорректный ID.");
                        return;
                    }
                    if (Eksponatis.Any(e => e.EkspId == newEkspId)) // если хоть один элемент имеет такой же id 
                    {
                        Console.WriteLine($"Экспонат с ID {newEkspId} уже существует.");
                        return;
                    }
                    Console.WriteLine("Введите имя экспоната:");
                    string newEkspName = Console.ReadLine();
                    Console.WriteLine("Введите тип экспоната:");
                    string newEpoha = Console.ReadLine();
                    Eksponati newEksp = new Eksponati(newEkspId, newEkspName, newEpoha);
                    Eksponatis.Add(newEksp);
                    Eksponatis = Eksponatis.OrderBy(e => e.EkspId).ToList();
                    break;
                case "2":
                    Console.WriteLine("Введите ID посетителя:");
                    if (!int.TryParse(Console.ReadLine(), out int newPosId))
                    {
                        Console.WriteLine("Некорректный Id");
                        return;
                    }
                    if (Posyetyityelyis.Any(p => p.PosId == newPosId))
                    {
                        Console.WriteLine($"Посетитель с ID {newPosId} уже существует.");
                        return;
                    }
                    Console.WriteLine("Введите имя посетителя:");
                    string posName = Console.ReadLine();
                    Console.WriteLine("Введите возраст посетителя:");
                    int posAge = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите город проживания посетителя:");
                    string posPhone = Console.ReadLine();
                    Posyetyityelyis.Add(new Posyetyityelyi(newPosId, posName, posAge, posPhone));
                    Console.WriteLine("Посетитель добавлен.");
                    break;
                case "3":
                    Console.WriteLine("Введите ID билета:");
                    if (!int.TryParse(Console.ReadLine(), out int newTiketosId))
                    {
                        Console.WriteLine("Некорректный Id");
                        return;
                    }
                    if (Biletis.Any(b => b.TiketId == newTiketosId))
                    {
                        Console.WriteLine($"Билет с ID {newTiketosId} уже существует.");
                        return;
                    }
                    Console.WriteLine("Введите ID экспоната:");
                    int newBiletiEkspId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ID посетителя:");
                    int newBiletiPosId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите дату билета через '.' в формате 01.01.2000::");
                    string nweBiletiDate = Console.ReadLine();
                    Console.WriteLine("Введите цену билета:");
                    int newBiletiCost = int.Parse(Console.ReadLine());
                    Biletis.Add(new Bileti(newTiketosId, newBiletiEkspId, newBiletiPosId, nweBiletiDate, newBiletiCost));
                    Console.WriteLine("Билет добавлен.");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
            SaveDb();
        }

        
        
        
       

        //вывести все экспонатов эпохи поп-арта (к 1 табл, перечень)
        public void ShowPopArtEksponati()
        {
            if (Eksponatis == null || !Eksponatis.Any())
            {
                Console.WriteLine("Нет данных об экспонатах");
                return;
            }

            // Фильтрация экспонатов по типу "Поп-арт"
            IEnumerable<Eksponati> popArtEksponati = Eksponatis.Where(e => e.Epoha.Equals("Поп-арт", StringComparison.OrdinalIgnoreCase));

            if (!popArtEksponati.Any())
            {
                Console.WriteLine("Экспонаты эпохи Поп-арт не найдены.");
                return;
            }

            Console.WriteLine("Экспонаты эпохи Поп-арт:");
            foreach (Eksponati eksp in popArtEksponati)
            {
                Console.WriteLine($"Id:{eksp.EkspId}, Название: {eksp.EkspName}"); // Используется переопределенный ToString()
            }
            SaveDb();
        }

        //Определите, суммарную выручку от продажи билетов на экспонаты эпохи Ренессанс за июнь 2023 года? (к 2 табл, 1 знач)
        public void SumRenesans()
        { 
            if (!Eksponatis.Any() || !Biletis.Any())
            {
                Console.WriteLine("Нет данных об экспонатах или билетах");
                return;
            }

            int sum = (from b in Biletis 
                                join e in Eksponatis on b.EkspId equals e.EkspId //связываем коллекции экспонатов и билетов
                                where e.Epoha.Equals("Ренессанс", StringComparison.OrdinalIgnoreCase) && //где эпоха - ренесана
                                      DateTime.TryParse(b.Date, out DateTime ticketDate) && 
                                      ticketDate.Month == 6 && ticketDate.Year == 2023
                                select b.Cost).Sum();

            Console.WriteLine($"Суммарная выручка от продажи билетов на экспонаты эпохи Ренессанс за июнь 2023 года: {sum}.");
            SaveDb();
        }

        //вывести весх посетеителей от 60 которые купили билет на экспонаты средневековья (к 3 тадл, перечень)
        public void PosOtShesdesyatSrednevek()
        {
            if (!Posyetyityelyis.Any() ||
                !Biletis.Any() ||
                !Eksponatis.Any())
            {
                Console.WriteLine("Нет данных для выполнения операции");
                return;
            }

            // LINQ-запрос для поиска посетителей
            IEnumerable<Posyetyityelyi> posetitel;
            posetitel = from b in Biletis
                           join e in Eksponatis on b.EkspId equals e.EkspId
                           join p in Posyetyityelyis on b.PosId equals p.PosId
                           where e.Epoha.Equals("Средневековье", StringComparison.OrdinalIgnoreCase) &&
                                 p.Age >= 60
                           select p;
             
            if (!posetitel.Any())
            {
                Console.WriteLine("Посетители из города Obrienberg, купившие билет на экспонаты эпохи Средневековья, не найдены.");
                return;
            }

            Console.WriteLine("Посетители старше 60 лет, купившие билет на экспонаты эпохи Средневековья:");
            foreach (var p in posetitel.Distinct()) // Используем Distinct, чтобы исключить дубли
            {
                Console.WriteLine($"Id: {p.PosId}, Имя: {p.PosName}, Возраст: {p.Age}"); // Используется переопределенный метод ToString()
            }
            SaveDb();
        }

        //сколько билетов купили посетители до 30 лет на экспонаты эпохи ар-деко стоимостью от 500 р (к 3 табл, 1 знач)

        public void PosDoTridcatiOtPyatsotR()
        {
            if (!Posyetyityelyis.Any() ||
                !Biletis.Any() ||
                !Eksponatis.Any())
            {
                Console.WriteLine("Нет данных для выполнения операции");
                return;
            }
            int posetitelCount = (from b in Biletis
                        join e in Eksponatis on b.EkspId equals e.EkspId
                        join p in Posyetyityelyis on b.PosId equals p.PosId
                        where e.Epoha.Equals("ар-деко", StringComparison.OrdinalIgnoreCase) &&
                        b.Cost >= 500 &&
                        p.Age <= 30
                        select b).Count();

            Console.WriteLine($"Число посетителей младше 30 лет, купивших билет на ар-деко, стоимостью от 500 р.: {posetitelCount}");
            SaveDb();
        }


        public void Run()
        {
            Console.WriteLine("Хотите создать новый файл для протоколирования или дописывать в существующий? (1 - Новый файл, 2 - Дописывать)");
            string logChoice = Console.ReadLine();
            string logFileName = "log.txt";

            if (logChoice == "1")
            {
                File.WriteAllText(logFileName, "Протокол действий\n"); // Создание нового файла с заголовком
            }

            Log("Начало сеанса работы.");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Чтение базы данных");
                Console.WriteLine("2. Просмотр базы данных");
                Console.WriteLine("3. Удаление элемента");
                Console.WriteLine("4. Корректировка элемента");
                Console.WriteLine("5. Добавление элемента");
                Console.WriteLine("6. Показать экспонаты эпохи Поп-арт");
                Console.WriteLine("7. Рассчитать выручку от продажи билетов на экспонаты эпохи Ренессанс за июнь 2023 года");
                Console.WriteLine("8. Показать посетителей старше 60 лет, купивших билет на экспонаты эпохи Средневековья");
                Console.WriteLine("9. Посчитать билеты, купленные посетителями до 30 лет на экспонаты ар-деко стоимостью от 500 рублей");
                Console.WriteLine("10. Выход");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            ReadDb();
                            Log("База данных успешно прочитана.");
                            break;
                        case "2":
                            ShowDb();
                            Log("Просмотр базы данных выполнен.");
                            break;
                        case "3":
                            DeleteElement();
                            Log("Удаление элемента выполнено.");
                            break;
                        case "4":
                            UpdateElement();
                            Log("Корректировка элемента выполнена.");
                            break;
                        case "5":
                            AddElement();
                            Log("Добавление элемента выполнено.");
                            break;
                        case "6":
                            ShowPopArtEksponati();
                            Log("Просмотр экспонатов эпохи Поп-арт выполнен.");
                            break;
                        case "7":
                            SumRenesans();
                            Log("Выручка за июнь 2023 года рассчитана.");
                            break;
                        case "8":
                            PosOtShesdesyatSrednevek();
                            Log("Просмотр посетителей старше 60 лет выполнен.");
                            break;
                        case "9":
                            PosDoTridcatiOtPyatsotR();
                            Log("Подсчет билетов на экспонаты ар-деко выполнен.");
                            break;
                        case "10":
                            Log("Сеанс работы завершен.");
                            return;
                        default:
                            Console.WriteLine("Некорректный ввод.");
                            Log("Некорректный ввод команды.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Log($"Ошибка: {ex.Message}");
                }
            }
        }


        private void Log(string message)
        {
            string logFile = "log.txt"; 
            string logTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(logFile, logTime + '\n');
        }


        private static List<Eksponati> ReadEksp()
        {
            List<Eksponati> eksponatis = new List<Eksponati>();
            try
            {
                // Открываем файл для чтения
                using (StreamReader sr = new StreamReader("eksponati.csv", Encoding.GetEncoding("windows-1251")))
                {
                    string line = sr.ReadLine(); //читаем первую строку и пропускаем её

                    // Читаем построчно из исходного файла
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Разбиваем строку на отдельные числа
                        string[] notes = line.Split(';');

                        Eksponati eksp = new Eksponati(Convertaciya(notes[0]), notes[1], notes[2]); //создаем объект класса экспонаты со свойствами ID, названия и эпохи

                        eksponatis.Add(eksp);
                    }
                    // StreamWriter автоматически закрывается
                }
                return eksponatis;
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("e");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Произошла ошибка: " + ex.Message);
            }

        }


        private static List<Posyetyityelyi> ReadPos()
        {
            List<Posyetyityelyi> posyetyityelyis = new List<Posyetyityelyi>();
            try
            {
                // Открываем файл для чтения
                using (StreamReader sr = new StreamReader("posyetyitelyi.csv", Encoding.GetEncoding("windows-1251")))
                {
                    // Создаем файл для записи

                    string line = sr.ReadLine(); //читаем первую строку и пропускаем её

                    // Читаем построчно из исходного файла
                    while ((line = sr.ReadLine()) != null)
                    {

                        // Разбиваем строку на отдельные числа
                        string[] notes = line.Split(';');

                        Posyetyityelyi eksp = new Posyetyityelyi(Convertaciya(notes[0]), notes[1], Convertaciya(notes[2]), notes[3]);

                        posyetyityelyis.Add(eksp);
                    }
                    // StreamWriter автоматически закрывается
                }
                return posyetyityelyis;
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("p");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Произошла ошибка: " + ex.Message);
            }

        }

        private static List<Bileti> ReadBilet()
        {
            List<Bileti> biletis = new List<Bileti>();
            try
            {
                // Открываем файл для чтения
                using (StreamReader sr = new StreamReader("Bileti.csv", Encoding.GetEncoding("windows-1251")))
                {
                    // Создаем файл для записи

                    string line = sr.ReadLine(); //читаем первую строку и пропускаем её

                    // Читаем построчно из исходного файла
                    while ((line = sr.ReadLine()) != null)
                    {

                        // Разбиваем строку на отдельные числа
                        string[] notes = line.Split(';');

                        Bileti eksp = new Bileti(Convertaciya(notes[0]), Convertaciya(notes[1]), Convertaciya(notes[2]), notes[3], Convertaciya(notes[4]));

                        biletis.Add(eksp);
                    }
                    // StreamWriter автоматически закрывается
                }
                return biletis;
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("b");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Произошла ошибка: " + ex.Message);
            }

        }

        private static int Convertaciya(string input)//метод преобразования строки чисел в int
        {
            // Используем StringBuilder для формирования результата
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsDigit(c)) // Проверяем, является ли символ цифрой
                {
                    result.Append(c); // Добавляем цифру
                }
            }

            // Преобразуем строку с цифрами в int
            int number = int.Parse(result.ToString());
            return number;
        }

        ///
        public void SaveDb() // Сохранение базы данных
        {
            SaveToFile("eksponati.csv",
                new[] { "ID экспоната;Название;Эпоха" } // Заголовок таблицы
                .Concat(Eksponatis.Select(e => $"{e.EkspId};{e.EkspName};{e.Epoha}")));

            SaveToFile("posyetyitelyi.csv",
                new[] { "ID посетителя;Имя;Возраст;Город проживания" } // Заголовок таблицы
                .Concat(Posyetyityelyis.Select(p => $"{p.PosId};{p.PosName};{p.Age};{p.City}")));

            SaveToFile("bileti.csv",
                new[] { "ID билета;ID экспоната;ID посетителя;Дата;Стоимость" } // Заголовок таблицы
                .Concat(Biletis.Select(b => $"{b.TiketId};{b.EkspId};{b.PosId};{b.Date};{b.Cost}")));

            Console.WriteLine("База данных успешно сохранена.");
        }

        private void SaveToFile(string fileName, IEnumerable<string> lines)
        {
            try
            {
                File.WriteAllLines(fileName, lines, Encoding.GetEncoding("windows-1251"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения в файл {fileName}: {ex.Message}");
            }
        }
    }
}
