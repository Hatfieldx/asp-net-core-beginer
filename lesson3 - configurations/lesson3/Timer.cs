using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson3
{
    public class Timer : ITimer
    {
        public string GetPartOfDay()
        {            
            int current = DateTime.Now.Hour;

            if (current >= 12 && current <= 16)
                return "now is day";
            else if (current >= 16 && current <= 24)            
                return "now is evening";
            else if (current >= 0 && current <= 4)
                return "now is night";
            else return "now is morning";
        }
    }

    public interface ITimer
    {
        string GetPartOfDay();
    }
}
