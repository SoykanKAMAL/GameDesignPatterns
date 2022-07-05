using UnityEngine;

namespace UpdateMethod
{
    [System.Serializable]

    public class FPSPrinter : ITickable
    {
        private float _fps;
        public FPSPrinter(float fps)
        {
            this._fps = fps;
        }

        public void Tick()
        {
            Debug.Log($"Current FPS: {_fps}");
        }
    }
}