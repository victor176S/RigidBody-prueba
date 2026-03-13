using UnityEngine;

public class MovimientoRigidBody : MonoBehaviour
{

    public bool maintainW, maintainA, maintainS, maintainD, maintainShift, maintainSpace;

    public bool pressSpace;

    private float dirX, dirZ;

    [Header ("Movimiento")]

    public float speed = 5f;

    public float jumpForce = 6f;

    private Rigidbody rb;

    public bool isGrounded;

    [SerializeField] private float runMultiplier = 2f;

    public bool isRunning = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        Controles();

        
    }

    void FixedUpdate()
    {
            if (maintainA)
            {
                dirX += -1;
            }

            if (maintainD)
            {
                dirX += 1;
            }

            if (maintainW)
            {
                dirZ += 1;
            }

            if (maintainS)
            {
                dirZ += -1;
            }

            if (maintainShift)
            {
                isRunning = true;
            }

            else
            {
                isRunning = false;
            }
        

        Vector3 direction = new Vector3(dirX, 0f, dirZ);

        float currentSpeed;

        if (isRunning)
        {
            currentSpeed = speed * runMultiplier;
        }

        else
        {
            currentSpeed = speed;
        }

        Vector3 velocity = direction * currentSpeed;

        Vector3 newVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        rb.linearVelocity = newVelocity;

        if (pressSpace)
        {
            Debug.Log("Press space");

            rb.AddForce(40 * 9.8f * Vector3.up);
        }

        Debug.Log($"{dirX}, {dirZ}");

        Debug.Log($"Controles {maintainW}, {maintainA}, {maintainS}, {maintainD}");

        this.gameObject.GetComponent<Animaciones>().AnimacionesValues();

        dirX = 0;

        dirZ = 0;
 
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }



    private void Controles()
    {

        //hacia delante

        if (Input.GetKey(KeyCode.W))
        {
            maintainW = true;
        }

        else
        {
            maintainW = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            
        }

        //hacia la izq

        if (Input.GetKey(KeyCode.A))
        {
            maintainA = true;
        }

        else
        {
            maintainA = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {

        }

        //hacia atras

        if (Input.GetKey(KeyCode.S))
        {
            maintainS = true;
        }

        else
        {
            maintainS = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            
        }

        //hacia la derecha

        if (Input.GetKey(KeyCode.D))
        {
            maintainD = true;
        }

        else
        {
            maintainD = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            
        }

        //correr

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maintainShift = true;
        }

        else
        {
            maintainShift = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
           
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressSpace = true;
        }

        else
        {
            pressSpace = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            maintainSpace = true;
        }

        else
        {
            maintainSpace = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
           
        }
    }
}
