using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BL.Model
{
    public class LinkedList<T>:IEnumerable
    {
        public Item<T> Head;
        public Item<T> Tail;
        public int Count { get; private set; }

        public LinkedList()
        {
            EmptyList();
        }

        

        public LinkedList(T data)
        {
            Initialization(data);
        }

        

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

        public bool RemoveAll(T item)
        {
            bool ret = RemoveFirst(item);
            if (ret)
            {
                while (RemoveFirst(item)) { }
            }
            return ret;
        }

        public void Clear()
        {
            EmptyList();
        }
        private void EmptyList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        private void Initialization(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

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
