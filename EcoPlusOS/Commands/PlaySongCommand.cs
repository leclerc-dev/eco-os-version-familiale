using System.Collections.Generic;
using Cosmos.System;
using EcoPlusOS.Audio;

namespace EcoPlusOS.Commands
{
    public class PlaySongCommand : ICommand
    {
        public List<string> Names => new List<string>
        {
            "mélodie",
            "melodie",
            "musique",
            "transition",
            "music",
            "song"
        };

        public string Description => "Joue de la musique de l'espace culturel Leclerc.";

        public void Execute(string parameter = null)
        {
            Songs.MarioSong.Play();
        }
    }
}