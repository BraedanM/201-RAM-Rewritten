using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//player can go through walls when the game starts speeding up for some reason
public class PlayerController : MonoBehaviour
{
    //declaring objects and variables
    private Camera mainCamera;
    private Rigidbody rb;
    private float lastUse;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public GameObject projectilePrefab;
    public GameObject player;
    public int numberOfProjectiles = 5;
    public float cooldown = 5f;


    // Start is called before the first frame update
    void Start()
    {
        //finds the camera
        mainCamera = FindObjectOfType<Camera>();
        //assigns name to rigidbody
        rb = GetComponent<Rigidbody>();
        //finds the player object
        player = GameObject.Find("Player");
        //helps stop the player moving on its own after collision
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //For the Player Projectile
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {//creates the prefab and positons it where the player is facing
            Instantiate(projectilePrefab, transform.position + (player.transform.forward * 1.5f), player.transform.rotation);
        }
        //spawns the special attack 
        if (Input.GetKeyDown(KeyCode.E) && Time.time > lastUse + cooldown)
        {
            SpawnProjectiles();
            lastUse = Time.time;
        }
     
        //Player movement from input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //moves the rigidbody
      Vector3 movement = new(horizontalInput, 0.0f, verticalInput);
        movement = speed * Time.deltaTime * movement.normalized;
       rb.MovePosition(transform.position + movement);

        //Player object follows mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void SpawnProjectiles()
    {
        for (int i = 0; i < numberOfProjectiles; i++)// spawns multiple as mush as the variable has
        {
            Vector3 spawnPosition = new Vector3(i * 1, 0, 1) + player.transform.position;//spawns based on where the player is
            Instantiate(projectilePrefab, spawnPosition, player.transform.rotation);
        }
    }
}
