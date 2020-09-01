using System;
using System.Collections.Generic;

namespace HackerRank
{
    public static class PasswordCracker
    {

        public static string GetPasswordCracker(List<string> passwords, string loginAttempt)
        {
            HashSet<string> pws = new HashSet<String>(passwords);
            string result = string.Empty;
            string toCompare = String.Empty;

            for (int ini = 0; ini < loginAttempt.Length; ini++)
            {
                for (int end = loginAttempt.Length - 1; end > ini ; end--)
                {
                    string tmp = loginAttempt.Substring(ini, end - ini + 1);
                    if (pws.Contains(tmp))
                    {
                        result += (result.Length > 0 ? " " : "") + tmp;
                        toCompare += tmp;

                        ini = ini + tmp.Length - 1;
                    }
                }
            }
            
            return (result.Length == 0 || toCompare != loginAttempt) ?
                "WRONG PASSWORD" : result;
        }

    }
}