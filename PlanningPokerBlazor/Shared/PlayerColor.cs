namespace PlanningPokerBlazor.Shared
{
    public class PlayerColor
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
