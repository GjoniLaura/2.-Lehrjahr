namespace TimeTable
{
    public class Education
    {
        public int Id { get; set; }
        public string _participant { get; set; }
        public string _subject { get; set; }
        public int _lessons { get; set; }


        public Education(string participant, string subject, int lessons)
        {
            _participant = participant;
            _subject = subject;
            _lessons = lessons;
        }
    }
}
