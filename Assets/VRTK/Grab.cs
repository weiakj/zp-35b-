using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Grab : MonoBehaviour {

    VRTK_InteractGrab interactGrab;
    VRTK_Pointer vRTK_Pointer;
    // Use this for initialization
    void Start () {
        interactGrab = GetComponent<VRTK_InteractGrab>();
        vRTK_Pointer = GetComponent<VRTK_Pointer>();
        interactGrab.GrabButtonPressed += GrabButtonReleased;
        interactGrab.ControllerStartGrabInteractableObject += ControllerStartGrabInteractableObject;
    }
    private void OnDestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {
        Debug.Log("MarkerHover");
    }
    private void ControllerStartGrabInteractableObject(object sender, ObjectInteractEventArgs e)
    {
        Debug.Log("GrabThings");
    }
    private void GrabButtonReleased(object o, ControllerInteractionEventArgs e)
    {
        Debug.Log("GrabPress");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
