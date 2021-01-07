using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceHomeWork
{
    public class HDD : Storage
    {
        //скорость USB 2.0
        public double SpeedUSBVersion2 { get; set; } //Скорость в Мг/сек
        //количество разделов
        public int CountSections { get; set; }
        //Обхем разделов
        public double VolumeSections { get; set; } //Объем в Гб 

        public override double GetMemoryCapacity()
        {
            return VolumeSections;
        }

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
            Console.WriteLine($"Скорость USB 2.0: {SpeedUSBVersion2} Мбайт/сек");
            Console.WriteLine($"Количество разделов: {CountSections}");
            Console.WriteLine($"Объем разделов: {VolumeSections} Гб");
        }

        public override DateTime GetTimeForCopying(double memoryCapacity)
        {
            DateTime time = new DateTime();
            int seconds = Convert.ToInt32(memoryCapacity * 1024 / SpeedUSBVersion2);
            time = time.AddSeconds(seconds);
            return time;
        }

 
    }
}
