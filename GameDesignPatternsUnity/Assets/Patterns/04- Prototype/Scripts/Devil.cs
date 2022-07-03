using UnityEngine;

[System.Serializable]
public class Devil : IEnemy
{
    public static int DevilCount = 0;
    private GameObject _prefab;
    public Devil (GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject Clone()
    {
        DevilCount++;
        return Object.Instantiate(_prefab);
    }

    public override string ToString()
    {
        return $"I am a devil!";
    }
}