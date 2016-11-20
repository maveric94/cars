using UnityEngine;
using System.Collections;

public interface ICollisionReceiver 
{
    void CollisionEnter(Collision collision, int tag);
    void CollisionExit(Collision collision, int tag);
    void CollisionStay(Collision collision, int tag);

    void TriggerEnter(Collider other, int tag);
    void TriggerExit(Collider other, int tag);
    void TriggerStay(Collider other, int tag);
}
