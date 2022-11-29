using System.Security.Policy;

namespace PetApi.Models
{
    public class E_Usernames
    {
        internal object? newPassword;

        public string userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        

        public E_Usernames(string userid, string userN, string passwd)
        {
            userID = userid;
            userName = userN;
            password = passwd;
            
        }
        public E_Usernames()
        {
            userName = "-1";
        }

        public static implicit operator string(E_Usernames v)
        {
            throw new NotImplementedException();
        }
    }
}
