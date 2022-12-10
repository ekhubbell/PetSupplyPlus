namespace PetApi.Models
{
    public class State
    {

        public string Id { get; set; }
        public string name { get; set; }
        public string abbr { get; set; }
        public string tax { get; set; }

        public State(string id, string name, string abbr, string tax)
        {
            Id = id;
            this.name = name;
            this.abbr = abbr;
            this.tax = tax;
        }
    }
}
