using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace курсач_2._0.Mutation
{
    public class MutationInversion
    {
        public int[] Mutation(int[] child)
        {
            Random rnd = new Random();
            var mutant = new int[child.Length];
            int delay1 = rnd.Next(0, child.Length - 1);
            int delay2 = rnd.Next(delay1 + 1, child.Length);
            for (int i = 0; i < delay1; i++)
            {
                mutant[i] = child[i];
            }
            var buffDelay2 = delay2;
            for (int i = delay1; i < delay2; i++)
            {
                mutant[i] = child[--buffDelay2];
            }
            for (int i = delay2; i < child.Length; i++)
            {
                mutant[i] = child[i];
            }
            return mutant;
        }
    }
}
