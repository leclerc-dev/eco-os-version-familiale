using System;
using Cosmos.HAL;

namespace EcoPlusOS
{
    public static class EcoRand
    {
        public static readonly EcoRandom Instance = new EcoRandom();
        // modified from https://github.com/CosmosOS/Cosmos/blob/94a6bd68aaa00df569130c6bab444fd1abcc01a2/source/Cosmos.System2_Plugs/System/RandomImpl.cs
        public class EcoRandom
        {
            public EcoRandom()
            {
                _seed = RTC.Second;
            }
            private int _seed;
            public int Next(int maxValue)
            {
                return (int)(GetUniform() * maxValue);
            }

            public int Next()
            {
                return (int)(GetUniform() * int.MaxValue);
            }
            public int Next(int minValue, int maxValue)
            {
                uint diff = (uint)(maxValue - minValue);
                if (diff <= 1)
                    return minValue;
                return (int)((uint)(GetUniform() * diff) + minValue);
            }
            private double GetUniform()
            {
                uint seed = (uint)_seed;
                uint m_w = seed >> 16;
                uint m_z = (uint)(seed % 4294967296);
                m_z = 36969 * (m_z & 65535) + (m_z >> 16);
                m_w = 18000 * (m_w & 65535) + (m_w >> 16);
                uint u = (m_z << 16) + m_w;
                double uniform = (u + 1.0) * 2.328306435454494e-10;
                unchecked
                {
                    _seed += RTC.Second;
                }
                return uniform;
            }
        }
    }
}