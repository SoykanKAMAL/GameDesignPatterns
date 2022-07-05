using UnityEngine;

namespace TypeObject
{
    public class Programmer : Human
    {
        private IShyness _shynessType;
        public Programmer (string name, bool isShy)
        {
		    this.name = name;
            this._shynessType = isShy ? new Shy() : new Talkative();
        }

        public override void Talk()
        {
            if (_shynessType.AmIShy())
            {
                Debug.Log($"My name is {name} and I am a shy programmer");
            }
            else
            {
                Debug.Log($"My name is {name} and I am a talkative programmer");
            }
        }
    }
}