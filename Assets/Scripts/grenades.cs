using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenades : MonoBehaviour
{
    private int PipeInventory = 2;
    public GameObject pipe;
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
                Instantiate(pipe, new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + 0.2f, this.transform.position.z), Quaternion.identity);
                PipeInventory--;
            }
        }
    }
}
