using System;

namespace InheritanceHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            DVD dvd = new DVD
            {
                StorageName = "DVD-диск",
                Model = "DVD-R Verbatim",
                IsBilateral = false,
                SpeedReadAndWrite = 22.16, //скорость = x16
                OccupiedMemory = 0
            };
            HDD hdd = new HDD 
            {
                StorageName = "съемный HDD",
                Model = "HDD PQI 2.5",
                SpeedUSBVersion2 = 60, //480 Мбит/сек
                CountSections = 1,
                VolumeSections = 500,
                OccupiedMemory = 0
            };

            Flash flash = new Flash
            {
                StorageName = "Flash-накопитель",
                Model = "Kingson swivl datatraveler",
                MemoryCapacity = 32,
                SpeedUSBVersion3 = 614.4, //4.8 Гбит/сек
                OccupiedMemory = 0
            };

            const int sizeArray = 3;
            Storage[] storages = new Storage[sizeArray] {dvd,hdd,flash};

            Menu.Run(storages,sizeArray);
        }
    }
}
