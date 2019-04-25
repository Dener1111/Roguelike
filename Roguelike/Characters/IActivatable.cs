using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Characters
{
    interface IActivatable
    {
        char Graphic1 { get; set; }
        char Graphic2 { get; set; }

        string Activate();
    }
}
