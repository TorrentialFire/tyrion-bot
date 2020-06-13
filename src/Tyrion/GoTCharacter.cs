
namespace Tyrion
{
    public class GoTCharacter {
        public static readonly GoTCharacter[] Characters = {
            new GoTCharacter("bronn", "Bronn"), // 0
            new GoTCharacter("brynden", "Brynden Tully"), // 1
            new GoTCharacter("cersei", "Cersei Lannister"), // 2
            new GoTCharacter("hound", "Sandor \"The Hound\" Clegane"), // 3
            new GoTCharacter("jaime", "Jaime Lannister"), // 4
            new GoTCharacter("littlefinger", "Petyr \"Littlefinger\" Baelish"), // 5
            new GoTCharacter("olenna", "Olenna Tyrell"), // 6
            new GoTCharacter("renly", "Renly Baratheon"), // 7
            new GoTCharacter("tyrion", "Tyrion Lannister"), // 8
            new GoTCharacter("varys", "Varys \"The Spider\"") // 9
        };

        public string Term { get; set; }
        public string Name { get; set; }
        public GoTCharacter(string term, string name)
        {
            Term = term;
            Name = name;
        }
    }
}