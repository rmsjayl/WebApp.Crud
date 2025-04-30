using WebApp.Crud.Models.Domain;

namespace WebApp.Crud.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
        Task<Student> GetAsync(int id);
        Task<Student> UpdateAsync(int id, Student student);
        Task<bool> DeleteAsync(int id);
        Task<List<Student>> GetAllAsync();
    }
}
