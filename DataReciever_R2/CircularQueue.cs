using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReciever
{
    class CircularQueue<T>
    {
        public CircularQueue(int size)
        {
            _size = size;
        }

        private Queue<T> queue = new Queue<T>();


        private readonly int _size;                 //definuje maximální velikost fronty než začne odhazovat nejstarší prvek ze skály
        
        public int Size { get { return _size; } }
        
        /// <summary>
        /// Přidá pravek do fronty. Pokud fronta není plná prostě ho přidá, pokud fronta je plná udělá si místo tak že odhodí nejstarší prvek ze skály
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (queue.Count >= _size)
            {
                queue.Dequeue();
            }
            queue.Enqueue(item);
        }
        /// <summary>
        /// Vrátí nejstarší prvek fronty a odstraní ho z fronty
        /// </summary>
        /// <returns><T></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return queue.Dequeue();
        }

        //už chápu co jsou to lambda výrazy -> udělám medodu uvnitř svoji třídy, ale mohu ji poslat dělat něco jiného co je definované v jiné metodě

        public T[] ToArray() => queue.ToArray();        //Vrátí frontu jako pole
        public List<T> ToList()
        {
            List<T> result = new List<T>();
            foreach (T item in queue)
            {
                result.Add(item);
            }
            return result;
        }

        public int Count => queue.Count;                //Vrátí velikost fronty
        public void Clear() => queue.Clear();           //Smaže celou frontu
    }
}
