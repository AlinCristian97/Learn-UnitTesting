namespace UnitTestingTutorial.Mocking
{
    public interface IEmployeeStorage
    {
        void DeleteEmployeeFromDb(int id);
    }

    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }
        
        public void DeleteEmployeeFromDb(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee == null) return;
            
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}