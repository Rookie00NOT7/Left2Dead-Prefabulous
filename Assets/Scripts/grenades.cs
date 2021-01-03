using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenades : MonoBehaviour
{
    private int PipeInventory = 2;
    private int MolInventory = 3;
    public GameObject pipe;
    public GameObject molotov;
    private int selected = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            selected = (selected + 1) % 3;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (selected == 0 && PipeInventory > 0)
            {
                Instantiate(pipe, new Vector3(this.transform.position.x , this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
                PipeInventory--;
            }
            if(selected == 1 && MolInventory > 0)
            {
                Instantiate(molotov, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
                MolInventory--;
            }
        }
    }
}
