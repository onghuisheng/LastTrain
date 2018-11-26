﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCallManager : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;

            FindObjectOfType<Checkpoint>().CheckpointActivated();

            FindObjectOfType<TrainArriver>().CallTheTrain();

            AnnouncementManager.Instance.PlayAnnouncement3D("announcement_chime", transform.position + new Vector3(0f, 4f, 0f), AnnouncementManager.AnnounceType.Queue, 0f);
            AnnouncementManager.Instance.PlayAnnouncement3D("platform_entry", transform.position + new Vector3(0f, 4f, 0f), AnnouncementManager.AnnounceType.Queue, 0f);
        }
    }
}
