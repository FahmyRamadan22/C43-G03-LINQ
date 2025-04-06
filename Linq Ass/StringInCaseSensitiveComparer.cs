namespace Assignment
{
    internal class StringInCaseSensitiveComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return string.Compare(x, y, true);
        }
    }
}
