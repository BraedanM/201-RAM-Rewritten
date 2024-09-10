using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 20, -2);//offset for the camera to follow above and behind the player

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;//position is the players with offset
    }
}
