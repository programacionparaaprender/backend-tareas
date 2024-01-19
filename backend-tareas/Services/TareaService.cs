using backend_tareas.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using backend_tareas.Models;
using System.Threading;

namespace backend_tareas.Services
{
    public class TareaService
    {
        private readonly ApplicationDbContext _applicationBDContext;
        public TareaService(ApplicationDbContext applicationBDContext)
        {
            this._applicationBDContext = applicationBDContext;
        }


        public Boolean agregarTarea(Tarea _tarea)
        {
            int resultado = 0;
            try
            {
                _applicationBDContext.Tareas.Add(_tarea);
                resultado = _applicationBDContext.SaveChanges();
                return (resultado > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean editarTarea(Tarea tarea)
        {
            int resultado = 0;
            try
            {
                var tareaUpdate = porTareaPorID(tarea.Id);
                tareaUpdate.Nombre = tarea.Nombre;
                tareaUpdate.Estado = tarea.Estado;
                resultado = _applicationBDContext.SaveChanges();
                return (resultado > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Tarea porTareaPorID(int Id)
        {
            try
            {
                IQueryable<Tarea> query = _applicationBDContext.Tareas.Where(tareaBuscar => tareaBuscar.Id == Id);
                Tarea tareaUpdate = query.FirstOrDefault();
                return tareaUpdate;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Tarea> listarTareas()
        {
            try
            {
                var tareas = _applicationBDContext.Tareas.ToList();
                return tareas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean eliminarTarea(int Id)
        {
            int resultado = 0;
            try
            {

                var tareaEliminar = porTareaPorID(Id);
                _applicationBDContext.Remove(tareaEliminar);
                resultado = _applicationBDContext.SaveChanges();
                return (resultado > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
