using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BisunessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer;

namespace BisunessLayer.Implementations
{
    public class EFDirectoryRepository : IDirectoryRepository
    {
        private EFDBContext context;
        public EFDirectoryRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<DataLayer.Entities.Directory> GetAllDirectorys(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Directories.Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directories.ToList();
        }

        public DataLayer.Entities.Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Directories.Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(DataLayer.Entities.Directory directory)
        {
            if (directory.Id == 0)
                context.Directories.Add(directory);
            else
                context.Entry(directory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectory(DataLayer.Entities.Directory directory)
        {
            context.Directories.Remove(directory);
            context.SaveChanges();
        }
    }
}
