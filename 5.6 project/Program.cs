/*Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
Имя;v
Фамилия;v
Возраст;v
Наличие питомца;v
Если питомец есть, то запросить количество питомцев; v
Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры); v
Запросить количество любимых цветов; v
Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры); v
Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе; v
Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен; v
Корректный ввод: ввод числа типа int больше 0.v
Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.v
Вызов методов из метода Main.v
*/

// (string Name, string LastName, int Age, bool HavePet, int PetNumber, string [] PetNames, int ColorNumber, string [] Colors) User;

class Programm
{
    static void Main(String[] args)
    {
        var User = EnterUser();
        Print(User);
    }

    static (string Name, string LastName, int Age, bool HavePet, int PetN, string[] Petnames, int ColorN, string[] Colors) EnterUser()
    {

        (string Name, string LastName, int Age, bool HavePet, int PetN, string[] Petnames, int ColorN, string[] Colors) User;

        Console.WriteLine("Введите имя");
        User.Name = Console.ReadLine();

        Console.WriteLine("Введите фамилию");
        User.LastName = Console.ReadLine();

        string Age;
        int Intage;
        do
        {
            Console.WriteLine("Введите возраст цифрами");
            Age = Console.ReadLine();
        }
        while (TryConvertToInt(Age, out Intage) == false);
        User.Age = Intage;

        Console.WriteLine("У Вас есть питомец? да/нет");
        string PetAnswer = Console.ReadLine();
        if (PetAnswer == "да")
        {
            User.HavePet = true;
        }
        else

        User.HavePet = false;

        if (PetAnswer == "да")
        {
            string PetNText;
            int PetNInt;
            do
            {
                Console.WriteLine("Введите количество питомцев");
                PetNText = Console.ReadLine();
            }
            while (TryConvertToInt(PetNText, out PetNInt) == false);
            User.PetN = PetNInt;
        }
        else
        User.PetN = 0;

        string [] PetnamesOut = new string [User.PetN];
        if (User.PetN > 0)
        {
         PetNamesAtion(User.PetN,PetnamesOut);
         User.Petnames = PetnamesOut;
        }
        else
            User.Petnames = null;
        
        string ColorNText;
        int ColorNInt;
        do
        {
            Console.WriteLine("Введите количество любимых цветов");
            ColorNText = Console.ReadLine();
        }
        while (TryConvertToInt(ColorNText, out ColorNInt) == false);
        User.ColorN = ColorNInt;

        string[] ColorOut = new string[User.ColorN];

            ColorsAtion(User.ColorN, ColorOut);
            User.Colors = ColorOut;

            return User;
    }
    
    static bool TryConvertToInt(string TextIn, out int IntOut)
    {
        return int.TryParse(TextIn, out IntOut) && IntOut > 0;
    }
     
    static string [] PetNamesAtion (int Num, string [] TextOut)
    {   
        
        for (int i = 0; i < Num; i++)
        {
            Console.WriteLine("Введите кличку питомца {0}", i+1);
            TextOut[i] = Console.ReadLine();
        }

        return TextOut;
    }
    static string[] ColorsAtion(int Num, string[] TextOut)
    {

        for (int i = 0; i < Num; i++)
        {
            Console.WriteLine("Введите цвет {0}", i + 1);
            TextOut[i] = Console.ReadLine();
        }

        return TextOut;
    }

    static void Print ((string Name, string LastName, int Age, bool HavePet, int PetN, string[] Petnames, int ColorN, string[] Colors) User)
    {
        Console.WriteLine($"Имя: {User.Name}");
        Console.WriteLine($"Фамилия: {User.LastName}");
        Console.WriteLine($"Возраст: {User.Age}");
        Console.WriteLine($"Наличие питомца: {( User.HavePet ? "Да" : "Нет")}" ); 
        Console.WriteLine($"Количество питомцев: {User.PetN}");
        if (User.HavePet == true)
        {
            for (int i = 0; i < User.Petnames.Length; i++)
            {
                Console.WriteLine($"Имя питомца {i + 1}: {User.Petnames[i]}");
            }
        }

        Console.WriteLine($"Количество любимых цветов: {User.ColorN}");
        for (int i = 0; i < User.Colors.Length; i++)
        {
            Console.WriteLine($"Цвет {i + 1}: {User.Colors[i]}");
        }
    }
}
