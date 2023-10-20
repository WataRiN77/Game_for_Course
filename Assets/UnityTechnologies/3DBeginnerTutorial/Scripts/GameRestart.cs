using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public float fadeDuration = 6f;
    public GameObject player;
    public AudioSource resetAudio;
    public Light sunLight;

    float m_timer = 0f;

    bool m_IsPlayerAtDoor;
    bool isPlayed = false;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtDoor = true;
        }
    }

    void FixedUpdate ()
    {
        if(m_IsPlayerAtDoor)
        {
            if(!isPlayed)
            {
                resetAudio.Play();
                isPlayed = true;
            }
            m_timer += Time.deltaTime;

            if(m_timer > fadeDuration)
            {
                SceneManager.LoadScene (0);
                SceneManager.UnloadSceneAsync("Scene2");
                //Debug.Log(m_IsPlayerAtDoor);
            }            
            
        }
        
    }
}