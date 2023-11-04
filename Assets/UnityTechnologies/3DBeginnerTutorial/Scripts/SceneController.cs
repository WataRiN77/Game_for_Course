using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float fadeDuration;
    public float displayImageDuration;
    
    public CanvasGroup ExitImageCanvasGroup; 
    public CanvasGroup ReturnImageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerAtDoor;
    float m_Timer;

    GameObject player;
    public GameObject Counter;

    public AudioSource resetAudio;
    public Light sunLight;

    bool isPlayed = false;

    int SwitchCount = 0;

    void Start()
    {
        GameObject p;
        p = GameObject.Find("JohnLemon");
        player = p;
    }

    void OnTriggerEnter (Collider other)
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (other.gameObject == player)
        {
            if (SceneIndex == 0) m_IsPlayerAtExit = true;
            else                 m_IsPlayerAtDoor = true;
        }
    }

    public void LoadNextScene(bool isCyclical=false)
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (buildIndex > SceneManager.sceneCountInBuildSettings-1) buildIndex = 0;
    
        SceneManager.LoadScene(buildIndex);
    }

    void FixedUpdate ()
    {
        //player = p;
        if (m_IsPlayerAtExit)
        {
            SwitchCount += 1;
            Debug.Log(SwitchCount);
            DontDestroyOnLoad(player);
            //DontDestroyOnLoad(Counter);
            LoadNextScene(true);    
        }
        if(m_IsPlayerAtDoor)
        {
            if(!isPlayed)
            {
                resetAudio.Play();
                isPlayed = true;
            }
            m_Timer += Time.deltaTime;
            //Debug.Log(m_Timer);

            if(m_Timer > fadeDuration)
            {
                SwitchCount += 1;
                Debug.Log(SwitchCount);
                //DontDestroyOnLoad(Counter);
                LoadNextScene(true);
                //DontDestroyOnLoad(player); 
            }
        }
    }
}
