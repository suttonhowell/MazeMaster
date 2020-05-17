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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutorialClick()
    {
        MazeBlueprint.clear();
        SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
    }

    public void startClick()
    {
        MazeBlueprint.clear();
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }

    public void mainMenuClick()
    {
        MazeBlueprint.clear();
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
}
