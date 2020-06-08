using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ( Main Game Class ), Attached to Main Camera. Translation of Stack.

public class StackMovement : MonoBehaviour
{
    public static StackMovement SMInstance;

    // Objects
    public GameObject Stack;
    public GameObject playerRef; 
    public GameObject Ground;
    public GameObject mainArenaBox;
    public GameObject currentFallenStack;
    public GameObject Camera;
    public GameObject tempStack;
    public static GameObject newStack;
    public static GameObject lastStack;

    // variables
    public static int score = 0; 
    public static bool StackSpawned = false;

    // Stack Positions
    [SerializeField]
    private Vector3 _startPos = new Vector3(0, 1, 40);
    [SerializeField]
    private Vector3 _startPosforX = new Vector3(40, 1, 0);
    private Vector3 _lastStackPos;
    private Vector3 _newStackPos;
   
    // Camera Positions
    private Vector3 _camStartPos;
    private Vector3 _camEndPos;

    // Axis 
    public bool _isEven { get; set; }
    public enum Axis { X, Z }
    public static Axis myAxis = Axis.Z;
    public static Axis oldAxis = Axis.Z;

    // Speeds
    public float speed = 100;
    private float _stackIndex = 2f;

    void CreateNewStack()
    {
        {
            if (myAxis == Axis.Z)
            {
                if (_isEven == true)
                {
                    _newStackPos = new Vector3(0, _lastStackPos.y + _stackIndex, _startPos.z - 80);
                }
                else
                {
                    _newStackPos = new Vector3(0, _lastStackPos.y + _stackIndex, _startPos.z);
                }
            }
            else if (myAxis == Axis.X)
            {
                if (_isEven == true)
                {
                    _newStackPos = new Vector3(_startPosforX.x , _lastStackPos.y + _stackIndex, 0);
                }
                else
                {
                    _newStackPos = new Vector3(_startPosforX.x - 80, _lastStackPos.y + _stackIndex, 0);
                }
            }

            // Spawn new stack
            newStack = Instantiate(Stack, _newStackPos, Quaternion.identity);
            Utilities.ChangeRandomColor(newStack);
            StackSpawned = true;

            _lastStackPos = _newStackPos;
        }
    }

    void SwitchStackPosition()
    {
        if (myAxis == Axis.Z)
        {
            if (_isEven == true)
            {
                _isEven = false;
                oldAxis = myAxis;
            }
            else if (_isEven == false)
            {
                _isEven = true;
                oldAxis = myAxis;
                myAxis = Axis.X;
            }
        }
        else if (myAxis ==Axis.X)
        {
            if (_isEven == true)
            {
                _isEven = false;
                oldAxis = myAxis;
            }
            else if (_isEven == false)
            {
                _isEven = true;
                oldAxis = myAxis;
                myAxis = Axis.Z;
            }
        }
    }

    void StackTranslation()
    {
        if (myAxis == Axis.Z)
        {
            if (_isEven == false)
                newStack.transform.Translate(0, 0, -Time.deltaTime * 10 * speed);
            else
                newStack.transform.Translate(0, 0, Time.deltaTime * 10 * speed);
        }
        else if (myAxis == Axis.X)
        {
            if (_isEven == false)
                newStack.transform.Translate(Time.deltaTime * 10 * speed, 0, 0);
            else
                newStack.transform.Translate(-Time.deltaTime * 10 * speed, 0, 0);
        }

    }

    GameObject ReassignFallenStack(GameObject csFallenStack)
    {
        GameObject myFallenStack = csFallenStack;
        
        return myFallenStack;
    }

    void Start()
    {
        // Reassign Static References on Start for reload.
        Time.timeScale = 1;
        SMInstance = this;
        score = 0;
        StackSpawned = false;
        _startPos = new Vector3(0, 1, 40);
        _startPosforX = new Vector3(40, 1, 0);
        myAxis = Axis.Z;
        oldAxis = Axis.Z;

        currentFallenStack = ReassignFallenStack(Ground);
        tempStack = Stack;
        _lastStackPos = _startPos;
        CreateNewStack();
       
    }


 
    void Update()
    {
        StackSpawned = false;

        StackTranslation();

        if (Input.touchCount == 1)
        {
           
            if((Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began)) 
                && GameManager.gameHasEnded == false )
            {

                SwitchStackPosition();
                lastStack = newStack;
                lastStack.GetComponent<Rigidbody>().useGravity = true;
                
                lastStack.name = "LastStack";
                            
                CreateNewStack();
                Utilities.CheckIfStackable(lastStack, currentFallenStack);
                score++;

                // Translate player reference on y axis for camera follow.
                playerRef.transform.position = new Vector3(playerRef.transform.position.x, playerRef.transform.position.y + 2,
                                                           playerRef.transform.position.z);
            }
        }

        if (cutStack.stackCollided == true)
        {
            currentFallenStack = ReassignFallenStack(cutStack.fallenStack);
            cutStack.stackCollided = false;
        }

    }
}
