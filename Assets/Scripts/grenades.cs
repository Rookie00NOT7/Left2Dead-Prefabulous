using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenades : MonoBehaviour
{
    private int PipeInventory = 0;
    private int MolInventory=0 ;
    private int StunInventory=0 ;
    public GameObject pipe;
    public GameObject molotov;
    public GameObject stun;
    private int selected = 0;

    public int GetEquippedNade() {
        return selected;
    }

    public void addMol(int quantity)
    {
        MolInventory += quantity;
        MolInventory = Mathf.Clamp(MolInventory, 0, 3);
    }

    public void addPipe(int quantity)
    {
        PipeInventory += quantity;
        PipeInventory = Mathf.Clamp(PipeInventory, 0, 2);
    }

    public void addStun(int quantity)
    {
        StunInventory += quantity;
        StunInventory = Mathf.Clamp(StunInventory, 0, 2);
    }

    public int getPipeInv()
    {
        return PipeInventory;
    }

    public int getMolInv()
    {
        return MolInventory;
    }

    public int getStunInv()
    {
        return StunInventory;
    }

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
                Debug.Log(MolInventory);
            }
           if (selected == 2 && StunInventory > 0)
           {
               Instantiate(stun, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
               StunInventory--;
          }
        }
    }
}
