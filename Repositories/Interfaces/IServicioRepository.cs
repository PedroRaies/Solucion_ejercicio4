using WebApi_TurnosPeluqueria.Models;

namespace WebApi_TurnosPeluqueria.Repositories.Interfaces
{
    public interface IServicioRepository
    {
        List<TServicio> GetServicioList();
        TServicio? GetServicioById(int id);
        bool CreateService(TServicio servicio);
        bool UpdateService(TServicio servicio);
        bool DeleteService(int id);
    }
}
