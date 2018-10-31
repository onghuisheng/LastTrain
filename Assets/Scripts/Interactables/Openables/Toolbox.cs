﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : GrabbableObject
{
    public GameObject[] containedObjectsArray;
    public GameObject sawBladeVisual;

    AudioPlayer openAudio;
    Animator toolboxAnimator;
    bool opened;

    void Start()
    {
        toolboxAnimator = GetComponent<Animator>();
        openAudio = GetComponent<AudioPlayer>();
    }
    
    // Re-arrange colliders on the main object body for Grab rigidbody to reflect the new model state.
    private void ReArrangeColliders()
    {
        BoxCollider oldBC = GetComponent<BoxCollider>();

        BoxCollider newBC = gameObject.AddComponent<BoxCollider>();

        newBC.center = new Vector3(0, 0.12f, -0.06f);
        newBC.size = new Vector3(0.22f, 0.15f, 0.015f);

        newBC = gameObject.AddComponent<BoxCollider>();

        newBC.center = new Vector3(0, 0.025f, 0.003f);
        newBC.size = new Vector3(0.22f, 0.04f, 0.125f);

        Destroy(oldBC);
    }

    public void OpenToolbox()
    {
        toolboxAnimator.Play("toolbox_open");
        openAudio.Play();

        ReArrangeColliders();

        StartCoroutine(ObjectActivateDelay());
    }

    IEnumerator ObjectActivateDelay()
    {
        yield return new WaitForSeconds(1.2f);

        sawBladeVisual.SetActive(false);

        foreach (GameObject go in containedObjectsArray)
        {
            go.SetActive(true);
            go.transform.SetParent(null);
        }
    }

    public override bool hideControllerOnGrab { get { return true; } }

    public override void OnControllerEnter(PlayerViveController currentController)
    {
    }

    public override void OnControllerExit()
    {
    }

    public override void OnControllerStay()
    {
    }

    public override void OnGrab()
    {
    }

    public override void OnGrabReleased()
    {
    }

    public override void OnUse()
    {
        if (!opened)
        {
            OpenToolbox();
            opened = true;
        }
    }

    public override void OnUseDown()
    {
    }

    public override void OnUseUp()
    {
    }

}
