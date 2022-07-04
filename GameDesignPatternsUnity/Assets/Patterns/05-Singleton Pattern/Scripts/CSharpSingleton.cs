using UnityEngine;
using Random = System.Random;

namespace SingletonPattern
{
    public class CSharpSingleton
    {
        private static CSharpSingleton _instance = null;
        
        public static CSharpSingleton Instance => _instance ??= new CSharpSingleton();

        private readonly int _randomNumber;
        private CSharpSingleton()
        {
            _randomNumber = new Random().Next(0, 100);
        }
        
        public void TestSingleton()
        {
            Debug.Log($"Random number: {_randomNumber}");
        }
    }
}