using UnityEngine;
using Mirror;

public class Movimenti : NetworkBehaviour
{
    private Rigidbody rb;

    private float fSpeed = 3f;

    public Transform posCamera;

    private Animator animator;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        rb.interpolation = RigidbodyInterpolation.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        if(!isLocalPlayer) return;

        Vector3 cameraForward = posCamera.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = posCamera.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 movimento = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movimento += cameraForward; // Avanti
        }
        if (Input.GetKey(KeyCode.S))
        {
            movimento -= cameraForward; // Indietro
        }
        if (Input.GetKey(KeyCode.A))
        {
            movimento -= cameraRight; // Sinistra
        }
        if (Input.GetKey(KeyCode.D))
        {
            movimento += cameraRight; // Destra
        }

        movimento.Normalize();

        if (movimento != Vector3.zero)
        {
            rb.linearVelocity = movimento * fSpeed;
            animator.SetBool("Cammina", true);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            animator.SetBool("Cammina", false);
        }
    }
}
