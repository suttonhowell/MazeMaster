using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //wipe the blueprint if the main menu is started again
        MazeBlueprint.clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutorialClick()
    {
        SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
    }

    public void startClick()
    {
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }
}
