using System;

namespace HomeworkIndexesTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            int globalcount1 = 0;
            int globalcount2 = 0;
            bool Exit = false;
            bool freebase1 = false;
            bool freebase2 = false;
            Students students = new Students();
            Aspirants aspirants = new Aspirants();
            do
            {
                Console.WriteLine("Меню: \n1.Ввод данных. \n2.Вывод данных о всех студентах. \n3.Вывод данных о всех аспирантах. \n4.Выход.\nВведите цифру перед пунктом для перехода в пункт меню.");
                int navigate = InputInfo.InputNavigate1();
                switch (navigate)
                {
                    case 1:
                        {
                            Console.WriteLine("Вы хотите ввести данные аспиранта или студента? \nВведите 1 - для ввода данных студента или 2 - для ввода данных аспиранта.");
                            int case1 = InputInfo.InputNavigate2();
                            switch (case1)
                            {
                                case 1:
                                    {
                                        bool newEnter = false;
                                        do
                                        {
                                            Console.WriteLine("Данные о скольки студентах вы хотите ввести?");
                                            int count1 = InputInfo.InputInt();
                                            
                                           
                                            for (int i = globalcount1; i < globalcount1+count1; i++)
                                            {
                                                students[i] = new Student("", 1, 1);

                                            }
                                            globalcount1 += count1;
                                            freebase1 = true;
                                            Console.WriteLine("Хотите продолжить ввод. Нажмите 1 - для завершения, 2 - для продолжения.");
                                            int select1 = InputInfo.InputNavigate2();
                                            if (select1 == 1)
                                            {
                                                newEnter = true;
                                            }

                                        }
                                        while (newEnter == false);
                                        Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                                        int select = InputInfo.InputNavigate2();
                                        if (select == 1)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                                case 2:
                                    {

                                        bool newEnter = false;
                                        do
                                        {
                                            Console.WriteLine("Данные о скольки аспирантах вы хотите ввести?");
                                           int count2 = InputInfo.InputInt();
                                           
                                            for (int i = globalcount2; i < globalcount2 + count2; i++)
                                            {
                                                aspirants[i] = new Aspirant("", 1, 1, "");
                                            }
                                            globalcount2 += count2;
                                            freebase2 = true;
                                            Console.WriteLine("Хотите продолжить ввод. Нажмите 1 - для завершения, 2 - для продолжения.");
                                            int select1 = InputInfo.InputNavigate2();
                                            if (select1 == 1)
                                            {
                                                newEnter = true;
                                            }

                                        }
                                        while (newEnter == false);
                                        Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                                        int select = InputInfo.InputNavigate2();
                                        if (select == 1)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }


                    case 2:
                        {
                            if (freebase1 == true)
                            {
                                for (int i = 0; i < globalcount1; i++)
                                {
                                    students[i].Display();
                                }
                            }
                            else
                            {
                                Console.WriteLine("База пустая.");
                            }
                            Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                            int select = InputInfo.InputNavigate2();
                            if (select == 1)
                            {
                                Exit = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (freebase2 == true)
                            {
                                for (int i = 0; i < globalcount2; i++)
                                {
                                    aspirants[i].Display();
                                }
                            }
                            else
                            {
                                Console.WriteLine("База пустая.");
                            }
                            Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                            int select = InputInfo.InputNavigate2();
                            if (select == 1)
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
                    default:
                        {
                            Console.WriteLine("Произошла ошибка.");
                            break;
                        }



                }
            }
            while (Exit == false);

        }
    }
    class Students
    {
        public static Student[] data;
        public Students()
        {
            data = new Student[100];
        }
        public Student this[int index]
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
    }
    class Student
    {

        public string Name { get; set; }
        public int Course { get; set; }
        public int Number { get; set; }


        public Student(string name, int course, int number)
        {
            Console.WriteLine("Введите имя.");
            Name = InputInfo.InputName();
            Console.WriteLine("Введите курс, на котором учится студент.");
            Course = InputInfo.InputNavigate1();
            Console.WriteLine("Введите номер зачетной книжки.");
            Number = InputInfo.InputInt();
        }
        public void Display()
        {
            Console.WriteLine($"Студент {Name}, учиться на {Course}-ом курсе, номер зачетной книжки: {Number}.");
        }

    }
    class Aspirants
    {
        public static Aspirant[] data;
        public Aspirants()
        {
            data = new Aspirant[100];
        }
        public Aspirant this[int index]
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
    }
    class Aspirant : Student
    {
        string CandidateDiss { get; set; }

        public Aspirant(string name, int course, int number, string candidatebook)
            : base(name, course, number)
        {
            Console.WriteLine("Введите название диссертации.");
            CandidateDiss = InputInfo.InputName();
        }
        public new void Display()
        {
            Console.WriteLine($"Студент {Name}, учиться на {Course}-ом курсе, номер зачетной книжки: {Number}, {CandidateDiss} - название диссертации.");
        }
    }
    class InputInfo
    {
        public static string InputName()
        {
            string name;
            bool isRight = false;
            do
            {
                name = Console.ReadLine();
                for (int i = 0; i < name.Length; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        if (name[i] == j.ToString()[0])
                        {
                            isRight = false;
                            break;
                        }
                        else
                        {
                            isRight = true;
                        }
                    }
                }
                if (isRight == false)
                {
                    Console.WriteLine("Введите имя, состоящее из букв. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return name;
        }
        public static int InputInt()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {if (number >= 0)
                    {
                        isRight = true;
                    }
                    else
                    {
                        Console.WriteLine("Введено отрицательное значение. Попробуйте снова.");
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
