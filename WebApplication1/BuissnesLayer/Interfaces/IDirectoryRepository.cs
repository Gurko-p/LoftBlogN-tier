

namespace BisunessLayer.Interfaces;

public interface IDirectoryRepository
{
    IEnumerable<DataLayer.Entities.Directory> GetAllDirectorys(bool includeMaterials = false);
    DataLayer.Entities.Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
    void SaveDirectory(DataLayer.Entities.Directory achieve);
    void DeleteDirectory(DataLayer.Entities.Directory achieve);
}
