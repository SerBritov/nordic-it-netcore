using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork11
{
    class Button
    {
        public bool IsPushed { get; private set; }
        
        public Button()
        {

        }

        public Button(bool isPushed)
        {
            IsPushed = isPushed;
        }
        public void Push()
        {
            IsPushed = true;
        }

        public void Reset()
        {
            IsPushed = false;
        }
    }
}
