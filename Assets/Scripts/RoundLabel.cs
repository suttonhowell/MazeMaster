using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundLabel : MonoBehaviour
{
    [SerializeField] Text roundLabel;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        roundLabel.text = "Round " + MazeBlueprint.round.ToString("D1");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count > 20) SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }
}
