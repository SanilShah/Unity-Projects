using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject Visual;

    void Start()
    {
        // Get The Components
        rayManager = FindObjectOfType<ARRaycastManager>();
        Visual = transform.GetChild(0).gameObject;

        // Hide the placement visual
        Visual.SetActive(false);
    }

    void Update()
    {
        // Shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // If we hit an AR plane, update the position and rotation
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!Visual.activeInHierarchy)
                Visual.SetActive(true);
        }
    }
}
