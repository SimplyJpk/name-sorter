using System;

namespace name_sorter
{
    public static class BubbleSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] items)
        {
            bool changed = false;
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - i - 1; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) >= 0)
                    {
                        var temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        changed = true;
                    }
                }
                if (changed == false)
                    break;
            }
        }
    }
}