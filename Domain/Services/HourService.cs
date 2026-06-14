using Horas.Infraestructure.Persistence;
using Horas.Domain.Entities;
using Horas.Api.Request;

namespace Horas.Domain.Services
{

    public class HourService(IHourRepository hourRepository)
    {
        //inyectar
        private readonly IHourRepository HourRepository = hourRepository;

        public Hour Get(int id)
        {
            return HourRepository.GetHourByID(id) ?? throw new ArgumentException("Hora inexistente en la db");
        }
        public IEnumerable<Hour> GetAll()
        {
            return HourRepository.GetHours();
        }
        public Hour Sum(SumRequest request)
        {
            //persistencia
            var hour =
                new Hour(request.H1, request.M1, request.S1)
                +
                new Hour(request.H2, request.M2, request.S2);
            HourRepository.Create(hour);
            HourRepository.Save();
            return hour;
        }
        public Hour Update(PutRequest request)
        {
            Hour hour = new(request.H, request.M, request.S)
            {
                Id = request.Id
            };
            return HourRepository.Update(hour);
        }


        public void Del(int id)
        {
            var hour = Get(id);
            HourRepository.Delete(hour);
            HourRepository.Save();
        }
    }


}