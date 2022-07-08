using DataLayer.Entities;

namespace BisunessLayer.Interfaces;

public interface IMaterialsRepository
{
    IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);
    Material GetMaterialById(int materialId, bool includeDirectory = false);
    void SaveMaterial(Material material);
    void DeleteMaterial(Material material);
}
