using System;
using System.Collections.Generic;
using System.Linq;
using System.DirectoryServices.AccountManagement;
using System.Text;
using System.Threading.Tasks;

namespace fullframeworklibrary
{
    public class Class1
    {
        public static List<string> GetGroupNames(string userName)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(userName))
                return result;

            var domain = userName.Split('\\').FirstOrDefault();

            try
            {
                var pc = new PrincipalContext(ContextType.Domain, domain);
                var identity = UserPrincipal.FindByIdentity(pc, userName);
                if (identity != null)
                {
                    var src = identity.GetGroups(pc);
                    src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
                }
                return result;
            }
            catch (PrincipalServerDownException e)
            {
                Console.WriteLine($"There was an exception because the server is down: ********** \n\n {e.ToString()}");
            }

            return result;
        }
    }
}
