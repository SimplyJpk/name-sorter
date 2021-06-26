using System.Linq;
using name_sorter;
using NUnit.Framework;

namespace name_sorter_tests
{
    public class SortReturnsExpected
    {
        [TestCase(new string[]
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            },
            new string[]
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"
            })]
        
        public void SortReturnsExpectedExample(string[] input, string[] expected)
        {
            // Arrange
            NameContainer[] inputNames = new NameContainer[input.Length];
            for (int index = 0; index < input.Length; index++)
            {
                inputNames[index] = new NameContainer(input[index]);
            }
            
            // Act
            BubbleSort<NameContainer>.Sort(inputNames);
            string[] sortedNames = inputNames.Select(n => n.FullName.ToString()).ToArray();
            
            // Assert
            CollectionAssert.AreEqual(sortedNames, expected);
        }
    }
}