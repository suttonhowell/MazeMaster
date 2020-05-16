using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private MazeSpawner mazeSpawner;
    private UIController uiController;
    private GameObject prevMaze;
    private GameObject curMaze;
    public Image blackImg;

    private int choiceCounter;
    private bool moving;
    private int turning;
    private float turnAngle;
    private GameObject destination;
    public float speed;
    private bool fadeout;
    private Color32 myColor;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        mazeSpawner = FindObjectOfType<MazeSpawner>();
        uiController = FindObjectOfType<UIController>();
        this.choiceCounter = 0;
        if (MazeBlueprint.path.Count == 0)
        {
            MazeBlueprint.createPath(5);
        }
        this.moving = true;
        this.curMaze = mazeSpawner.firstSpawn();
        this.destination = curMaze.transform.Find("choicePosition").gameObject;
        uiController.updateUI();
        this.speed = 25;
        this.turning = -1;
        this.turnAngle = 0;
        this.prevMaze = new GameObject("prevMaze");
        fadeout = false;
        myColor = new Color32(0, 0, 0, 0);
        count = 0;
    }

    // Update is called once per frame
    void Update() {
        //check to see if round is over
        if (MazeBlueprint.turn > MazeBlueprint.round)
        {
            count++;
            if (count < 20)
            {
                return;
            }
            //increase round
            MazeBlueprint.round++;
            MazeBlueprint.turn = 1;
            //reload scene or win scene
            if (MazeBlueprint.path.Count < MazeBlueprint.round) winGame();
            else SceneManager.LoadScene("RoundChangeScene");
        }

        //see if we are rotating towards new intersection
        if (turning != -1) {
            turn();
        }
        //see if we are moving towards choice 
        if (moving) {
            move();
            return;
        }

        //if not moving, we will check for button press for decison
        if (Input.GetKeyUp(KeyCode.RightArrow) && turning == -1) {
            rightTurn();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && turning == -1)
        {
            leftTurn();
        }

    }
    
    public void move()
    {
        if (transform.position == destination.transform.position)
        {
            //delete the old maze piece to clean up
            //tell the game we are ready to choose a direction
            Destroy(prevMaze);
            moving = false;
            return;
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, step);
    }

    public void turn()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, this.turnAngle, 0), speed * 10 * Time.deltaTime);
        if (transform.rotation.eulerAngles.y == curMaze.transform.rotation.eulerAngles.y)
        {
            turning = -1;
            this.destination = curMaze.transform.Find("choicePosition").gameObject;
            moving = true;
        }
    }

    public void rightTurn()
    {
       
        //check if right decision made
        if (MazeBlueprint.wrongTurn(1))
        {
            loseGame();
        }
        else if (MazeBlueprint.turn == MazeBlueprint.path.Count + 1)
        {
            winGame();
        }
        //spawn and move next piece
        MazeBlueprint.turn++;
        this.prevMaze = curMaze;
        this.curMaze = mazeSpawner.spawnMaze(1, true, this.prevMaze);
        this.turning = 1;
        this.turnAngle = (this.turnAngle + 90) % 360;
    }

    public void leftTurn()
    {
        if (MazeBlueprint.wrongTurn(0))
        {
            loseGame();
        }
        else if (MazeBlueprint.turn == MazeBlueprint.path.Count + 1)
        {
            winGame();
        }
        //spawn and move next piece
        MazeBlueprint.turn++;
        this.prevMaze = curMaze;
        this.curMaze = mazeSpawner.spawnMaze(0, true, this.prevMaze);
        this.turning = 0;
        if (this.turnAngle > 0) this.turnAngle = this.turnAngle - 90;
        else this.turnAngle = 270;
        fadeout = true;
    }

    private void loseGame()
    {

    }

    private void winGame()
    {
        SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
    }
}
