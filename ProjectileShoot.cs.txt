using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 10.0f;

    public void Fire()
    {
        GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.AddForce(startPoint.forward * launchSpeed, ForceMode.Impulse);
    }
}
