using Cosmos.Core;
using System;
using System.Diagnostics;

namespace EcoPlusOS
{
    public static class CStopwatch
    {
        public static long GetTimestamp()
        {
            return DateTime.UtcNow.Ticks;
        }
    }
}