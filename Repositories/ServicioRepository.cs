using WebApi_TurnosPeluqueria.Models;
using WebApi_TurnosPeluqueria.Repositories.Interfaces;

namespace WebApi_TurnosPeluqueria.Repositories
{
    public class ServicioRepository : IServicioRepository

    {
        private static dbTurnosContext _Context;

        public ServicioRepository(dbTurnosContext context)
        {
            if (context != null)
            _Context = context; 

        }


        public bool CreateService(TServicio servicio)
        {
            if(servicio == null)
                return false;
            try
            {
                _Context.TServicios.Add(servicio);
                var aux = _Context.SaveChanges();
                return aux == 1;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public bool DeleteService(int id)
        {
            try
            {
                var servicio = _Context.TServicios.Find(id);
                if (servicio == null)
                {
                    return false;
                }
                else
                {
                    servicio.EnPromocion = "N";
                    var aux = _Context.SaveChanges();
                    return aux == 1;
                }
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public TServicio? GetServicioById(int id)
        {
            return _Context.TServicios.Find(id);
        }

        public List<TServicio> GetServicioList() => _Context.TServicios.ToList();
        

        public bool UpdateService(TServicio servicio)
        {
            try
            {
                var servicioExistente = _Context.TServicios.Find(servicio.Id);

                if(servicioExistente == null)
                    return false;

                servicioExistente.Nombre = servicio.Nombre;
                servicioExistente.Costo = servicio.Costo;
                servicioExistente.EnPromocion = servicio.EnPromocion;

                _Context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
