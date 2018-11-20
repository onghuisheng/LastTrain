﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : GrabbableObject
{
    // TODO Particle collision event handling for extinguishing fires?

    PlayerViveController m_CurrentController;

    public ParticleSystem foamVisualParticles, foamTriggerParticles;

    bool held;

    private void Start()
    {
        foamVisualParticles.Stop();
        foamTriggerParticles.Stop();
    }

    public override bool hideControllerOnGrab { get { return true; } }

    public override void OnControllerEnter(PlayerViveController currentController)
    {
        base.OnControllerEnter(currentController);
        m_CurrentController = currentController;
    }

    public override void OnControllerExit()
    {
        base.OnControllerExit();
        held = false;
        foamVisualParticles.Stop();
    }

    public override void OnGrab()
    {
        base.OnGrab();
        held = true;
    }

    public override void OnGrabReleased()
    {
        base.OnGrabReleased();
        held = false;
        foamVisualParticles.Stop();
    }

    public override void OnUse()
    {
        if (held)
        {
            if (foamVisualParticles.isPlaying)
            {
                foamVisualParticles.Stop();
            }
            else
            {
                foamVisualParticles.Play();
            }
        }
    }
}
