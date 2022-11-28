namespace PetApi.Models
{
    public class TableData
    {
        public List<string> name { get; set; }
        public List<string> datatype { get; set; }

        public TableData(List<string> name, List<string> datatype)
        {
            this.name = name;
            this.datatype = datatype;
        }
    }
}
