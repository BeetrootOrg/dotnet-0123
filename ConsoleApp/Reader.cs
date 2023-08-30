using System.Diagnostics.CodeAnalysis;

namespace BookLibrary
{
    public class Reader
    {
        public required int Id { get; init; }

        public required string Name { get; init;}
        public Reader() {}

        [SetsRequiredMembers]
        public Reader(int id, string name)
        {
           Id = id;
           Name = name; 
        }
    }
}