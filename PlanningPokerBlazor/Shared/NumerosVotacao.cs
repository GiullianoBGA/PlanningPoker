//namespace PlanningPokerBlazor.Shared
//{
//    public static class NumerosVotacao
//    {
//        public static Deck Deck = new()
//        {
//            Cards = Sequencia()
//            //Cards = new List<Card>
//            //{
//            //    new Card{ Text="1", Value="1", SortOrder=0 },
//            //    new Card{ Text="2", Value="2", SortOrder=1 },
//            //    new Card{ Text="3", Value="3", SortOrder=2 },
//            //    new Card{ Text="5", Value="5", SortOrder=3 },
//            //    new Card{ Text="8", Value="8", SortOrder=4 },
//            //    new Card{ Text="13", Value="13", SortOrder=5 },
//            //    new Card{ Text="21", Value="21", SortOrder=6 }
//            //}
//        };

//        private static List<Card> Sequencia()
//        {
//            //List<int> Fibonacci = new() { 0, 1 };
//            List<int> Fibonacci = new() { 0, 1 };

//            //for (int i = 2; i < 12; i++)
//            for (int i = 1; i < 8; i++)
//            {
//                Fibonacci.Add((Fibonacci[i - 1] == 0 ? 1 : Fibonacci[i - 1]) + Fibonacci[i]);
//            }
            
//            Fibonacci = new();
//            Fibonacci.AddRange(new List<int> { 1, 2, 4, 8, 12, 16, 20, 24, 32 });

//            return Fibonacci.Select(s => new Card
//            {
//                Text = s.ToString(),
//                Value = s.ToString(),
//            }).ToList();
//        }
//    }
//}
