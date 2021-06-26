using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter
{
    public class NameSorter
    {
        private NameContainer[] _names = null;
        
        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File \"{filePath}\" not found");
            }
            try
            {
                _names = GetNamesFromFile(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Save(string filePath)
        {
            File.WriteAllLines(filePath, _names.Select(name => name.ToString()));
        }

        public void Print()
        {
            for (var i = 0; i < _names.Length; i++)
            {
                Console.WriteLine(_names[i]);
            }
        }

        public void Sort()
        {
            BubbleSort<NameContainer>.Sort(_names);
        }
        
        public static NameContainer[] GetNamesFromFile(string filePath)
        {
            using var fileStream = new StreamReader(filePath);
            List<NameContainer> results = new List<NameContainer>();
            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                results.Add(new NameContainer(line));
            }
            return results.ToArray();
        }
    }
}