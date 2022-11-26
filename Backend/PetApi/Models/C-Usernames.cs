namespace PetApi.Models
{
    public class C_Usernames
    {
       
        public string userName { get; set; }
        public string password { get; set; }

        public C_Usernames(string userN, string passwd)
        {

            userName = userN;
            password = passwd;
        }
        public C_Usernames()
        {
            userName = "-1";
        }

        public static implicit operator string(C_Usernames v)
        {
            throw new NotImplementedException();
        }
    }
}
