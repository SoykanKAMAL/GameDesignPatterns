using UnityEngine;

namespace FlyweightPattern
{
    public class FlyWeightBug : BugBase
    {
        public FlyWeightBug (Data bugData)
        {
            this.BugData = bugData;
            this.MoveSpeed = Random.Range(2f, 10f);
        }
    }
}
