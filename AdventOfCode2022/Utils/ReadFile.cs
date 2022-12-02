namespace Utils
{
    public class ReadFile
    {
        public static List<string> ReadLines(string path)
        {
            return File.ReadLines(path).ToList();
        }
    }
}