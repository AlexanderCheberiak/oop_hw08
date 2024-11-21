using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    //Код порушував принцип Single Responsibility.
    //Для виправлення перерозподілив відповідальності початкового класу між кількома новими.
    class Item
    {
    }

    // Відповідальність за управління списком товарів у замовленні
    class Order
    {
        private List<Item> itemList;

        public Order()
        {
            itemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public void DeleteItem(Item item)
        {
            itemList.Remove(item);
        }

        public int GetItemCount()
        {
            return itemList.Count;
        }

        public IEnumerable<Item> GetItems()
        {
            return itemList;
        }

        public decimal CalculateTotalSum()
        {
            return 0;
        }
    }

    // Відповідальність за представлення замовлення
    class OrderPrinter
    {
        public void PrintOrder(Order order)
        {
        }

        public void ShowOrder(Order order)
        {
        }
    }

    // Відповідальність за роботу з даними (збереження, завантаження тощо)
    class OrderRepository
    {
        public void Save(Order order)
        {
        }

        public Order Load(int orderId)
        {
            return new Order();
        }

        public void Update(Order order)
        {
        }

        public void Delete(int orderId)
        {
        }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}

