using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.FindParent
{
    public class Insourcing : ASourcing
    {
        protected override int CountParametr(int[] Parent1, int[] Parent2)
        {
            int param = 0;
            for (var i = 0; i < Parent1.Length; i++)
            {
                if (Parent1[i] == Parent2[i]) param++;
            }
            return param;
        }
    }
}
