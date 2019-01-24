using System;
using System.Collections.Generic;
using System.Text;

namespace EcoPlusOS.Commands
{
    public interface ICommand
    {
        List<string> Names { get; }
        string Description { get; }
        
        void Execute(string parameter = null);
    }
}
