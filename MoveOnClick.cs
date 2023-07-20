using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    private bool isMoving = false, atFinal = false;
    public Transform originalPosition, finalPosition;
    private Vector3 targetPosition;
    public float moveSpeed = 5f;
    public GameObject toToggle;
    
    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
                isMoving = false;
        }
    }

    public void OnMouseDown()
    {
        if (atFinal)
        {
            toToggle.SetActive(false);
            atFinal = false;
            MoveTo(originalPosition.position);
        }
        else
        {
            toToggle.SetActive(true);
            atFinal = true;
            MoveTo(finalPosition.position);
        }
    }

    private void MoveTo(Vector3 destination)
    {
        targetPosition = destination;
        isMoving = true;
    }
}
