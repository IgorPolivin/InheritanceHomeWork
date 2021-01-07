using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceHomeWork
{
    public class Menu
    {
        private enum Actions
        {
            CalculateTotalMemory = 1,
            CopyingDataToDevice,
            CalculateTimeForCopying,
            CalculateNumberStorages
        }

        private const int countActions = 4;

        private static int SetAction()
        {
            int.TryParse(Console.ReadLine(), out int choose);
            if (choose > countActions || choose <= 0) choose = 0;
            return choose;
        }

        private static int ChooseStorage(Storage[] storages, int sizeArray)
        {
            for (int i = 0; i < sizeArray; i++)
            {
                Console.WriteLine($"\nУстройство №{i}");
                storages[i].GetFullInformationAboutDevice();
            }
            int choose;
            while (true)
            {
                Console.Write("\nВыберите утройство: ");
                if (!int.TryParse(Console.ReadLine(), out choose) || choose < 0 || choose >= sizeArray)
                    choose = -1;
                if (choose != -1)
                    break;
                else
                    Console.WriteLine("Неправильный индекс!");

            }
            return choose;
        }

        private static double GetGigabytes()
        {
            double memoryCapacity;
            while (true)
            {
                Console.Write("\nВведите количество Гигабайт: ");
                double.TryParse(Console.ReadLine(), out memoryCapacity); // requiredMemory - необходимая память
                if (memoryCapacity > 0)
                    break;
                else
                    Console.WriteLine("Вы ввели неправильное значение!");
            }
            return memoryCapacity;
        }


        public static void Run(Storage[] storages, int sizeArray)
        {
            while (true)
            {
                PrintMenu();
                int choose = SetAction();
                if (choose == 0) continue;
                Actions actionChoose = (Actions)choose;
                Console.Clear();
                DoAction(actionChoose, storages, sizeArray);
                Console.ReadLine();
            }
        }


        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\n------------------------MENU------------------------");
            Console.WriteLine("1. Расчет общего количества памяти всех устройств");
            Console.WriteLine("2. Копирование информации на устройства");
            Console.WriteLine("3. Расчет времени необходимого для копирования");
            Console.WriteLine("4. Расчет количества носителей для переноса информации");
            Console.Write("\nНомер действия: ");
        }

        private static void DoAction(Actions action, Storage[] storages, int sizeArray)
        {
            int storageIndex;
            double memoryCapacity;
            switch (action)
            {
                case Actions.CalculateTotalMemory:
                    double totelMemory = ActionClass.CalculateTotalMemory(storages);
                    Console.WriteLine($"Общее количества памяти всех устройств = {totelMemory}");
                    break;

                case Actions.CopyingDataToDevice:

                    storageIndex = ChooseStorage(storages, sizeArray);

                    memoryCapacity = GetGigabytes();

                    if (storages[storageIndex].CopyingData(memoryCapacity))
                        Console.WriteLine("Информация записана!");
                    else
                        Console.WriteLine("Недостаточно места!!!");
                    break;

                case Actions.CalculateTimeForCopying:

                    storageIndex = ChooseStorage(storages, sizeArray);

                    memoryCapacity = GetGigabytes();

                    DateTime time = ActionClass.CalculateTimeForCopying(storages[storageIndex], memoryCapacity);
                    Console.WriteLine($"Время необходимое для копирование - {time.TimeOfDay}");

                    break;

                case Actions.CalculateNumberStorages:

                    storageIndex = ChooseStorage(storages, sizeArray);

                    memoryCapacity = GetGigabytes();

                    int numberStorages = ActionClass.CalculateNumberStorages(storages[storageIndex], memoryCapacity);

                    Console.WriteLine($"для переноса информации необходимого {numberStorages} {storages[storageIndex].StorageName}");

                    break;
            }
        }
    }
}
