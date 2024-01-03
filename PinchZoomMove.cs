using UnityEngine;

public class PinchZoomMove : MonoBehaviour
{
    private Vector2 initialPinchPosition;
    private float initialDistance;
    private bool isPinching = false;
    private CameraViewController cameraViewController;

    public float zoomSpeed = 0.1f;
    public float moveSpeed = 0.01f;
    //public float rotationSpeed = 0.1f;

    void Start()
    {
        cameraViewController = Camera.main.GetComponent<CameraViewController>();
    }

    void Update()
    {
        //if (Input.touchCount == 1)
        //{
        //    cameraViewController.HandleRotationInput();
        //}

        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch1.position, touch2.position);
                initialPinchPosition = (touch1.position + touch2.position) / 2f;
                isPinching = true;
            }
            else if ((touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) && isPinching)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float deltaDistance = currentDistance - initialDistance;

                if (Mathf.Abs(deltaDistance) > 20f) // Adjust this threshold based on your needs
                {
                    // Pinch zoom
                    float pinchZoom = deltaDistance * zoomSpeed;
                    Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - pinchZoom, 10f, 75f);
                }
                else
                {
                    // Pinch move
                    Vector2 currentPinchPosition = (touch1.position + touch2.position) / 2f;
                    Vector2 deltaPinch = currentPinchPosition - initialPinchPosition;
                    transform.Translate(-deltaPinch.x * moveSpeed, deltaPinch.y * moveSpeed, 0);
                }

                initialDistance = currentDistance;
                initialPinchPosition = (touch1.position + touch2.position) / 2f;
            }
            else if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
            {
                isPinching = false;
            }
        }
    }
}