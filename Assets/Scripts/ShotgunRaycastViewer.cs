using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunRaycastViewer : MonoBehaviour
{
   private float shotgunRange;
   private Camera fpsCam;

   private void Start() {
       shotgunRange = GetComponent<ShotgunBehaviour>().weaponRange;
       fpsCam = Camera.main;
   }

   private void Update() {
       Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

       Vector3[] pelletAngles = new Vector3[10];
       pelletAngles[0] = new Vector3(0.0f, 0.0f, 0.0f); // Forward
       pelletAngles[1] = new Vector3(-0.2f, 0.0f, 0.0f); // Left
       pelletAngles[2] = new Vector3(0.2f, 0.0f, 0.0f); // Right
       pelletAngles[3] = new Vector3(0.0f, 0.2f, 0.0f); // Up
       pelletAngles[4] = new Vector3(0.0f, -0.2f, 0.0f); // Down
       pelletAngles[5] = new Vector3(-0.2f, 0.2f, 0.0f); // Up-Left
       pelletAngles[6] = new Vector3(0.2f, 0.2f, 0.0f); // Up-Right
       pelletAngles[7] = new Vector3(-0.2f, -0.2f, 0.0f); // Down-Left
       pelletAngles[8] = new Vector3(0.2f, -0.2f, 0.0f); // Down-Right
       pelletAngles[9] = new Vector3(0.0f, 0.1f, 0.0f); // Slighter Up

       for (int i = 0; i < 10; i++)
       {
           Debug.DrawRay(rayOrigin, (fpsCam.transform.forward + pelletAngles[i]) * shotgunRange, Color.green);
       }
   }
}
