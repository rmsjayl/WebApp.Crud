using WebApp.Crud.Models.Domain;

namespace WebApp.Crud.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
        Task<Student> GetAsync(Guid id);
        Task<Student> UpdateAsync(Guid id, Student student);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Student>> GetAllAsync();
    }
}
