using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //was mostly used when there we no physical walls but in case projectiles get out this will delete them
    //boundaries set
    private float PosBound = 50;
    private float NegBound = -50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //When an object hits the boundaries of whats set for the playable area, it gets deleted.
        if (transform.position.z > PosBound | transform.position.z < NegBound)
        {
            Debug.Log("z Pos/Neg object Deleted");
            Destroy(gameObject);
        }
        else if(transform.position.x > PosBound | transform.position.x < NegBound)
        {
            Debug.Log("x Pos/Neg object Deleted");
            Destroy(gameObject);
        }
    }
}
