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

        public static readonly Song ElPuebloTouch = new List<SongPart>
        {
            new SongPart(Notes.C3, 175),
            new SongPart(Notes.C2, 250),
            new SongPart(Notes.CS2, 350)
        };
    }
}