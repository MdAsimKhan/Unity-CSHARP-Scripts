using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TransformFloatPair
{
    public Transform transform;
    public float speed;

    public TransformFloatPair(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
    }
}

public class MoveBetween : MonoBehaviour
{
    public TransformFloatPair[] initial_state;
    public Transform[] final_position;
    void Update()
    {
        for(int i = 0; i < initial_state.Length; i++)
        {
            Transform initial_position = initial_state[i].transform;
            float speed = initial_state[i].speed;
            initial_state[i].transform.position = Vector3.MoveTowards(initial_position.position, final_position[i].position, speed * Time.deltaTime);
        }
    }
}
