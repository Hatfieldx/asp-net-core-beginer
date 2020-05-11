
using System;

namespace lesson7.Services
{
    public class Timer : ITimer
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}
