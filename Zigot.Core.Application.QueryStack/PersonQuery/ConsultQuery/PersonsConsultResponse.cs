namespace Zigot.Core.Application.QueryStack.PersonQuery.ConsultQuery
{
    public class PersonsConsultResponse
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public string Profession { get; set; }
        public bool HasChildren { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime RegistredAt { get; set; }
    }
}
