namespace Horas
{
    
    class HourService
    {
        public Hour Sum(HourRequest request)
        {
            
            var h = request.H1 + request.H2;
            var m = request.M1 + request.M2;
            var s = request.S1 + request.S2;

            return new Hour(h,m,s);
        }
    }

}