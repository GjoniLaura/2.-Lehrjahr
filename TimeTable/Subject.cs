namespace TimeTable
{
    public class Subject
    {
        public string _designation { get; set; }
        public string _description { get; set; }
        public int _Id { get; set; }
        public string _premises { get; set; }


        public Subject(string designation, string description, int Id, string premises)
        {
            _designation = designation;
            _description = description;
            _Id = Id;
            _premises = premises;
        }
    }
}