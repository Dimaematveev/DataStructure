using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BL.Model
{
    /// <summary>
    /// Связный список.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>:IEnumerable
    {
        /// <summary>
        /// Голова
        /// </summary>
        public Item<T> Head;
        /// <summary>
        /// Хвост
        /// </summary>
        public Item<T> Tail;
        /// <summary>
        /// Количество элементов
        /// </summary>
        public int Count { get; private set; }

        public LinkedList()
        {
            EmptyList();
        }

        

        public LinkedList(T data)
        {
            Initialization(data);
        }

        /// <summary>
        /// Добавить список элементов
        /// </summary>
        /// <param name="datas">Массив элементов для добавления</param>
        public void Add(IEnumerable<T> datas)
        {
            foreach (var data in datas)
            {
                Add(data);
            }
        }

        /// <summary>
        /// Добавить один элемент
        /// </summary>
        /// <param name="data">Элемент для домавления</param>
        public void Add(T data)
        {
            if (Count==0)
            {
                Initialization(data);
                return;
            }
            var item = new Item<T>(data);
            Tail.Next = item;
            Tail = item;
            Count++;
        }
        /// <summary>
        /// Удалить первый элемент
        /// </summary>
        /// <param name="data">Элемент который надо удалить</param>
        /// <returns>true если получилось удалить, false не получилось удалить</returns>
        public bool RemoveFirst(T data)
        {
            var current = Head;
            if (Count==0)
            {
                return false;
            }

            if (Count==1)
            {
                if (Head.Data.Equals(data))
                {
                    EmptyList();
                    return true;
                }
                return false;
            }

            if (Head.Data.Equals(data))
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            while(current.Next!=null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        /// <summary>
        /// Удаляет все вхождения элемента
        /// </summary>
        /// <param name="item">Элемент для удаления</param>
        /// <returns>true если получилось удалить, false не получилось удалить</returns>
        public bool RemoveAll(T item)
        {
            bool ret = RemoveFirst(item);
            if (ret)
            {
                while (RemoveFirst(item)) { }
            }
            return ret;
        }
        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            EmptyList();
        }

        /// <summary>
        /// Пустой список.
        /// </summary>
        private void EmptyList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        /// <summary>
        /// Список с одним элементом
        /// </summary>
        /// <param name="data"></param>
        private void Initialization(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Для цикла foreach
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null) 
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
