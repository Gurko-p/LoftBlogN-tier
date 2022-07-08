

using BisunessLayer.Interfaces;

namespace BisunessLayer;

public class DataManager
{
    private IDirectoryRepository _directorysRepository;
    private IMaterialsRepository _materialsRepository;

    public DataManager(IDirectoryRepository directorysRepository, IMaterialsRepository materialsRepository)
    {
        _directorysRepository = directorysRepository;
        _materialsRepository = materialsRepository;
    }

    public IDirectoryRepository Directorys { get { return _directorysRepository; } }
    public IMaterialsRepository Materials { get { return _materialsRepository; } }
}
