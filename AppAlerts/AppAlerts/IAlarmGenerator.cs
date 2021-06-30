using System;
using System.Collections.Generic;
using System.Text;

namespace AppAlerts
{
    public interface IAlarmGenerator
    {
        void Generate(int hora,int minuto);
    }
}
