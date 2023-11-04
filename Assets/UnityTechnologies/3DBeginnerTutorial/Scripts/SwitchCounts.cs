using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCounter : MonoBehaviour
{
    int SwitchCounts;
    int currentScene;
    int LastScene;
    // Start is called before the first frame update
    void Start()
    {
        SwitchCounts = 0;
        LastScene = 1;        
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        if(SceneManager.GetSceneByName("Scene2").isLoaded) 
        {
            currentScene = 2;
        }
        else if(SceneManager.GetSceneByName("SampleScene").isLoaded)
        {
            currentScene = 1;
        }

        if(currentScene != LastScene) SwitchCounts += 1;

        LastScene = currentScene;

        Debug.Log(SwitchCounts);
    }
}
