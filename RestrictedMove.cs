using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RestrictedDS
{
    public Transform ip, fp;
    public float speed;
    [HideInInspector]
    public float yDistance, zDistance, yProgress, zProgress;
    public RestrictedDS(Transform ip, Transform fp, float speed, float yDistance, float zDistance, float yProgress, float zProgress)
    {
        this.ip = ip;
        this.fp = fp;
        this.speed = speed;
        this.yDistance = Mathf.Abs(ip.position.y - fp.position.y);
        this.zDistance = Mathf.Abs(ip.position.z - fp.position.z);
        this.yProgress = 0f;
        this.zProgress = 0f;
    }
}
public class RestrictedMove : MonoBehaviour
{
    public RestrictedDS[] ip;
    // first move in y then in z
    void Update()
    {
        for(int i=0; i<ip.Length; i++)
        {
            // y move
            if(ip[i].yProgress < ip[i].yDistance)
            {
                float yMovement = ip[i].speed * Time.deltaTime;
                ip[i].yProgress += yMovement;
                float newY = Mathf.Lerp(ip[i].ip.position.y, ip[i].fp.position.y, ip[i].yProgress / ip[i].yDistance);
                ip[i].ip.position = new Vector3(ip[i].ip.position.x, newY, ip[i].ip.position.z);
            }
            // z move
            else if(ip[i].zProgress < ip[i].zDistance)
            {
                float zMovement = ip[i].speed * Time.deltaTime;
                ip[i].zProgress += zMovement;
                float newZ = Mathf.Lerp(ip[i].ip.position.z, ip[i].fp.position.z, ip[i].zProgress / ip[i].zDistance);
                ip[i].ip.position = new Vector3(ip[i].ip.position.x, ip[i].ip.position.y, newZ);
            }
        }
    }
}
