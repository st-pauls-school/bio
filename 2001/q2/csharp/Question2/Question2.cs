using System;
using System.Linq;
using System.Text;

namespace BIO2001
{
	public class Question2
	{
		readonly string _gridLeft;
		readonly string _gridRight; 

		public string Left { get { return Interlace(_gridLeft); } }
		public string Right { get { return Interlace(_gridRight); } }

		public Question2(string seedLeft, string seedRight)
		{
			_gridLeft = Generate(true, seedLeft.ToUpperInvariant());
			_gridRight = Generate(false, seedRight.ToUpperInvariant());
		}



		string Generate(bool left, string seed)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in seed.Where(x => x != 'Q').Select(x => x).Distinct())
				sb.Append(c);

			byte a = Encoding.ASCII.GetBytes("A")[0];

			for (int i = 0; i < 26; i++)
			{
				char letter = (char)(a + i);
				if (letter != 'Q' && !seed.Contains(letter))
					sb.Append(letter);
			}

			string rv = sb.ToString();
			if (!left)
			{
				char[] charArray = rv.ToCharArray();
				Array.Reverse(charArray);
				return new string(charArray);
			}

			return rv;				
		}

		string Interlace(string str)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in str)
				sb.AppendFormat("{0} ", c);
			return sb.ToString().TrimEnd();
		}

		Tuple<int, int> Locate(string key, char target)
		{
			int pos = key.IndexOf(target);
			return new Tuple<int, int>(pos / 5, pos%5);
		}

		char Neighbour(string target, Tuple<int, int> pos, int offset)
		{
			return target[(pos.Item1 * 5) + ((pos.Item2 + offset + 5) % 5)];
		}

		char OppositeCorner(string target, Tuple<int, int> pos, int row)
		{
			return target[(row * 5) + pos.Item2];
		}

		public string ChangeABigram(char a, char b, bool encrypt)
		{
			var posA = Locate(_gridLeft, a);
			var posB = Locate(_gridRight, b);

			int offset = encrypt ? 1 : -1;

			if (posA.Item1 == posB.Item1)
				return string.Format("{0}{1}", Neighbour(_gridLeft, posA, offset), Neighbour(_gridRight, posB, offset));

			return string.Format("{0}{1}", OppositeCorner(_gridLeft, posA, posB.Item1), OppositeCorner(_gridRight, posB, posA.Item1));
		}

		public string Encrypt(string incoming)
		{
			return Change(incoming, true);
		}

		public string Decrypt(string incoming)
		{
			return Change(incoming, false);
		}

		string Change(string incoming, bool encrypt)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in incoming.Where(x => x != 'Q').Select(x => x))
				sb.Append(c);
			incoming = sb.ToString();

			if (incoming.Length % 2 == 1)
				incoming = string.Format("{0}{1}", incoming, 'X');
			StringBuilder rv = new StringBuilder();
			for (int i = 0; i < incoming.Length; i += 2)
			{
				string encoded = ChangeABigram(incoming[i], incoming[i + 1], encrypt);
				if (encoded[1] == 'X')
					rv.Append(encoded[0]);
				else
					rv.Append(encoded);
			}
			return rv.ToString();
		}
	}
}
