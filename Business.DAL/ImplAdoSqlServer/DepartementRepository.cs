
using Business.ADO.Data;
using Business.ADO.ConnectedMode;
using Business.DAL.Abstraction;
using System.Collections.Generic;

namespace Business.DAL.ImplAdoSqlServer
{
    public class DepartementRepository : IRepository<Departement>
    {
        ConnectedDataContext _context;

        public DepartementRepository()
        {
            _context = new ConnectedDataContext();
        }

        public void Add(Departement entity) //Method wrapper
        {
            _context.AddDepartement(entity);
        }

        public void Delete(int id)
        {
            _context.DeleteDepartement(id);
        }

        public Departement Get(int id)
        {
            return _context.GetDepartement(id);
        }

        public List<Departement> GetAll()
        {
            return _context.GetAllDepartements();
        }

        public void Update(int id,Departement entity)
        {
            _context.UpdateDepartement(id, entity);
        }
    }
}
