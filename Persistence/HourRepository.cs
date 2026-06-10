using Horas.Entities;
namespace Horas.Persistence
{

    public class HourRepository(HourContext hourContext) : IHourRepository, IDisposable
    {
        private readonly HourContext _hourContext = hourContext;

        public IEnumerable<Hour> GetHours()
        {
            return _hourContext.Hours.ToList();
        }

        ///<summary>Throws an exception if the hour is not found</summary>
        public Hour GetHourByID(int HourId)
        {
            return _hourContext.Hours.FirstOrDefault(h => h.Id == HourId) ?? throw new ArgumentException("Hora inexistente en la db");
        }
        public void Add(Hour hour)
        {
            _hourContext.Hours.Add(hour);
        }

        public Hour Update(Hour hour)
        {
            var h = GetHourByID(hour.Id);
            h = hour;
            h.LastModified = DateTime.Now;
            return h;            
        }
        public void Delete(Hour hour)
        {
            var h = GetHourByID(hour.Id);
            _hourContext.Hours.Remove(h);
        }
        public void Save()
        {
            _hourContext.SaveChanges();
        }

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _hourContext.Dispose();
                }
            }
            this.disposed = true;
        }
         public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}