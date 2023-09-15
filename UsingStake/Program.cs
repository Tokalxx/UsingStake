namespace UsingStake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Bone of My Sword";
            string reverseStr = ReverseMethod(str);

            for (int i = str.Length; i > 0; i--)
            {
                Console.Write(str[i - 1]);
            }
            Console.WriteLine("\n" + reverseStr);
        }

        public static string ReverseMethod(string word)
        {
            Stack<char> chars = new Stack<char>();

            foreach (char x in word)
            {
                chars.Push(x);
            }

            char[] charArray = new char[word.Length];
            int num = 0;

            while (chars.Count > 0)
            {
                charArray[num] = chars.Pop();
                num++;
            }

            return new string(charArray);
        }
    }
}