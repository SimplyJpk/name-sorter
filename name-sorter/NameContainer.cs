using System;
using System.Linq;

namespace name_sorter
{
    /// <summary>
    /// Class that holds a full name of 0-3 given names, and at least 1 surname.
    /// </summary>
    public class NameContainer : IComparable<NameContainer>
    {
        public string FullName { get; }
        private readonly string[] _names;
        
        public NameContainer(string fullName)
        {
            FullName = fullName;
            _names = fullName.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (_names.Length is < 1 or > 4)
            {
                throw new Exception("Full name must contain 1-4 Names.");
            }
        }

        public string Surname => _names[^1];

        /// <summary>
        /// Returns a given name using the index provided, returning an empty string if index is out of range or would return Surname.
        /// </summary>
        /// <param name="index">Given name, 0-2</param>
        /// <returns>Given name at Index, from 0</returns>
        public string NthGivenName(uint index)
        {
            if (_names.Length - 1 > index)
            {
                return _names[index];
            }
            return string.Empty;
        }

        public string GetGivenNames()
        {
            return string.Join(" ", _names.Where(n => n != Surname));
        }
        
        public int CompareTo(NameContainer other)
        {
            return string.Compare(ToSortOrderSpelling(), other.ToSortOrderSpelling(),
                StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary> Orders names how the sort is expecting.</summary>
        /// <returns>Surname followed by all Given names</returns>
        public string ToSortOrderSpelling()
        {
            return $"{Surname} {GetGivenNames()}";
        }

        public override string ToString() => FullName;
    }
}