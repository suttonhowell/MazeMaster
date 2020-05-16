using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject mazeObj;
    public GameObject mazeObjR;
    public GameObject mazeObjL;
    public GameObject deadEndObj;
    // Start is called before the first frame update
    void Start()
    {
        //nothing to do on start
    }

    // Update is called once per frame
    void Update()
    {
        // nothing to do on update; must wait for player choice
    }

    /*
     * direction 0 = left
     * direction 1 = right
     */
    public GameObject spawnMaze(int direction, bool correct, GameObject oldMaze)

    {
        UnityEngine.Debug.Log("MAZE SPAWNER ACTIVATED");
        //get rotation of old maze
        GameObject mazeSpawn = null;
        GameObject spawnObj = null;
        float oldRotationY = oldMaze.transform.rotation.eulerAngles.y;
        Vector3 newPos = new Vector3 (oldMaze.transform.position.x, oldMaze.transform.position.y, oldMaze.transform.position.z);
        Vector3 newAngle = new Vector3 (oldMaze.transform.rotation.eulerAngles.x, oldRotationY, oldMaze.transform.rotation.eulerAngles.z);
        // check if correct first
        if (correct)
        {
            //correct so we need to use the intersection game piece
            //figure out if we need the sign or not
            if (MazeBlueprint.turn == MazeBlueprint.round)
            {
                if (MazeBlueprint.turn >= MazeBlueprint.path.Count)
                {
                    spawnObj = mazeObj; 
                }
                else if ((int)MazeBlueprint.path[MazeBlueprint.turn] == 0)
                {
                    spawnObj = mazeObjL;
                }
                else
                {
                    spawnObj = mazeObjR;
                }
            }
            else {
                spawnObj = mazeObj;
            }
            //check if left turn
            if (direction == 0)
            {
                if (oldRotationY == 0)
                {
                    newPos.x = newPos.x - (float) 10.63;
                    newPos.z = newPos.z - (float) 10.63;
                }
                else if (oldRotationY == 90)
                {
                    newPos.x = newPos.x - (float)10.63;
                    newPos.z = newPos.z + (float)10.63;
                }
                else if (oldRotationY == 180)
                {
                    newPos.x = newPos.x + (float)10.63;
                    newPos.z = newPos.z + (float)10.63;
                }
                else if (oldRotationY == 270)
                {
                    newPos.x = newPos.x + (float)10.63;
                    newPos.z = newPos.z - (float)10.63;
                }
                else
                {
                    UnityEngine.Debug.Log("an error occurred");
                }

                //after position change, update new angle
                if (oldRotationY > 0) newAngle.y = oldRotationY - 90;
                else newAngle.y = 270;
            }
            //check if right turn
            if (direction == 1)
            {
                //check angle to set new position (adjusted for the different 
                if (oldRotationY == 0)
                {
                    newPos.x = newPos.x - (float)10.8;
                    newPos.z = newPos.z + (float)10.8;
                }
                else if (oldRotationY == 90)
                {
                    newPos.x = newPos.x + (float)10.8;
                    newPos.z = newPos.z + (float) 10.8;
                }
                else if (oldRotationY == 180)
                {
                    newPos.x = newPos.x + (float)10.8;
                    newPos.z = newPos.z - (float)10.8;
                }
                else if (oldRotationY == 270)
                {
                    newPos.x = newPos.x - (float)10.8;
                    newPos.z = newPos.z - (float)10.8;
                }
                else
                {
                    UnityEngine.Debug.Log("an error occurred");
                }

                //after position change, update new angle
                newAngle.y = (oldRotationY + 90) % 360;

            }//end of if direction is right
        }//end of if correct turn

        //instantiate new gameobject
        mazeSpawn = Instantiate(spawnObj, new Vector3(newPos.x, newPos.y, newPos.z), Quaternion.identity);
        mazeSpawn.transform.rotation = Quaternion.Euler(newAngle);
        //rotate new gameobject into place

        return mazeSpawn;
            
    }

    public GameObject firstSpawn()
    {
        GameObject spawnObj;
        if (MazeBlueprint.round > 1)
        {
            spawnObj = mazeObj;
        }
        else if ((int)MazeBlueprint.path[0] == 0)
        {
            spawnObj = mazeObjL;
        }
        else
        {
            spawnObj = mazeObjR;
        }

        GameObject mazeSpawn = Instantiate(spawnObj, new Vector3((float)0.7275391, (float)8.363531, (float)-0.3254), Quaternion.identity);
        return mazeSpawn;
    }
}
