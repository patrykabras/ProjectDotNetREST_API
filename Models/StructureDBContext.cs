using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CryptaEcillas.Models
{
    public class StructureDBContext : DbContext
    {
        public DbSet<Structure> Structure { get; set; }

        public StructureDBContext(DbContextOptions<StructureDBContext> options) : base(options)
        {
            
        }

        public List<Structure> getStructure () => Structure.ToList();

        public void addStructure (Structure structure) {
            Structure.Add(structure);
            this.SaveChanges();
            return;
        }
        public Structure getStructureById(int id)
        {
            return getStructure().Find(s => s.id == id);
        }
    }
}