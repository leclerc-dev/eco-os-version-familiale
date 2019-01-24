using Cosmos.System;

namespace EcoPlusOS.Audio
{
    public readonly struct SongPart
    {
        public readonly Notes Note;
        public readonly uint MillisecondsDuration;
        public readonly uint Delay;
        public SongPart(Notes note, Durations duration = Durations.Sixteenth, uint delay = 0)  : this(note, (uint)duration, delay) { }

        public SongPart(Notes note, uint millisecondsDuration, uint delay = 0)
        {
            Note = note;
            MillisecondsDuration = millisecondsDuration;
            Delay = delay;
        }
        public static implicit operator SongPart(Notes note) => new SongPart(note);
    }
}