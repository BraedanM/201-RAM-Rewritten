using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //declaring objects and variables
    private Camera mainCamera;
    private Rigidbody rb;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public GameObject projectilePrefab;
    public GameObject player;


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
        {
            Instantiate(projectilePrefab, transform.position + (player.transform.forward * 1.5f), player.transform.rotation);
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

}
