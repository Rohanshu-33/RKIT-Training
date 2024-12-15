using System;

namespace CSharp_Basics
{
    internal class StringClassDemo
    {
        internal static void StringClassMethods()
        {
            string str = "Rohanshu Banodha";
            int len = str.Length;

            string str2 = "Rohanshu Banodha";

            //Console.WriteLine(str2.Equals(str));
            // Only 1 instance of string literal is created
            // in string intern pool of heap memory and they are
            // referenced by string objects

            //string ans = string.Concat(str, " ", str2, " hello", " abc");
            //Console.WriteLine(ans);

            string s1 = "ebc";
            string s2 = "ebc";
            //Console.WriteLine(string.Compare(s1, s2));  // +1|-1|0

            //List<string> list = new List<string>() { "a", "b"};
            //Console.WriteLine(string.Concat(list));

            //Console.WriteLine(string.Intern(s1));  // reference of s1 variable

            //string s3 = "   ";
            //bool ans = string.IsNullOrEmpty(s3);
            //Console.WriteLine(ans);
            //bool ans = string.IsNullOrWhiteSpace(s3);
            //Console.WriteLine(ans);

            //Console.WriteLine(string.Join("--", s1, s2, "abc"));

            //bool ans = string.ReferenceEquals(s1, s2);
            //Console.WriteLine(ans);

            //s1.Clone(); // returns a reference to this string.
            //Console.WriteLine(s1.CompareTo(s2));  // +1|-1|0

            //Console.WriteLine(s1.Contains('e'));
            //Console.WriteLine(s1.Contains("ee"));

            //s1 = "aabcc";
            //string anss = s1.ToString();
            //string ans = s1.Distinct().ToString();
            //string ans2 = new string(s1.Distinct().ToArray());
            //Console.Write(anss + ans + ans2);

            //string sentence = " My name is Rohanshu Banodha        ";
            //Console.WriteLine(sentence.Length + " " + sentence.Trim() + " " + sentence.Trim().Length);
            //Console.WriteLine(sentence.ToUpper());
            //Console.WriteLine(sentence.Replace("Banodha", ""));
            //Console.WriteLine(sentence.Substring(1, 5));

            //string data = "a,b,c,d,e,f,g,h";
            //string[] arr = data.Split(",");
            //Console.WriteLine(string.Join(" ", arr));
        }
    }
}
