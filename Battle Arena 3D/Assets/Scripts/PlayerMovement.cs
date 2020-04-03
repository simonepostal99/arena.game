using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float camRotationSpeed;
    [SerializeField] private Transform playerBody;

    private float camRotationY;
    [SerializeField] private float camMinY, camMaxY;
    [SerializeField] private float rotationSmoothSpeed;

    private float bodyRotationX;

    [SerializeField] private Transform camera;

    private Vector3 directionalIntentX, directionalIntentY;
    private Rigidbody rb;
    private float speed;
    [SerializeField] private float maxSpeed, walkSpeed, runSpeed;

    [SerializeField] private float extraGravity;
    private bool grounded;
    [SerializeField] private float jumpPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        LockCursor();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        CameraRotation();
        Movement();
        ExtraGravity();
        GroundCheck();
        Jump();
	}


    private void LockCursor()
    {
        //blocco del cursore
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
        camRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;

        camRotationY = Mathf.Clamp(camRotationY, camMinY, camMaxY);

        Quaternion camTargetRotation = Quaternion.Euler(-camRotationY, 0, 0);
        Quaternion bodyTargetRotation = Quaternion.Euler(0, bodyRotationX, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRotation, Time.deltaTime * rotationSmoothSpeed);

        camera.transform.localRotation = Quaternion.Lerp(camera.localRotation, camTargetRotation, Time.deltaTime * rotationSmoothSpeed);
    }


    private void Movement()
    {
        directionalIntentX = camera.right;
        directionalIntentX.y = 0;
        directionalIntentX.Normalize();

        directionalIntentY = camera.forward;
        directionalIntentY.y = 0;
        directionalIntentY.Normalize();

        Vector3 xDir = directionalIntentX * Input.GetAxis("Horizontal") * speed;
        Vector3 yDir = directionalIntentY * Input.GetAxis("Vertical") * speed;

        rb.velocity = xDir + yDir + Vector3.up * rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
    }


    private void ExtraGravity()
    {
        rb.AddForce(Vector3.down * extraGravity);
    }

    private void GroundCheck()
    {
        RaycastHit groundHit;
        grounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 1.25f);
    }

    private void Jump()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    public float getExtraGravity()
    {
        return extraGravity;
    }

    public void setExtraGravity(float extraGravity)
    {
        this.extraGravity = extraGravity;
    }
}
