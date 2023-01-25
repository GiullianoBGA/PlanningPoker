namespace PlanningPokerBlazor.Shared
{
    public class Room
    {
        public Room()
        {
        }

        public Room(string connectionId)
        {
            ConnectionId = connectionId;
        }

        public string ConnectionId { get; }
        public string GameId { get; set; }
        public string Time { get; set; }
        public EnumPlayerType GameType { get; set; }
        public string Sequence { get; set; }
        public List<PlayerColor> PlayerColors { get; set; } = new()
        {
            new PlayerColor { Id = 1, Color = "blue" },
            new PlayerColor { Id = 2, Color = "red" },
            new PlayerColor { Id = 3, Color = "darkblue" },
            new PlayerColor { Id = 4, Color = "green" },
            new PlayerColor { Id = 5, Color = "black" },
            new PlayerColor { Id = 6, Color = "brown" },
            new PlayerColor { Id = 7, Color = "orange" },
            new PlayerColor { Id = 8, Color = "purple" },
            new PlayerColor { Id = 9, Color = "lightblue" },
            new PlayerColor { Id = 10, Color = "saddlebrown" },
            new PlayerColor { Id = 11, Color = "yellowgreen" },
            new PlayerColor { Id = 12, Color = "lightgreen" },
            new PlayerColor { Id = 13, Color = "darkslategray" },
            new PlayerColor { Id = 14, Color = "sandybrown" },
            new PlayerColor { Id = 15, Color = "coral" },
            new PlayerColor { Id = 16, Color = "salmon" },
        };

        public List<StyleCSS> PlayerCSSes { get; set; } = new()
        {
            new StyleCSS { Id = 1, Top = -12, Left = 45, Right = 0 },
            new StyleCSS { Id = 2, Top = -12, Left = 73, Right = 0 },
            new StyleCSS { Id = 3, Top = 37, Left = 94, Right = 0 },
            new StyleCSS { Id = 4, Top = 93, Left = 73, Right = 0 },
            new StyleCSS { Id = 5, Top = 93, Left = 45, Right = 0 },
            new StyleCSS { Id = 6, Top = 93, Left = 18, Right = 0 },
            new StyleCSS { Id = 7, Top = 37, Left = -5.5M, Right = 0 },
            new StyleCSS { Id = 8, Top = -12, Left = 18, Right = 0 },
            new StyleCSS { Id = 9, Top = -1, Left = 0, Right = 0 },
            new StyleCSS { Id = 10, Top = 80, Left = -1, Right = 0 },
            new StyleCSS { Id = 11, Top = -3, Left = 88, Right = 0 },
            new StyleCSS { Id = 12, Top = 80, Left = 90, Right = 0 },
            new StyleCSS { Id = 13, Top = -12, Left = 30, Right = 0 },
            new StyleCSS { Id = 14, Top = 93, Left = 30, Right = 0 },
            new StyleCSS { Id = 15, Top = -12, Left = 62, Right = 0 },
            new StyleCSS { Id = 16, Top = 93, Left = 62, Right = 0 },
        };

        public List<StyleCSS> CardCSSes { get; set; } = new()
        {
            new StyleCSS { Id = 1, Top = 18, Left = 50, Right = 0 },
            new StyleCSS { Id = 2, Top = 18, Left = 0, Right = 15 },
            new StyleCSS { Id = 3, Top = 48, Left = 0, Right = 2.5M },
            new StyleCSS { Id = 4, Top = 82, Left = 0, Right = 15 },
            new StyleCSS { Id = 5, Top = 82, Left = 50, Right = 0 },
            new StyleCSS { Id = 6, Top = 82, Left = 22, Right = 0 },
            new StyleCSS { Id = 7, Top = 48, Left = 10, Right = 0 },
            new StyleCSS { Id = 8, Top = 18, Left = 22, Right = 0 },
            new StyleCSS { Id = 9, Top = 22, Left = 14, Right = 0 },
            new StyleCSS { Id = 10, Top = 75, Left = 14, Right = 0 },
            new StyleCSS { Id = 11, Top = 22, Left = 0, Right = 7 },
            new StyleCSS { Id = 12, Top = 75, Left = 0, Right = 7 },
            new StyleCSS { Id = 13, Top = 18, Left = 35.5M, Right = 0 },
            new StyleCSS { Id = 14, Top = 82, Left = 35.5M, Right = 0 },
            new StyleCSS { Id = 15, Top = 18, Left = 0, Right = 23.5M },
            new StyleCSS { Id = 16, Top = 82, Left = 0, Right = 23.5M },
        };

        public List<StyleCSS> PlayerCSSesRedondo { get; set; } = new()
        {
            new StyleCSS { Id = 1, Top = -10, Left = 50, Right = 0 },
            new StyleCSS { Id = 2, Top = -10, Left = 0, Right = 15 },
            new StyleCSS { Id = 3, Top = 42, Left = 0, Right = -5.75M },
            new StyleCSS { Id = 4, Top = 100.75M, Left = 0, Right = 15 },
            new StyleCSS { Id = 5, Top = 100.75M, Left = 50, Right = 0 },
            new StyleCSS { Id = 6, Top = 100.75M, Left = 22, Right = 0 },
            new StyleCSS { Id = 7, Top = 42, Left = 1M, Right = 0 },
            new StyleCSS { Id = 8, Top = -10, Left = 22, Right = 0 },
            new StyleCSS { Id = 9, Top = 0, Left = 7, Right = 0 },
            new StyleCSS { Id = 10, Top = 88, Left = 7, Right = 0 },
            new StyleCSS { Id = 11, Top = 0.01M, Left = 0, Right = 0.01M },
            new StyleCSS { Id = 12, Top = 90, Left = 0, Right = 0.01M },
            new StyleCSS { Id = 13, Top = -10, Left = 31, Right = 0 },
            new StyleCSS { Id = 14, Top = 100.75M, Left = 31, Right = 0 },
            new StyleCSS { Id = 15, Top = -10, Left = 0, Right = 24 },
            new StyleCSS { Id = 16, Top = 100.75M, Left = 0, Right = 24 },
        };

        public List<StyleCSS> CardCSSesBkp { get; set; } = new()
        {
            new StyleCSS { Id = 1, Top = 18, Left = 50, Right = 0 },
            new StyleCSS { Id = 2, Top = 18, Left = 0, Right = 15 },
            new StyleCSS { Id = 3, Top = 48, Left = 0, Right = 2.5M },
            new StyleCSS { Id = 4, Top = 82, Left = 0, Right = 15 },
            new StyleCSS { Id = 5, Top = 82, Left = 50, Right = 0 },
            new StyleCSS { Id = 6, Top = 82, Left = 22, Right = 0 },
            new StyleCSS { Id = 7, Top = 48, Left = 10, Right = 0 },
            new StyleCSS { Id = 8, Top = 18, Left = 22, Right = 0 },
            new StyleCSS { Id = 9, Top = 22, Left = 14, Right = 0 },
            new StyleCSS { Id = 10, Top = 75, Left = 14, Right = 0 },
            new StyleCSS { Id = 11, Top = 22, Left = 0, Right = 7 },
            new StyleCSS { Id = 12, Top = 75, Left = 0, Right = 7 },
            new StyleCSS { Id = 13, Top = 18, Left = 33, Right = 0 },
            new StyleCSS { Id = 14, Top = 82, Left = 33, Right = 0 },
            new StyleCSS { Id = 15, Top = 18, Left = 0, Right = 23.5M },
            new StyleCSS { Id = 16, Top = 82, Left = 0, Right = 23.5M },
        };
    }
}