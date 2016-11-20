using UnityEngine;
using System.Collections;

public class CollisionMonitor : MonoBehaviour 
{
    [SerializeField] new int tag;
    [SerializeField] MonoBehaviour target;

    ICollisionReceiver receiver = null;

    void Awake()
    {
        if (target != null)
        {
            receiver = target.GetComponent<ICollisionReceiver>();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (receiver != null)
        {
            receiver.CollisionEnter(collision, tag);
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (receiver != null)
        {
            receiver.CollisionExit(collision, tag);
        }
    }


    void OnCollisionStay(Collision collision)
    {
        if (receiver != null)
        {
            receiver.CollisionStay(collision, tag);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (receiver != null)
        {
            receiver.TriggerEnter(other, tag);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (receiver != null)
        {
            receiver.TriggerExit(other, tag);
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (receiver != null)
        {
            receiver.TriggerStay(other, tag);
        }
    }

}
