using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ubiq.XR
{
    public class CombinedGraspController : MonoBehaviour
    {
        public HandController controller;

        private Collider contacted;
        private IGraspable grasped;
        private Rigidbody graspedRigidbody; // Reference to the Rigidbody of the grasped object

        private void Start()
        {
            controller.GripPress.AddListener(Grasp);
        }

        public void Grasp(bool grasp)
        {
            if (grasp)
            {
                if (contacted != null)
                {
                    // Parent because physical bodies consist of a rigid body, and colliders *below* it in the scene graph
                    grasped = contacted.gameObject.GetComponentsInParent<MonoBehaviour>().Where(mb => mb is IGraspable).FirstOrDefault() as IGraspable;
                    graspedRigidbody = contacted.GetComponentInParent<Rigidbody>();

                    // Disable gravity on the grasped object's Rigidbody
                    if (graspedRigidbody != null)
                    {
                        graspedRigidbody.useGravity = false;
                    }

                    grasped.Grasp(controller);
                }
            }
            else
            {
                if (grasped != null)
                {
                    // Re-enable gravity on the grasped object's Rigidbody
                    if (graspedRigidbody != null)
                    {
                        graspedRigidbody.useGravity = true;
                    }

                    grasped.Release(controller);
                    grasped = null;
                    graspedRigidbody = null;
                }
            }
        }

        // *this* collider is the trigger
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponentsInParent<MonoBehaviour>().Where(mb => mb is IGraspable).FirstOrDefault() != null)
            {
                contacted = collider;
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (contacted == collider)
            {
                contacted = null;
            }
        }
    }
}