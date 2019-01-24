using System.Collections.Generic;
using Cosmos.System;

namespace EcoPlusOS.Audio
{
    public static class Songs
    {
        public static readonly Song MarioSong = new List<SongPart>
        {
            new SongPart(Notes.E5, delay: 2),
            new SongPart(Notes.E5, delay: 2),
            new SongPart(Notes.E5, delay: 2),
            new SongPart(Notes.C5, delay: 2),
            new SongPart(Notes.E4, delay: 2),
            new SongPart(Notes.G4, 150, 10),
            new SongPart(Notes.G2, Durations.Quarter)
        };
    }
}