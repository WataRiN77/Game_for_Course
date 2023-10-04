/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float TurnSpeed = 20f;

    Vector3    c_Movement;
    Quaternion c_Rotation = Quaternion.identity;
    Animator   c_Animator;
    Rigidbody  c_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        c_Animator  = GetComponent<Animator> ();
        c_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Input_Horizontal = Input.GetAxis("Horizontal"); // Horizontal Input
        float Input_Vertical   = Input.GetAxis("Vertical");   // Vertical   Input

        c_Movement.Set(Input_Horizontal, 0f, Input_Vertical);
        c_Movement.Normalize();

        bool Move_Horizontally = !Mathf.Approximately(Input_Horizontal, 0f);
        bool Move_Vertically   = !Mathf.Approximately(Input_Vertical  , 0f);

        bool isWalking = Move_Horizontally || Move_Vertically;

        c_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, c_Movement, TurnSpeed * Time.deltaTime, 0f);
        c_Rotation = Quaternion.LookRotation(desiredForward);

    }

    void OnAnimatoerMove()
    {

        c_Rigidbody.MovePosition(c_Rigidbody.position + c_Movement * c_Animator.deltaPosition.magnitude);
        c_Rigidbody.MoveRotation(c_Rotation);

    }
}
*/

// The code above cannot run correctly and I don't know WHY.

// No matter W, A, S or D is input, John Lemon just moves FORWARD.

// The following is exactly the same code from the tutorial.

// And it just works.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}