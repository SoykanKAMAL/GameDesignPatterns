using UnityEngine;

namespace UpdateMethod
{
    [System.Serializable]

    public class TimePrinter : ITickable
    {
        public TimePrinter()
        {

        }

        public void Tick()
        {
            Debug.Log($"Current time is {System.DateTime.Now}");
        }
    }
}