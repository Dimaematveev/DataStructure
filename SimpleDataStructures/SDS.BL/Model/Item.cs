using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BL.Model
{
    public class Item<T>
    {
        public T Data { get; private set; }

        public Item<T> Next = null;

        public Item(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Данные не должны быть пустыми!", nameof(Data));
            }
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
