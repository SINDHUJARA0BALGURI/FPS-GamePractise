using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public CharacterController character;
    Vector3 moveinput;
    public float mouseSenstivity;
    public float verticalVelocity;
    public bool invertX, invertY;
    public float lookAngle;
    Vector2 mouseInput;
    public float gravity = 20f;
    public float jumpForce = 10f;
    public Transform cameraTransform;
    public Transform firePoint;
    public GameObject prefab;
    bool canJump;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayAudio("Background");
    }

    // Update is called once per frame
    void Update()
    {
        MovingThePlayer();
        Run();



        //camera rotation using mouseinput
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSenstivity;
        


        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles + new Vector3(mouseInput.y, 0, 0));

        if (Input.GetMouseButtonDown(0))
        {
            //raycast
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 50f))
            {
                firePoint.LookAt(hit.point);
            }
            else
            {
                if (Vector3.Distance(cameraTransform.position, hit.point) > 2f)
                {
                    firePoint.LookAt(cameraTransform.position + (cameraTransform.forward * 30f));
                }

            }

            Instantiate(prefab, firePoint.position, firePoint.rotation);
        }
    }



    void MovingThePlayer()
    {
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 verMove = transform.forward * Input.GetAxis("Vertical");
        moveinput = horiMove + verMove;
        moveinput *=  moveSpeed * Time.deltaTime;

        ApplyGravity();
        
        character.Move(moveinput); //moves the player in given direction
       
    }


    void ApplyGravity()
    {

        moveinput.y += Physics.gravity.y * gravity * Time.deltaTime;
        PlayerJump();
    }
   


    void PlayerJump()
    {
        if (character.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveinput.y = jumpForce;
        }

    }
    void Run()
    {
        if (Input.GetKey(KeyCode.E))
        {
            moveinput = moveinput * runSpeed;
        }
        else
        {
            moveinput *= moveSpeed;
        }

    }


}


