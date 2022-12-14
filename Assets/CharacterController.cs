using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    
    public AudioSource musicPlayer;
    public AudioClip backgroundMusic;
    public float maxSpeed;
    public float normalSpeed = 3.0f;
    public float sprintSpeed = 4.0f;

    public float rotation = 0.0f;
    float camRotation = 0.0f;
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidbody;

    public Animator anim;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    public float maxSprint = 5.0f;
    float sprintTimer;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
        
        sprintTimer = maxSprint;
        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
   
    }


    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        anim.SetBool("isOnGround", isOnGround);

        if(isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jumped");
            myRigidbody.AddForce(transform.up * jumpForce);
        }

        if(Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }else
        {
            maxSpeed = normalSpeed;
            if(Input.GetKey(KeyCode.LeftShift) ==false){
                sprintTimer = sprintTimer +Time.deltaTime;
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer,0.0f, maxSprint);

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

       // transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical"));

        //Vector3 newVelocity = transform.forward * Input.GetAxis("vertical") * maxSpeed;
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

        anim.SetFloat("speed", newVelocity.magnitude);
     
    }
}
