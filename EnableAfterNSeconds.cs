using UnityEngine;

public class EnableAfterNSeconds : MonoBehaviour
{
    public GameObject target;
    public float delayTime;
    private float curTime;
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= delayTime)
        {
            target.SetActive(true);
        }
    }
}
