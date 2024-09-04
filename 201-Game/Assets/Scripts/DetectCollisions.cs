using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //when an object collides with this object it destroys the other one.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
