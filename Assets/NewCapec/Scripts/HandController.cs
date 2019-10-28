using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using VRTK;



public class HandController : MonoBehaviour {

    public Transform camTr;
    public VRTK_Pointer pointer;
    public GameObject pointGo;
    public PostProcessVolume postProcessVolume;
    private FloatParameter foucesDistance;
	// Use this for initialization
	void Start () {
        pointer.DestinationMarkerEnter += OnDestinationMarkerEnter;
        pointer.DestinationMarkerExit += OnDestinationMarkerExit;
        pointer.DestinationMarkerHover += OnDestinationMarkerHover;
        pointer.SelectionButtonPressed += OnSelectionButtonPressed;
        foucesDistance = postProcessVolume.profile.GetSetting<DepthOfField>().focusDistance;
        foucesDistance.value = 3f;
    }

    private void OnSelectionButtonPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (pointGo != null)
        {
            TKPointerClick tK = pointGo.GetComponent<TKPointerClick>();
            if (tK != null)
            {
                tK.OnTKPointerClick();
            }
        }
    }

    private void OnDestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {

        TKPointerEnter tK = e.target.GetComponent<TKPointerEnter>();
        if (tK != null)
        {
            foucesDistance.value = Mathf.Clamp(Vector3.Distance(camTr.position, e.raycastHit.point)+0.5f, 0, 3f);
            tK.OnTKPointerEnter(e);
        }
    }

    private void OnDestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
        pointGo = null;
        foucesDistance.value = 3f;
        TKPointerExit tK = e.target.GetComponent<TKPointerExit>();
        if (tK != null)
        {
            tK.OnTKPointerExit(e);
        }
    }

    private void OnDestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {

        pointGo = e.target.gameObject;
        TKPointerEnter tK= e.target.GetComponent<TKPointerEnter>();
        if (tK != null)
        {
            foucesDistance.value = Mathf.Clamp(Vector3.Distance(camTr.position, e.raycastHit.point)+0.5f, 0, 2.8f);
        }
    }

    
}
public interface TKPointerEnter
{
     void OnTKPointerEnter(DestinationMarkerEventArgs e);
}
public interface TKPointerExit
{
    void OnTKPointerExit(DestinationMarkerEventArgs e);
}
public interface TKPointerClick
{
    void OnTKPointerClick();
}
