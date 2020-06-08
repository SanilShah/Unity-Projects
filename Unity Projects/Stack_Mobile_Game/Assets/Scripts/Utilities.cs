using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Static utitities for frequently used game tools.

public static class Utilities 
{
   
    public static void DestroyObjectDelayed(GameObject myObject, int delay)
    {
        MonoBehaviour.Destroy(myObject, 3);
    }


    public static void ClipCube(GameObject firstCube, GameObject secondCube, int currentAxis)
    {
       // if (currentAxis == 0)
        {
            float lengthFirstCube;
            float lengthSecondCube;
            float zDistance;
            float commonDistanceZ;
            float newZCord;
            float newZCord2;
            int delay = 1;
            
            GameObject secondCubeSpare = MonoBehaviour.Instantiate(secondCube,new Vector3(100,0,100), Quaternion.identity);
            secondCubeSpare.GetComponent<BoxCollider>().enabled = false;
           
            float zSCS;

            
            // Half lengths of Cubes
            lengthFirstCube = secondCube.transform.localScale.z / 2;
            lengthSecondCube = firstCube.transform.localScale.z / 2;

            // Distance on Z-Axis between the 2 cubes
            zDistance = Mathf.Abs(secondCube.transform.position.z - firstCube.transform.position.z);

            // Distance in common with the 2 cubes on Z-Axis
            commonDistanceZ = lengthFirstCube - (zDistance - lengthSecondCube);
            commonDistanceZ = (float)System.Math.Round(commonDistanceZ, 4);

            zSCS = secondCube.transform.localScale.z - commonDistanceZ;

            // Clipping :-
            // 1) Scale the cube on Z-Axis
            secondCube.transform.localScale = new Vector3(secondCube.transform.localScale.x, secondCube.transform.localScale.y, 
                                                          commonDistanceZ);

            
            secondCubeSpare.transform.localScale = new Vector3(secondCubeSpare.transform.localScale.x,
                                                                   secondCubeSpare.transform.localScale.y, zSCS);


            if (secondCubeSpare.transform.localScale.x < 0.1f || secondCubeSpare.transform.localScale.z < 0.1f)
                secondCubeSpare.SetActive(false);

            // 2) Position the cube inside the other cube along Z-Axis on its vertice.
            if (secondCube.transform.position.z > firstCube.transform.position.z)
            {
                newZCord = (lengthSecondCube - (commonDistanceZ / 2)) + (firstCube.transform.position.z);
                newZCord2 = secondCube.transform.position.z + commonDistanceZ/2;

                secondCube.transform.position = new Vector3(secondCube.transform.position.x, secondCube.transform.position.y, newZCord);
                secondCubeSpare.transform.position = new Vector3(secondCube.transform.position.x, secondCube.transform.position.y, newZCord2);
            }
            else
            {
                newZCord = (lengthSecondCube - (commonDistanceZ / 2)) + (firstCube.transform.position.z);
                newZCord2 = secondCube.transform.position.z - commonDistanceZ/2;

                secondCube.transform.position = new Vector3(secondCube.transform.position.x, secondCube.transform.position.y, newZCord - zDistance);
                secondCubeSpare.transform.position = new Vector3(secondCube.transform.position.x, secondCube.transform.position.y, newZCord2);
            }

            DestroyObjectDelayed(secondCubeSpare, delay);

            // Debugging
            /*
            Debug.Log("zDistance:" + zDistance);
            Debug.Log("firstCubeLength:" + lengthFirstCube);
            Debug.Log("secondCubeLength:" + lengthSecondCube);
            Debug.Log("commonDistanceZ:" + commonDistanceZ);
            Debug.Log("newZCord:" + newZCord);
            */
        }

       // else if ( currentAxis == 1)
        {
            float lengthFirstCube;
            float lengthSecondCube;
            float xDistance;
            float commonDistanceX;
            float newXCord;
            float newXCord2;
            int delay = 1;

            GameObject secondCubeSpare = MonoBehaviour.Instantiate(secondCube, new Vector3(100, 0, 100), Quaternion.identity);
            secondCubeSpare.GetComponent<BoxCollider>().enabled = false;

            float xSCS;

            // Half lengths of Cubes
            lengthFirstCube = secondCube.transform.localScale.x / 2;
            lengthSecondCube = firstCube.transform.localScale.x / 2;

            // Distance on X-Axis between the 2 cubes
            xDistance = Mathf.Abs(secondCube.transform.position.x - firstCube.transform.position.x);

            // Distance in common with the 2 cubes on Z-Axis
            commonDistanceX = lengthFirstCube - (xDistance - lengthSecondCube);
            commonDistanceX = (float)System.Math.Round(commonDistanceX, 4);

            xSCS = secondCube.transform.localScale.x - commonDistanceX;

            // Clipping :-
            // 1) Scale the cube on X-Axis
            secondCube.transform.localScale = new Vector3(commonDistanceX, secondCube.transform.localScale.y,
                                                          secondCube.transform.localScale.z);


            secondCubeSpare.transform.localScale = new Vector3(xSCS, secondCubeSpare.transform.localScale.y,
                                                                   secondCubeSpare.transform.localScale.z);

            if (secondCubeSpare.transform.localScale.x < 0.1f || secondCubeSpare.transform.localScale.z < 0.1f)
                secondCubeSpare.SetActive(false);

            // 2) Position the cube inside the other cube along X-Axis on its vertice.
            if (secondCube.transform.position.x > firstCube.transform.position.x)
            {
                newXCord = (lengthSecondCube - (commonDistanceX / 2)) + (firstCube.transform.position.x);
                newXCord2 = secondCube.transform.position.x + commonDistanceX/2;
                secondCube.transform.position = new Vector3(newXCord, secondCube.transform.position.y, secondCube.transform.position.z);
                secondCubeSpare.transform.position = new Vector3(newXCord2, secondCube.transform.position.y, secondCube.transform.position.z);
            }
            else
            {
                newXCord = (lengthSecondCube - (commonDistanceX / 2)) + (firstCube.transform.position.x);
                newXCord2 = secondCube.transform.position.x - commonDistanceX / 2;
                secondCube.transform.position = new Vector3(newXCord - xDistance, secondCube.transform.position.y, secondCube.transform.position.z);
                secondCubeSpare.transform.position = new Vector3(newXCord2, secondCube.transform.position.y, secondCube.transform.position.z);
            }

            DestroyObjectDelayed(secondCubeSpare, delay);

            // Debugging
            /*
            Debug.Log("zDistance:" + xDistance);
            Debug.Log("firstCubeLength:" + lengthFirstCube);
            Debug.Log("secondCubeLength:" + lengthSecondCube);
            Debug.Log("commonDistanceZ:" + commonDistanceX);
            Debug.Log("newZCord:" + newXCord);
            */
        }
    }

    public static void ChangeRandomColor(GameObject thisCube)
    {
        Color _randomColor = new Color(Random.value, Random.value, Random.value);

        thisCube.GetComponent<MeshRenderer>().material.color = _randomColor;
    }

    public static void CheckIfStackable(GameObject secondCube, GameObject firstCube)
    {
        Debug.Log("FirstCube:" + firstCube);
        Debug.Log("SecondCube:" + secondCube);

        float thresholdZDistance = firstCube.transform.localScale.z;
        float currentZDistance = Mathf.Abs(secondCube.transform.position.z - firstCube.transform.position.z);

        float thresholdXDistance = firstCube.transform.localScale.x;
        float currentXDistance = Mathf.Abs(secondCube.transform.position.x - firstCube.transform.position.x);

        Debug.Log(" Stack out of bounds on X-Axis, unstackable. ");
        Debug.Log(" ThresholdXDistance:" + thresholdXDistance);
        Debug.Log("currentXdistance:" + currentXDistance);

        if ( currentZDistance >= thresholdZDistance)
        {
            Debug.Log(" Stack out of bounds on Z-Axis, unstackable. ");
            Debug.Log(" ThresholdZDistance:" + thresholdZDistance);
            Debug.Log("currentZdistance:" + currentZDistance);
            Time.timeScale = 0;
            GameManager.CompleteLevel();
            GameManager.EndGame();
        }

        if (currentXDistance >= thresholdXDistance)
        {
            
            Time.timeScale = 0;
            GameManager.CompleteLevel();
            GameManager.EndGame();
        }

    }

    public static bool CheckOutOfBounds(GameObject firstCube, GameObject secondCube)
    {
        float thresholdZDistance = firstCube.transform.localScale.z;
        float currentZDistance = Mathf.Abs(secondCube.transform.position.z - firstCube.transform.position.z);

        float thresholdXDistance = firstCube.transform.localScale.x;
        float currentXDistance = Mathf.Abs(secondCube.transform.position.x - firstCube.transform.position.x);


        if (currentZDistance >= thresholdZDistance)
        {
            return true;
        }

        if (currentXDistance >= thresholdXDistance)
        {
            return true;
        }

        return false;
    }
}
