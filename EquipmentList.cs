using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker
{
    internal class EquipmentList
    {
        private List<Equipment> equipmentList = [];
        private List<Equipment> sortedList = [];

        public void Add(Equipment item)
        {
            equipmentList.Add(item);
        }

        public void Remove(int index)
        {
            equipmentList.RemoveAt(index);
        }

        public void List(string method)
        {
            switch (method) 
            {
                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;
            }
        }
    }
}
