﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.FindParent
{
    public interface IFindParents
    {
        public (int[], int[]) GetParents(int Parameter, List<int[]> population);
    }
}
