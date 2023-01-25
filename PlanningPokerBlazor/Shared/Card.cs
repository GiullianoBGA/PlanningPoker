namespace PlanningPokerBlazor.Shared
{
    public class Card
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public int SortOrder { get; set; }

        public bool Flipped { get; set; } = false;
        public string Color { get; set; } = "white";
    }
}
