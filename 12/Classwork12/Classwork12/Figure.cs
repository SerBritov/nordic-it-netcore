using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork12
{
    class Figure
    {
        public string FigureType { get; private set; }

        public Figure(string figureType)
        {
            FigureType = figureType;
        }
    }
}
