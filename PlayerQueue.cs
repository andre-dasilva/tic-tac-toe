using System;
using System.Collections.Generic;

namespace tic_tac_toe
{
    public class PlayerQueue<T>
    {
        private int currentIndex = 0;
        private List<T> queue;

        public PlayerQueue(int size)
        {
            if (size < 2)
            {
                throw new ArgumentException("Size must be bigger than 2");
            }
            queue = new List<T>(size);
        }

        public void Enqueue(T entity)
        {
            queue.Add(entity);
        }

        public T GetNext()
        {
            CheckIndex();
            T element = queue[currentIndex];
            currentIndex++;
            return element;
        }

        public void CheckIndex()
        {
            if (currentIndex > queue.Count - 1)
            {
                currentIndex = 0;
            }
        }
    }
}