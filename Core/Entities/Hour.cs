using System.ComponentModel.DataAnnotations;

namespace Horas.Core.Entities
{
    public class Hour
    {
        [Key]
        public int Id {get; set;}
        public int H { get; set; }
        public int M { get; set; }
        public int S { get; set; }
        //mirar en supabase los distintos tipos de timestamp para verificar cual es acorde con la hora colombiana
        public DateTime LastModified {get; set;} = DateTime.UtcNow;

        public Hour(int h, int m, int s)
        {
            H = h;
            M = m;
            S = s;
            validate();
        }
        public Hour(){}

        private void validate()
        {
            int total = H*3600 + M*60 + S;
            //validar negativos
            total = ((total % 86400) + 86400) % 86400;

            H = total/3600;
            M = total%3600 / 60;
            S = total % 60;
        }

        public static Hour operator +(Hour a, Hour b)
        =>
            new(a.H + b.H, a.M + b.M, a.S + b.S);

        public override string ToString()
            => $"HH:MM:SS -> {H:D2}:{M:D2}:{S:D2}";
    }

}