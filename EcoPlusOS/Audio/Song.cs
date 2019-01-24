using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Core;
using Cosmos.Core.IOGroup;
using PIT = Cosmos.HAL.PIT;

namespace EcoPlusOS.Audio
{
    public class Song
    {
        public List<SongPart> Parts { get; set; }
        public void Play(double speed = 1)
        {
            foreach (var part in Parts)
            {
                CustomSpeaker.Beep((uint)part.Note, (uint)(part.MillisecondsDuration / speed), part.Delay);
            }
        }
        public Song(in SongPart[] parts)
        {
            Parts = parts.ToList();
        }

        public Song(List<SongPart> parts)
        {
            Parts = parts;
        }
        public static implicit operator Song(in SongPart[] parts) => new Song(in parts);
        public static implicit operator Song(in List<SongPart> parts) => new Song(parts);
        public class CustomSpeaker
        {
            protected static PCSpeaker IO = BaseIOGroups.PCSpeaker;
            private static PIT SpeakerPIT = new PIT();

            private static void EnableSound()
            {
                IO.Gate.Byte |= 3;
            }

            private static void DisableSound()
            {
                IO.Gate.Byte &= 252;
            }

            public static void Beep(uint frequency)
            {
                if (frequency < 37U || frequency > (uint)short.MaxValue)
                    throw new ArgumentOutOfRangeException("Frequency must be between 37 and 32767Hz");
                uint num1 = 1193180U / frequency;
                IO.CommandRegister.Byte = 182;
                IO.Channel2Data.Byte = (byte)(num1 & byte.MaxValue);
                IO.Channel2Data.Byte = (byte)(num1 >> 8 & byte.MaxValue);
                byte num2 = IO.Gate.Byte;
                if (num2 != (num2 | 3))
                    IO.Gate.Byte = (byte)(num2 | 3U);
                EnableSound();
            }

            public static void Beep(uint frequency, uint duration, uint delay = 0)
            {
                if (duration <= 0U)
                    throw new ArgumentOutOfRangeException("Duration must be more than 0");
                Beep(frequency);
                SpeakerPIT.Wait(duration);
                DisableSound();
                SpeakerPIT.Wait(delay);
            }
        }
    }
}
