using System;

namespace name_sorter
{
    static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("file path was not given as arg");
            }

            NameSorter nameSorter = new NameSorter();
            nameSorter.Load(args[0]);
            nameSorter.Sort();
            
            nameSorter.SaveToDisk("sorted-names-list.txt");
            nameSorter.Print();
        }
    }
}