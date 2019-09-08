namespace q2.Lib
{
    public class PasswordChecker
    {
        public static string Check(string stringtocheck)
        {
            for(int len = 1; len <= stringtocheck.Length/2; len++)
            {
                for(int pos = 0; pos + (2*len) <= stringtocheck.Length; pos++)
                {
                    string a = stringtocheck.Substring(pos, len);
                    string b = stringtocheck.Substring(pos + len, len);
                    if (a.Equals(b))
                        return "Rejected";
                }
            }

            return "Accepted";
        }
    }
}
