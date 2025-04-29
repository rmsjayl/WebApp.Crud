namespace WebApp.Crud.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? University { get; set; }
        public string? CellPhoneNumber { get; set; }

        protected static string GetName(string FirstName, string LastName)
        {
            return FirstName + " " + LastName;
        }
    }
}
