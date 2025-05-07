using WebApp.Crud.Models.Domain;

namespace WebApp.Crud.Shared
{
    public class Helpers
    {
        public void PropNullChecker(Student student)
        {
            var properties = student.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(student);

                //if the value contains an empty string or null
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception($"Property {property.Name} cannot be null or empty.");
                }
            }
        }
    }
}  
