using System;

namespace Algorithms_Performance_Visualizer.Helpers {
    public static class StringHelper {
        static readonly Random rg = new Random();

        public static string NewString(int length) {
            char[] chars = new char[length];
            for(int n = 0; n < chars.Length; n++) {
                chars[n] = NewChar();
            }
            return new string(chars);
        }
        public static string Substring(string s) {
            int index1 = rg.Next(s.Length);
            int index2 = rg.Next(s.Length);
            int lo = Math.Min(index1, index2);
            int hi = Math.Max(index1, index2);
            int sz = Math.Min(8, hi - lo + 1);
            return s.Substring(lo, sz);
        }
        public static string[] NewStrings(int size) {
            string[] @strings = new string[size];
            for(int n = 0; n < strings.Length; n++) {
                strings[n] = NewString(1 + rg.Next(15));
            }
            return strings;
        }
        public static string GetWord(string[] strings) {
            return strings[rg.Next(strings.Length)];
        }
        public static string UniqueString() {
            return new string((char)1111, 1 + rg.Next(8));
        }
        static char NewChar() => (char)rg.Next(256);
    }
}