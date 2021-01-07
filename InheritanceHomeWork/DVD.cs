using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceHomeWork
{
    public class DVD : Storage
    {
        //Скорость чтения и записи
        public double SpeedReadAndWrite { get; set; }
        //тип (односторонний (4.7 Гб) или двусторонний (9 Гб))
        public bool IsBilateral { get; set; } //Является Двухсторонним

        public override bool CopyingData(double memoryCapacity)
        {
            if (GetFreeMemorySpace() >= memoryCapacity)
            {
                OccupiedMemory += memoryCapacity;
                return true;
            }
            return false;
        }

        public override double GetFreeMemorySpace()
        {
            return GetMemoryCapacity() - OccupiedMemory;
        }

        public override void GetFullInformationAboutDevice()
        {
            double volume;
            if (IsBilateral) volume = 9;
            else volume = 4.7;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Название устройсва: {StorageName}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Скорость чтения/записи, : {SpeedReadAndWrite} Мбайт/сек");
            Console.WriteLine($"Тип односторонний/двусторонний: {IsBilateral}");
            Console.WriteLine($"Объем памяти: {volume} Гб");
        }

        public override double GetMemoryCapacity()
        { 
            if (IsBilateral) return 9;
            else return 4.7;
        }

        public override DateTime GetTimeForCopying(double memoryCapacity)
        {
            DateTime time = new DateTime();
            int seconds = Convert.ToInt32(memoryCapacity * 1024 / SpeedReadAndWrite);
            time.AddSeconds(seconds);
            return time;
        }
    }
}
