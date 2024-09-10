using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //this is used for projectiles to move forward
    public float speed = 10.0f;

    void Update()
    {//moves forward based on speed value times by forward vector and time
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
