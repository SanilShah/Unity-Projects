using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Cut the main stack into 2 pieces.

public class cutStack : MonoBehaviour
{

    public static bool objectStacked = true;
    public static GameObject fallenStack;
    public int currentAxis = 0;
    public static bool stackCollided = false;
    public AudioClip collideSound;
    
    private void OnCollisionEnter(Collision collision)
    {

        stackCollided = true;

        GetComponent<AudioSource>().Play();

        if (StackMovement.myAxis == StackMovement.Axis.Z)
        {
            currentAxis = 0;
        }
        else
        {
            currentAxis = 1;
        }

        if( collision.gameObject.name == "Ground")
        {
            

            Utilities.ClipCube(collision.gameObject, StackMovement.lastStack, currentAxis);
            //StackMovement.lastStack.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            // Transform new stack's scale to fallen stack and reassign its position wrt. fallen stack.
            StackMovement.newStack.transform.localScale = StackMovement.lastStack.transform.localScale;
            if( currentAxis == 0)   // Reassign position in Z-Axis of fallen Stack.
                StackMovement.newStack.transform.position = new Vector3(StackMovement.lastStack.transform.position.x,
                                                                        StackMovement.newStack.transform.position.y,
                                                                        StackMovement.newStack.transform.position.z);
            
            else if ( currentAxis == 1) // Reassign position in X-Acis of fallen Stack.
                StackMovement.newStack.transform.position = new Vector3(StackMovement.newStack.transform.position.x,
                                                                        StackMovement.newStack.transform.position.y,
                                                                        StackMovement.lastStack.transform.position.z);
            //  StackMovement.newStack.SetActive(true);
            //StackMovement.newStack.SetActive(true);

            fallenStack = StackMovement.lastStack;
            objectStacked = true;
            this.name = "FallenStack";    
        }
        if ( collision.gameObject.name == "FallenStack")
        {
            Utilities.ClipCube(collision.gameObject, StackMovement.lastStack, currentAxis);
            //StackMovement.lastStack.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            // Transform new stack's scale to fallen stack and reassign its position wrt. fallen stack.
            StackMovement.newStack.transform.localScale = StackMovement.lastStack.transform.localScale;
            if (currentAxis == 0)   // Reassign position in Z-Axis of fallen Stack.
                StackMovement.newStack.transform.position = new Vector3(StackMovement.lastStack.transform.position.x,
                                                                        StackMovement.newStack.transform.position.y,
                                                                        StackMovement.newStack.transform.position.z);
            else if (currentAxis == 1)  // Reassign position in X-Axis of fallen Stack.
                StackMovement.newStack.transform.position = new Vector3(StackMovement.newStack.transform.position.x,
                                                                        StackMovement.newStack.transform.position.y,
                                                                        StackMovement.lastStack.transform.position.z);
            //  StackMovement.newStack.SetActive(true);

            fallenStack = StackMovement.lastStack;
            objectStacked = true;
            this.name = "FallenStack";
        }

    }
}
