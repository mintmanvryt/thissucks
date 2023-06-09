using UnityEngine;

public class MonkesGravityChanger : MonoBehaviour
{
    public string targetTag; // The customizable tag to detect
    public Vector3 gravity; // The customizable gravity to apply

    private void Start()
    {
        // Detect and apply gravity to existing Rigidbody components within the same GameObject
        Rigidbody[] existingRigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in existingRigidbodies)
        {
            if (rigidbody.CompareTag(targetTag))
            {
                ApplyGravity(rigidbody);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Rigidbody rigidbody = other.attachedRigidbody;
            if (rigidbody != null)
            {
                ApplyGravity(rigidbody);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Rigidbody rigidbody = other.attachedRigidbody;
            if (rigidbody != null)
            {
                GravityController gravityController = rigidbody.gameObject.GetComponent<GravityController>();
                if (gravityController != null)
                {
                    gravityController.ResetGravity();
                }
                else
                {
                    DirectionalGravityController directionalGravityController = rigidbody.gameObject.GetComponent<DirectionalGravityController>();
                    if (directionalGravityController != null)
                    {
                        directionalGravityController.ResetGravity();
                    }
                }
            }
        }
    }

    private void ApplyGravity(Rigidbody rigidbody)
    {
        GravityController gravityController = rigidbody.gameObject.GetComponent<GravityController>();
        if (gravityController != null)
        {
            gravityController.SetGravity(gravity);
        }
        else
        {
            DirectionalGravityController directionalGravityController = rigidbody.gameObject.GetComponent<DirectionalGravityController>();
            if (directionalGravityController != null)
            {
                directionalGravityController.SetGravity(gravity);
            }
        }
    }
}
