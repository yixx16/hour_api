using Horas.Persistence;
using Horas.Core.Entities;
using Horas.Request;

namespace Horas.Services
{

    public class HourService(IHourRepository hourRepository)
    {
        //inyectar
        private readonly IHourRepository HourRepository = hourRepository;


        public Hour Get(int id)
        {
            return HourRepository.GetHourByID(id);
        }
        public Hour Sum(SumRequest request)
        {
            var h = request.H1 + request.H2;
            var m = request.M1 + request.M2;
            var s = request.S1 + request.S2;
            //persistencia
            var hour = new Hour(h, m, s);
            HourRepository.Add(hour);
            HourRepository.Save();
            return hour;
        }
        public Hour Update(PutRequest request)
        {
            Hour hour = new(request.H, request.M, request.S);
            return HourRepository.Update(hour);      
        }


        public void Del(int id){}
    }

    
}