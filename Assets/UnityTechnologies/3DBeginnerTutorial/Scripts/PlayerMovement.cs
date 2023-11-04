using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    //public float force     = 5f;

    Animator    m_Animator;
    Rigidbody   m_Rigidbody;
    Vector3     m_Movement;
    Quaternion  m_Rotation = Quaternion.identity;
    AudioSource m_AudioSource;

    //public GameObject GetPlayer(){return playerJL;}

    void Start ()
    {
        m_Animator    = GetComponent<Animator>   ();
        m_Rigidbody   = GetComponent<Rigidbody>  ();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical   = Input.GetAxis ("Vertical");
        //float height     = Input.GetAxis ("")
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput   = !Mathf.Approximately (vertical,   0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        if(isWalking)
        {
            if(m_AudioSource.isPlaying == false)
            {
                m_AudioSource.Play();
                //Debug.Log("SOUND");
            }
        }
        else m_AudioSource.Stop();
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + 3 * m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}