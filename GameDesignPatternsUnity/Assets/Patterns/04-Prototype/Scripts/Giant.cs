using UnityEngine;

[System.Serializable]
public class Giant : IEnemy
{
    public static int GiantCount = 0;
    private GameObject _prefab;
    public Giant (GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject Clone()
    {
        GiantCount++;
        return Object.Instantiate(_prefab);
    }

    public override string ToString()
    {
        return $"I am a Giant!";
    }
}