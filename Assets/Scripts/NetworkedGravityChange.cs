using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ubiq.Messaging;
using Ubiq.XR;

public class NetworkedGravityChange : MonoBehaviour
{
    NetworkContext context;
    public Rigidbody rb;
    public bool isKinematic = false;
   // public Hand grasped;

    // Start is called before the first frame update
    void Start()
    {
        context = NetworkScene.Register(this);
        rb = GetComponent<Rigidbody>();
    }

    Vector3 lastPosition;
    Quaternion lastRotation;


    // Update is called once per frame
    void Update()
    {
        bool positionChanged = lastPosition != transform.localPosition;
        bool rotationChanged = lastRotation != transform.localRotation;

        if (positionChanged || rotationChanged)
        {
            lastPosition = transform.localPosition;
            lastRotation = transform.localRotation;

            context.SendJson(new Message()
            {
                position = transform.localPosition,
                rotation = transform.localRotation,
                isKinematic = isKinematic
            });
        }
    }



    private struct Message
    {
        public Vector3 position;
        public Quaternion rotation;
        public bool isKinematic;
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        // Parse the message
        var m = message.FromJson<Message>();

        // Use the message to update the Component
        transform.localPosition = m.position;
        transform.localRotation = m.rotation;
        isKinematic = m.isKinematic;

        // Make sure the logic in Update doesn't trigger as a result of this message
        lastPosition = transform.localPosition;
        lastRotation = transform.localRotation;

        if (rb != null)
        {
            rb.isKinematic = isKinematic;
        }
    }      
}

