namespace WebApp.Crud.Models.DTOs
{
    public class UpdateStudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string CellPhoneNumber { get; set; } = string.Empty;
    }
}
