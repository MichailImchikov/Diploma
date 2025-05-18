namespace курсач_2._0.Crossingover
{
    public class Crossbreeding : ICrossingover
    {
        private int[] _child;
        private int[] _parent1;
        private int[] _parent2;
        private int[] _tablePosition;
        public int[] GetChild(int[] Parent1, int[] Parent2)
        {
            Random rnd = new Random();
            _child = new int[Parent1.Length];
            _parent1 = Parent1;
            _parent2 = Parent2;

            int delay1 = rnd.Next(0, Parent1.Length - 1);
            int delay2 = rnd.Next(delay1 + 1, Parent1.Length);
            int[] Section1 = Parent1.Skip(delay1).Take(delay2 - delay1 + 1).ToArray();
            int[] Section2 = Parent2.Skip(delay1).Take(delay2 - delay1 + 1).ToArray();
            for (int i = delay1; i <= delay2; i++)
            {
                _child[i] = Parent1[i];
            }

            _tablePosition = new int[Parent1.Length];
            for (int i = 0; i < Parent1.Length; i++)
            {
                var positionInParent2 = Array.IndexOf(Parent2, i + 1);
                _tablePosition[i] = positionInParent2;
            }

            var resultExcept = Section2.Except(Section1).ToArray();

            for (int k = 0; k < resultExcept.Length; k++)
            {
                var i = Array.IndexOf(Parent2, resultExcept[k]);
                var posAndValue = GetPositionAndValue(i);
                _child[posAndValue.Position] = posAndValue.Value;
            }
            for (int i = 0; i < _parent1.Length; i++)
            {
                if (_child[i] == 0) _child[i] = _parent2[i];
            }
            return _child;
        }
        private (int Position, int Value) GetPositionAndValue(int i)
        {
            var pos = NewPosition(i);
            return (pos, _parent2[i]);
        }
        private int NewPosition(int i)
        {
            int j = i;
            int j_ = SelectPosition(j);
            while (_child[j_] != 0)
            {
                j = j_;
                j_ = SelectPosition(j);
            }
            return j_;
        }
        private int SelectPosition(int j)
        {
            var ValueInParent1 = _parent1[j];
            return _tablePosition[ValueInParent1 - 1];
        }

    }
}
