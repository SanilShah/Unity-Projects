using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    public GameObject groundPrefab;
    public GameObject firstGround;

    private bool finishMoveGround;
    private bool finishedRandomGround;
    private List<GameObject> listGroundForward = new List<GameObject>();
    private List<GameObject> listGroundBack = new List<GameObject>();
    private Vector3 firstForwardPos;
    private Vector3 firstBackPos;

    private int numberofGrounds = 5;
    private float timeToMove = 1f;

    void Start()
    {
        firstForwardPos = firstGround.transform.position + Vector3.forward * firstGround.transform.localScale.z
            + new Vector3(0, -10, 0);
        firstBackPos = firstGround.transform.position + Vector3.back * firstGround.transform.localScale.z
            + new Vector3(0, -10, 0);
        StartCoroutine(RandomGroundForward(firstForwardPos, numberofGrounds, listGroundForward));
        StartCoroutine(RandomGroundBack(firstBackPos, numberofGrounds, listGroundForward));
       //tartCoroutine(MoveGround(firstBackPos, numberofGrounds, listGroundForward));
    }


    void Update()
    {
        //When all ground is created, start to move ground
        if (finishedRandomGround && !finishMoveGround)
        {
            for (int i = 0; i < listGroundForward.Count; i++)
            {
                StartCoroutine(MoveGround(listGroundForward[i], listGroundForward[i].transform.position, listGroundForward[i].transform.position + new Vector3(0, 10f, 0), timeToMove));
            }
            for (int i = 0; i < listGroundBack.Count; i++)
            {
                StartCoroutine(MoveGround(listGroundBack[i], listGroundBack[i].transform.position, listGroundBack[i].transform.position + new Vector3(0, 10f, 0), timeToMove));
            }
            finishMoveGround=true;
        }
    }

    IEnumerator MoveGround(GameObject ground, Vector3 startPos, Vector3 endPos, float timeToMove)
    {
        float t = 0;
        while(t < timeToMove)
        {
            float fraction = t / timeToMove;
            ground.transform.position = Vector3.Lerp(startPos, endPos, fraction);
            t += Time.deltaTime;
            yield return null;
        }

        ground.transform.position = endPos;
        finishMoveGround = true;
    }

    IEnumerator RandomGroundForward(Vector3 position, int number, List<GameObject> newList)
    {
        finishedRandomGround = false;

        for (int i = 0; i < number; i++)
        {
            GameObject currentGround = Instantiate(groundPrefab, position, Quaternion.identity);
            newList.Add(currentGround);
            currentGround.transform.SetParent(firstGround.transform.parent);
            position = currentGround.transform.position + Vector3.forward * currentGround.transform.localScale.z;
            yield return new WaitForSeconds(.1f);
        }

        finishedRandomGround = true;
    }

    IEnumerator RandomGroundBack(Vector3 position, int number, List<GameObject> newList)
    {
        finishedRandomGround = false;

        for (int i = 0; i < number; i++)
        {
            GameObject currentGround = Instantiate(groundPrefab, position, Quaternion.identity);
            newList.Add(currentGround);
            currentGround.transform.SetParent(firstGround.transform.parent);
            position = currentGround.transform.position + Vector3.back* currentGround.transform.localScale.z;
            yield return new WaitForSeconds(.1f);
        }

        finishedRandomGround = true;
    }
}
