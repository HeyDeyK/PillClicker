using System;
using System.Collections.Generic;
using System.Text;

namespace Clicker
{
    abstract class UserData
    {
        private int _MoneyCTR = 200;
        public int MoneyCTR
        {
            get => _MoneyCTR;
            set
            {
                _MoneyCTR = value;
            }
        }
    }
}
