namespace PlanningPokerBlazor.Shared
{
    public class UpdateGameRequest
    {
        public IEnumerable<GamePlay> GamePlays { get; set; }
        public EnumPlayerType? PlayerType { get; set; } = null;
    }
}
