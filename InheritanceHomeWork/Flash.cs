using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceHomeWork
{
    public class Flash : Storage
    {
        //скорость USB 3.0
        public double SpeedUSBVersion3 { get; set; } //Скорость в Мг/сек
        //объем памяти;
        public double MemoryCapacity { get; set; }//Скорость в Гб

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
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Название устройсва: {StorageName}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Cкорость USB 3.0, : {SpeedUSBVersion3} Мбайт/сек");
            Console.WriteLine($"Объем памяти: {MemoryCapacity} Гб");
        }

        public override double GetMemoryCapacity()
        {
            return MemoryCapacity;
        }

        public override DateTime GetTimeForCopying(double memoryCapacity)
        {
            DateTime time = new DateTime();
            int seconds = Convert.ToInt32(memoryCapacity * 1024 / SpeedUSBVersion3);
            time.AddSeconds(seconds);
            return time;
        }
    }
}
