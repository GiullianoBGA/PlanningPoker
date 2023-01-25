namespace PlanningPokerBlazor.Shared
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public bool ExperimentalFeatures { get; set; } = true;
        public EnumMemberType MemberType { get; set; }
        public EnumPlayerType PlayerType { get; set; }
        public PlayerColor PlayerColor { get; set; }
        public StyleCSS PlayerCSS { get; set; }
        public StyleCSS CardCSS { get; set; }
    }
}
