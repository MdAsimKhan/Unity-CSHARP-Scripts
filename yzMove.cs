using UnityEngine;

public class yzMove : MonoBehaviour
{
    public Transform initial_position, final_position;
    public float speed;
    private float yDistance, zDistance, yProgress, zProgress;
    void Start()
    {
        yDistance = Mathf.Abs(initial_position.position.y - final_position.position.y);
        zDistance = Mathf.Abs(initial_position.position.z - final_position.position.z);
    }
    void Update()
    {
        Vector3 pos = initial_position.position;
        // y move
        if(yProgress < yDistance)
            {
                float yMovement = speed * Time.deltaTime;
                yProgress += yMovement;
                float newY = Mathf.Lerp(pos.y, final_position.position.y, yProgress / yDistance);
                initial_position.position = new Vector3(pos.x, newY, pos.z);
            }
        // z move
        else if(zProgress < zDistance)
        {
            float zMovement = speed * Time.deltaTime;
            zProgress += zMovement;
            float newZ = Mathf.Lerp(pos.z, final_position.position.z, zProgress / zDistance);
            initial_position.position = new Vector3(pos.x, pos.y, newZ);
        }
    }
}