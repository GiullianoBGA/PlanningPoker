namespace PlanningPokerBlazor.Client.Services
{
    public static class EnumServices
    {
        public static IList<SelectOption> GetOptions<T>()
        {
            var tipo = typeof(T);
            var result = Enum.GetNames(tipo).Select(
                item => new SelectOption
                {
                    Value = Enum.Parse(tipo, item),
                    Description = Enum.Parse(tipo, item).ToString(),
                }).ToList();

            return result;
        }
    }

    public class SelectOption
    {
        public object Value { get; set; }
        public string Description { get; set; }
    }
}
