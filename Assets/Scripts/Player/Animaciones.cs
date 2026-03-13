using UnityEngine;

public class Animaciones : MonoBehaviour
{

    private Animator animator;

    private MovimientoRigidBody controles;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        controles = this.gameObject.GetComponent<MovimientoRigidBody>();

        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"LinearX, {Mathf.Abs(rb.linearVelocity.x)}");
        Debug.Log($"LinearY, {Mathf.Abs(rb.linearVelocity.y)}");
        Debug.Log($"LinearZ, {Mathf.Abs(rb.linearVelocity.z)}");
    }

    public void AnimacionesValues()
    {

        if(Mathf.Abs(rb.linearVelocity.x) > 0 || Mathf.Abs(rb.linearVelocity.z) > 0)
        {
            animator.SetTrigger("Andar");
        }

        animator.SetBool("Atras", rb.linearVelocity.z < 0);
        animator.SetBool("Delante", rb.linearVelocity.z > 0);
        animator.SetBool("Derecha", rb.linearVelocity.x > 0);
        animator.SetBool("Izquierda", rb.linearVelocity.x < 0);

        animator.SetFloat("VelocidadX", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("VelocidadVert", Mathf.Abs(rb.linearVelocity.y));
        animator.SetFloat("VelocidadZ", Mathf.Abs(rb.linearVelocity.z));

        animator.SetFloat("XReal", rb.linearVelocity.x);
        animator.SetFloat("VertReal", rb.linearVelocity.y);
        animator.SetFloat("ZReal", rb.linearVelocity.z);

        animator.SetBool("Salto", controles.pressSpace && controles.isGrounded);
        animator.SetBool("EnSuelo", controles.isGrounded);
        animator.SetBool("Corriendo", controles.isRunning);
        
    }
}
