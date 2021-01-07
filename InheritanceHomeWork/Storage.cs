using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceHomeWork
{
    public abstract class Storage
    {
        public string StorageName { get; set; }
        public string Model { get; set; }
        public double OccupiedMemory { get; set; }

        //Получение объема памяти
        public abstract double GetMemoryCapacity();

        //Копирование данных на устройство
        public abstract bool CopyingData(double memoryCapacity);

        //Получение информации о свободном объеме памяти на устройстве
        public abstract double GetFreeMemorySpace();

        //Получение полной информации об устройстве
        public abstract void GetFullInformationAboutDevice();

        //Расчет времени необходимого для копирования
        public abstract DateTime GetTimeForCopying(double memoryCapacity);



    }
}
