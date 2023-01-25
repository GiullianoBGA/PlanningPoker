namespace PlanningPokerBlazor.Shared
{
    public class Game
    {
        public string Id { get; set; } // TODO: Atualizar para int
        public string Time { get; set; }
        public string Sequence { get; set; } = "1;2;4;8;12;16;20;24;32;";
        public EnumPlayerType GameType { get; set; }
    }
}
