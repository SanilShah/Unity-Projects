using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera position will change wrt. player using lerp ( smooth ) motion.
public class CameraFollow : MonoBehaviour
{
    public Transform target; // Attach Player_ref

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private bool onePanout = false;
    private Vector3 finalPosition;
    private Vector3 smoothPosition;

    void CameraPanOut()
    {
        float lerpSpeed = 0.1f;
        

        if ( onePanout == false)
        {
            finalPosition = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + 10);
            onePanout = true;
        }
        smoothPosition = Vector3.Lerp(transform.position, finalPosition, lerpSpeed);
        transform.position = smoothPosition;

    }


    private void FixedUpdate() // FixedUpdate is the most smooth for this case.
    {
        if ( GameManager.gameHasEnded == false)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            Camera.main.orthographic = false;
            CameraPanOut();
        }
        
    }
}
