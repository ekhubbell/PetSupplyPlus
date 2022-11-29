namespace PetApi.Models
{
    public class PetType
    {
        public string TypeID { get; set; }
        public string TypeName { get; set; }

        public PetType (string typeID, string typeName)
        {
            TypeID = typeID;
            TypeName = typeName;
        }
        public PetType()
        {
            TypeID = "-1";
        }
    }
}
