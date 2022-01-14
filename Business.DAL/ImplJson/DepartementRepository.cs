using Business.DAL.Abstraction;
using Business.JSON;
using Business.JSON.Data;
using System;
using System.Collections.Generic;

namespace Business.DAL.ImplJson
{
    public class DepartementRepository : IRepository<Departement>
    {
        DataContext<Departement> _context;
        public DepartementRepository()
        {
            _context = new DataContext<Departement>();
        }
        public void Add(Departement entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public Departement Get(int id)
        {
            return _context.Get(id);
        }

        public List<Departement> GetAll()
        {
            return _context.GetAll();
        }

        public void Update(int id, Departement entity)
        {
            _context.Update(id, entity);
        }
    }
}
