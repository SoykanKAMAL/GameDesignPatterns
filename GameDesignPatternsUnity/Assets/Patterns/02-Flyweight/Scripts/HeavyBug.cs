using UnityEngine;

public class HeavyBug : BugBase
{
    public HeavyBug ()
    {
		this.BugData = new Data();
        this.MoveSpeed = Random.Range(2f, 10f);
    }
}