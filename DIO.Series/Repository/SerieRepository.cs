using System.Collections.Generic;
using DIO.Series.Entities;

namespace DIO.Series.Repository
{
    public class SerieRepository : IRepository<SerieEntity>
    {
        private List<SerieEntity> serieList = new List<SerieEntity>();
        public void Create(SerieEntity entity)
        {
            serieList.Add(entity);
        }

        public void Delete(int id)
        {
            serieList[id].Active = false;
        }

        public SerieEntity GetById(int id)
        {
            return serieList[id];
        }

        public int GetNextId()
        {
            return serieList.Count;
        }

        public List<SerieEntity> ListAll()
        {
            return serieList;
        }

        public void Update(int id, SerieEntity entity)
        {
            serieList[id] = entity;
        }
    }
}