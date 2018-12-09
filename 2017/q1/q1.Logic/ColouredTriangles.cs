using System.Text;

namespace q1.Logic
{
    public static class ColouredTriangles
    {
        static char Triangle(char left, char right) {
            if (left == right)
                return left;
            if (left == 'R')
                return right == 'G' ? 'B' : 'G';
            if (left == 'G')
                return right == 'R' ? 'B' : 'R';
            return right == 'R' ? 'G' : 'R';
        }

        public static char Q1(string input)
        {
            if (input.Length == 1)
                return input[0];
            if (input.Length == 2)
                return Triangle(input[0], input[1]);
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < input.Length-1; i++)
                sb.Append(Triangle(input[i], input[i + 1]));
            return Q1(sb.ToString());
        }
    }
}
