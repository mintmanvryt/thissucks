using UnityEngine;
using easyInputs;

namespace MyNamespace
{
    public class MonkePhysicsGrab : MonoBehaviour
    {
        [Header("script made by The Kachow DO NOT STEAL")]
        [Header("Give credits to The Kachow")]
        public Collider LeftHand;
        public Collider RightHand;
        public GameObject Grabbable;
        public bool UseNozzleAndLineRenderer = true;
        public Transform Nozzle;
        public float ThrowForce = 10f;
        public LineRenderer LineRenderer;

        private bool _isGrabbing = false;
        private Transform _originalParent;
        private Rigidbody _grabbableRigidbody;

        void Start()
        {
            _originalParent = Grabbable.transform.parent;
            _grabbableRigidbody = Grabbable.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (!_isGrabbing && (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand) || EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand)))
            {
                Collider handCollider = null;
                if (LeftHand.bounds.Intersects(Grabbable.GetComponent<Collider>().bounds))
                {
                    handCollider = LeftHand;
                }
                else if (RightHand.bounds.Intersects(Grabbable.GetComponent<Collider>().bounds))
                {
                    handCollider = RightHand;
                }

                if (handCollider != null)
                {
                    _isGrabbing = true;
                    Grabbable.transform.SetParent(handCollider.transform);
                    Grabbable.transform.localPosition = Vector3.zero; // set position to (0,0,0) relative to hand
                    Grabbable.GetComponent<Collider>().enabled = false;
                    _grabbableRigidbody.isKinematic = true; // disable physics
                }
            }
            else if (_isGrabbing && (EasyInputs.GetGripButtonDown(EasyHand.RightHand) || EasyInputs.GetGripButtonDown(EasyHand.LeftHand)))
            {
                _isGrabbing = false;
                Grabbable.transform.SetParent(_originalParent);
                Grabbable.GetComponent<Collider>().enabled = true;
                _grabbableRigidbody.isKinematic = false; // enable physics

                if (UseNozzleAndLineRenderer)
                {
                    Vector3 throwDirection = Nozzle.transform.forward;
                    _grabbableRigidbody.AddForce(throwDirection * ThrowForce, ForceMode.Impulse);

                    if (LineRenderer != null)
                    {
                        LineRenderer.enabled = false;
                    }
                }
            }
            else if (_isGrabbing)
            {
                // update position to match hand position
                Grabbable.transform.localPosition = Vector3.zero; // set position to (0,0,0) relative to hand
                Grabbable.transform.localRotation = Quaternion.identity; // set rotation to identity relative to hand
            }
        }
    }
}
