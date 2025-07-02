using System;

namespace Assets.Scripts.Learn
{
    [Serializable]
    public class LearnResult<T>
    {
        public T Value { get; set; }
    }
}
