using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{
	public class Kata
	{
		//returns square of every digit of a number
		public static int SquareDigits(int n)
		{
			if (n == 0) return 0;
			string s = "";
			while (n > 0)
			{
				var x = n % 10;
				s = Convert.ToString(x * x) + s;
				n = n / 10;
			}
			return Convert.ToInt32(s);
		}
		public static int SquareDigitsBest(int n)
		{
			return int.Parse(String.Concat(n.ToString().Select(a => (int)Math.Pow(char.GetNumericValue(a), 2))));
		}
		public static string OrderByDigitInWord(string words)
		{
			string s = "";
			var parsed = words.Split(' ');
			int i = 0;
			int n = parsed.Length;
			string[] ss = new string[n];
			foreach (var digit in words.Where(c => char.IsDigit(c)).Select(c => c - '0' - 1))
			{
				ss[digit] = parsed[i++];
				if (digit != n - 1) { ss[digit] += " "; }
			}
			foreach (var sss in ss)
				s += sss;
			return s;
		}
		public static string OrderByDigitInWordBest(string words)
		{
			if (string.IsNullOrEmpty(words)) return words;

			return string.Join(" ", words.Split().OrderBy(w => w.SingleOrDefault(char.IsDigit)));
		}
		//find an index N where the sum of the integers to the left of N 
		//is equal to the sum of the integers to the right of N
		public static int FindEvenIndex(int[] arr)
		{
			int n = arr.Length;
			for (int i = 0; i < n; ++i)
			{
				int left_sum = 0, right_sum = 0;
				int j = i;
				while (j > 0) left_sum += arr[--j];
				j = i;
				while (j < n - 1) right_sum += arr[++j];
				if (left_sum == right_sum) return i;
			}
			return -1;
		}
		public static int FindEvenIndexBest1(int[] arr)
		{
			for (var i = 0; i < arr.Length; i++)
			{
				if (arr.Take(i).Sum() == arr.Skip(i + 1).Sum()) { return i; }
			}
			return -1;
		}
		public static int FindEvenIndexBest2(int[] arr)
		{
			int leftSum = 0, rightSum = arr.Sum();
			for (int i = 0; i < arr.Length; ++i)
			{
				rightSum -= arr[i];
				if (leftSum == rightSum)
				{
					return i;
				}
				leftSum += arr[i];
			}
			return -1;
		}
		public static int[] ArrayDiff(int[] a, int[] b)
		{
			foreach (var diff in b)
				a = a.Where(i => i != diff).ToArray();
			return a;
		}
		public static int[] ArrayDiffBest(int[] a, int[] b)
		{
			return a.Where(n => !b.Contains(n)).ToArray();
		}
		public static int sumTwoSmallestNumbers(int[] numbers)
		{
			var list = numbers.ToList();
			list.Sort();
			return list[0] + list[1];
		}
		public static int sumTwoSmallestNumbersBest(int[] numbers)
		{
			return numbers.OrderBy(i => i).Take(2).Sum();
		}
		public static string Accum(string s)
		{
			int i = 0;
			int n = s.Length;
			return s.Aggregate("", (str, c) => str += char.ToUpper(c) + new string(char.ToLower(c), i++) + (i < n ? "-" : ""));
		}
		public static string AccumBest(string s)
		{
			return string.Join("-", s.Select((x, i) => char.ToUpper(x) + new string(char.ToLower(x), i)));
		}
		public static string SpinWords(string sentence)
		{
			return string.Join(" ", sentence.Split().Select(str => str.Length < 5 ? str : new string(str.Reverse().ToArray())));
		}
        public static int MaxSequence(int[] arr)
        {
            int n = arr.Length;
            int max = 0;
            for (int i = n; i >= 0; i--)
            {
                for (int j = 0; j <= n - i; j++)
                {
                    var x = arr.Skip(j).Take(i);
                    var sum = x.Sum();
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }
            return max;
        }
        public static int MaxSequenceBest(int[] arr)
        {
            foreach (var item in arr)
                Console.Write(item + " ");
                int max = 0, res = 0, sum = 0;
            foreach (var item in arr)
            {
                sum += item;
                max = sum > max ? max : sum;
                res = res > sum - max ? res : sum - max;
                Console.Write($"\n{sum}\t{max}\t{res}");
            }
            return res;
        }
        public static long digPow(int n, int p)
        {
            var x = Convert.ToInt64(n.ToString().ToCharArray().Select((c, i) => Math.Pow(c - '0', i + p)).Sum());
            return x % n == 0 ? x / n : -1;
        }
        public static long digPowBest(int n, int p)
        {
            var x = n.ToString().Select(c => (int)Math.Pow(char.GetNumericValue(c), p++)).Sum();
            return x % n == 0 ? x / n : -1;
        }
        public static bool comp(int[] a, int[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;
            var B = b.OrderBy(s => s);
            var sum = a.OrderBy(s => s).Select((n, i) => Math.Abs(n * n - B.ElementAt(i))).Sum();
            return sum > 0 ? false : true;
        }
        public static bool compBest(int[] a, int[] b)
        {
            return !(a?.Length != b?.Length) && a.Select(x => x * x).OrderBy(o => o).SequenceEqual(b.OrderBy(o => o));
        }
        public static int[] DeleteNth(int[] arr, int x)
        {
            return arr.Where((element, i) => arr.Take(i).Count(a => a == element) < x).ToArray();
        }
        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n < 4)
                return signature.Take(n).ToArray();
            var res = signature.ToList();
            for (int i = 3; i < n; i++)
            {
                res.Add(res[i - 3] + res[i - 2] + res[i - 1]);
            }
            return res.ToArray();
        }
        public static int CountSmileys(string[] smileys)
        {
            return smileys.Count(str
                => str.Length == 2 && (str[0].Equals(':') || str[0].Equals(';')) && (str[1].Equals(')') || str[1].Equals('D'))
                || str.Length == 3 && (str[0].Equals(':') || str[0].Equals(';')) && (str[1].Equals('-') || str[1].Equals('~')) && (str[2].Equals(')') || str[2].Equals('D'))
                   );
        }
        public static int CountSmileysBests(string[] smileys)
        {
            //Read regular expressions.
            return Regex.Matches(string.Join(" ", smileys), "([:;][-~]?)[)D]").Count;
            //return smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
        }
    }
}
