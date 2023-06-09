using UnityEngine;

public class DirectionalGravityController : MonoBehaviour
{
    private Vector3 originalGravity;
    private bool isGravityModified = false;
    private Vector3 customGravity;

    private Rigidbody rigidbodyComponent;

    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;
    }

    public void SetGravity(Vector3 customGravity)
    {
        if (!isGravityModified)
        {
            isGravityModified = true;
            this.customGravity = customGravity;

            Debug.Log(gameObject.name + " gravity modified with custom gravity: " + customGravity);

            // Calculate the target rotation based on the custom gravity direction
            Vector3 targetUp = -customGravity.normalized;
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, targetUp) * transform.rotation;

            // Apply the target rotation to align the object with the gravity direction
            transform.rotation = targetRotation;
        }
    }

    public void ResetGravity()
    {
        if (isGravityModified)
        {
            isGravityModified = false;

            Debug.Log(gameObject.name + " gravity reset.");

            // Restore the object's original orientation
            transform.rotation = Quaternion.identity;
        }
    }

    private void FixedUpdate()
    {
        if (isGravityModified)
        {
            rigidbodyComponent.AddForce(customGravity, ForceMode.Acceleration);
        }
        else
        {
            rigidbodyComponent.AddForce(originalGravity, ForceMode.Acceleration);
        }
    }
}
