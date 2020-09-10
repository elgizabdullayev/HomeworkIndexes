using System;

namespace HomeworkIndexesTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Exit = false;
            int count1 = 0;
            int count2 = 0;
            bool freeBase1 = false;
            bool freeBase2 = false;
            PersonalAccounts personalaccounts = new PersonalAccounts();
            LegalAccounts legalaccounts = new LegalAccounts();
            do
            {
                Console.WriteLine("Выберите с каким счетом вы хотите работать:\n1.Счет физического лица.\n2.Счет юридического лица.");
                int select1 = InputInfo.InputNavigate2();
                switch (select1)
                {
                    case 1:
                        {
                            Console.WriteLine("1.Создать счет физического лица.\n2.Показать информацию о счете.\n3.Снятие денег со счета.\n4.Выход.");
                            int select2 = InputInfo.InputNavigate1();
                            switch (select2)
                            {
                                case 1:
                                    {
                                        count1 += 1;
                                        personalaccounts[count1] = new PersonalAccount(1, "", "");
                                        freeBase1 = true;
                                        Console.WriteLine("Чтобы вернуться в главное меню нажмите - 1;\nДля выхода нажмите - 2.");
                                        int select3 = InputInfo.InputInt();
                                        if (select3 == 2)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        if (freeBase1 == true)
                                        {
                                            Console.WriteLine("Введите номер счета");
                                            string num = Console.ReadLine();
                                            personalaccounts[num].ShowDate();
                                            personalaccounts[num].ShowSum();
                                            personalaccounts[num].TypeOfAccount();
                                            personalaccounts[num].Percentage();
                                        }
                                        else
                                        {
                                            Console.WriteLine("База пустая.");
                                        }
                                        Console.WriteLine("Чтобы вернуться в главное меню нажмите - 1;\nДля выхода нажмите - 2.");
                                        int select3 = InputInfo.InputInt();
                                        if (select3 == 2)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (freeBase1 == true)
                                        {
                                            Console.WriteLine("Введите номер счета.");
                                            string num = Console.ReadLine();
                                            personalaccounts[num].Withdraw();
                                        }
                                        else
                                        {
                                            Console.WriteLine("База пустая.");
                                        }
                                        Console.WriteLine("Чтобы вернуться в главное меню нажмите - 1;\nДля выхода нажмите - 2.");
                                        int select3 = InputInfo.InputInt();
                                        if (select3 == 2)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        Exit = true;
                                        break;
                                    }

                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("1.Создать счет юридического лица.\n2.Показать информацию о счете.\n3.Выход.");
                            int select2 = InputInfo.InputNavigate1();
                            switch (select2)
                            {
                                case 1:
                                    {
                                        count2 += 1;
                                        legalaccounts[count2] = new LegalAccount(1, "", "");
                                        Console.WriteLine($"Ваш порядковый номер счета:{count2}");
                                        freeBase2 = true;
                                        Console.WriteLine("Чтобы вернуться в главное меню нажмите - 1;\nДля выхода нажмите - 2.");
                                        int select3 = InputInfo.InputInt();
                                        if (select3 == 2)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        if (freeBase2 == true)
                                        {
                                            Console.WriteLine("Введите номер счета");
                                            string num = Console.ReadLine();
                                            legalaccounts[num].ShowDate();
                                            legalaccounts[num].ShowSum();
                                            legalaccounts[num].Percentage2();
                                        }
                                        else
                                        {
                                            Console.WriteLine("База пустая.");
                                        }
                                        Console.WriteLine("Чтобы вернуться в главное меню нажмите - 1;\nДля выхода нажмите - 2.");
                                        int select3 = InputInfo.InputInt();
                                        if (select3 == 2)
                                        {
                                            Exit = true;
                                        }

                                        break;
                                    }
                                case 3:
                                    {
                                        Exit = true;
                                        break;
                                    }
                                case 4:
                                    {
                                        Console.WriteLine("Пункта меню не существует.");
                                        break;
                                    }

                            }
                            break;
                        }

                }
            }
            while (Exit == false);
        }
    }
    class Account
    {
        public int Amount { get; set; }
        public string AccountNumber { get; set; }
        public  DateTime Date { get; set; }

        public Account(int amount, string accountnumber, string date)
        {
            Console.WriteLine("Введите сумму на вашем счете.");
            Amount = InputInfo.InputInt();
            Console.WriteLine("Введите номер счета.");
            AccountNumber = Console.ReadLine();
            Console.WriteLine("Дата и время создания счета:");
            Date = DateTime.Now;
            Console.WriteLine(Date);
        }
        public void ShowDate()
        {
            Console.WriteLine($"Счет создан: {Date}");
        }
        public void ShowSum()
        {
            Console.WriteLine($"На вашем счете: {Amount}$");
        }
    }
    class PersonalAccounts
    {
        public static PersonalAccount[] data;
        public PersonalAccounts()
        {
            data = new PersonalAccount[100];
        }
        public PersonalAccount this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public PersonalAccount this[string accountnumber]
        {
            get
            {
                PersonalAccount personalaccount = null;
                foreach (var p in data)
                {
                    if (p?.AccountNumber == accountnumber)
                    {
                        personalaccount = p;
                        break;
                    }
                }
                return personalaccount;

            }
        }
    }
    class PersonalAccount : Account
    {
        double percentage1 = 0.05;
        string type;
        double percamount;
        public PersonalAccount(int amount, string accountnumber, string date)
            : base(amount, accountnumber, date)
        {
            Console.WriteLine("Введите вид вашего счета.");
            type = Console.ReadLine();
        }
        public void TypeOfAccount()
        {
            Console.WriteLine($"Вид счета: {type}");
        }
        public void Percentage()
        {
            percamount = percentage1 * Amount;
            Console.WriteLine($"Начисление процентов: {percamount}$");
        }
        public void Withdraw()
        {
            Console.WriteLine("Введите сумму, которую хотите вывести.");
            int withdrawalamount = InputInfo.InputInt();
            if (withdrawalamount > Amount)
            {
                Console.WriteLine($"У вас на счете не хватает средств.");
            }
            else
            {

                Amount -= withdrawalamount;
            }
            Console.WriteLine($"У вас осталось: {Amount}$");
        }
    }
    class LegalAccounts
    {
        public static LegalAccount[] data;
        public LegalAccounts()
        {
            data = new LegalAccount[100];
        }
        public LegalAccount this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public LegalAccount this[string accountnumber]
        {
            get
            {
                LegalAccount legalaccount = null;
                foreach (var p in data)
                {
                    if (p?.AccountNumber == accountnumber)
                    {
                        legalaccount = p;
                        break;
                    }
                }
                return legalaccount;

            }
        }

    }
    class LegalAccount : Account
    {
        double percentage2 = 0.04;
        double percamount2;
        public LegalAccount(int amount, string accountnumber, string date)
            : base(amount, accountnumber, date)
        {

        }
        public void Percentage2()
        {
            percamount2 = percentage2 * Amount;
            Console.WriteLine($"Начисление процентов:{percamount2}");
        }
    }
    class InputInfo
    {
        public static int InputInt()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number >= 0)
                    {
                        isRight = true;
                    }
                    else
                    {
                        Console.WriteLine("Введено отрицательное значение. Введите снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return number;
        }
        public static int InputNavigate1()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number <= 4)
                    {
                        isRight = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите одну из цифр: 1, 2, 3, 4.");
                    }
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return number;

        }
        public static int InputNavigate2()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number <= 2)
                    {
                        isRight = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите: 1 или 2");
                    }
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return number;
        }

    }
}