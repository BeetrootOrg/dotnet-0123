namespace BookLibrary
{
    public class Card
    {
        public Member Member { get; set; }
        public BookInCard[] Books { get; set; } 

        public Card(Member member)
        {
            Member = member;
            Books = Array.Empty<BookInCard>();
        }
    }
} 