using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceHomeWork
{
    public static class ActionClass
    {
        public static double CalculateTotalMemory(Storage[] storeges)
        {
            double totalMemory = 0;
            foreach(var el in storeges)
            {
                totalMemory += el.GetMemoryCapacity();
            }
            return totalMemory;
        }

        public static DateTime CalculateTimeForCopying(Storage storage, double memoryCapacity)
        {
            DateTime time = new DateTime();
            if (memoryCapacity > 0 && memoryCapacity <= storage.GetMemoryCapacity())
            {
                time = storage.GetTimeForCopying(memoryCapacity);

            }
            return time;
        }

        public static int CalculateNumberStorages(Storage storage, double memoryCapacity)
        {
            return Convert.ToInt32(Math.Ceiling(memoryCapacity / storage.GetMemoryCapacity()));
        }

        //public static Storage CopyingDataToDevice(Storage storage, double memoryСapacity)
        //{
        //    storage.CopyingData(memoryСapacity);
        //}
    }
}
