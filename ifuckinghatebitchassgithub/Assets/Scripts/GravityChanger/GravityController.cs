using UnityEngine;

public class GravityController : MonoBehaviour
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
        }
    }

    public void ResetGravity()
    {
        if (isGravityModified)
        {
            isGravityModified = false;

            Debug.Log(gameObject.name + " gravity reset.");
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
