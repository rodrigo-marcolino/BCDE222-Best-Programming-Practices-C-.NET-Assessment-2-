using System;
using System.Collections.Generic;
using System.Text;

namespace TaM
{
    interface IMovement
    {
        void GoUp();
        void GoDown();
        void Goleft();
        void GoRight();
        int Row { get; }
        int Column { get; }

    }

}
