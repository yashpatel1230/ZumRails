namespace ZumRailsAPI.Validators
{
    public static class ZumRailsValidator
    {
        public static bool IsSortByValid(string input)
        {
            return input switch
            {
                "id" => true,
                "reads" => true,
                "likes" => true,
                "popularity" => true,
                _ => false,
            };
        }

        public static bool IsDirectionValid(string direction)
        {
            return direction switch
            {
                "asc" => true,
                "desc" => true,
                _ => false,
            };
        }
    }
}