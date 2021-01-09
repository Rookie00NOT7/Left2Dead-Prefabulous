using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunEffect : MonoBehaviour
{
    private List<GameObject> chasingZombies = new List<GameObject>();
    private List<GameObject> chasingSpitters = new List<GameObject>();
    private List<GameObject> chasingChargers = new List<GameObject>();
    private List<GameObject> chasingTanks = new List<GameObject>();
    private List<GameObject> chasingBoomers = new List<GameObject>();
    private float delayToDistract;
    private float delayToUndistract;
    void Start()
    {
        delayToUndistract = 3f;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "target"){
            chasingZombies.Add(other.gameObject);
        }
        if(other.tag == "spitter"){
            chasingSpitters.Add(other.gameObject);
        }
        if(other.tag == "charger"){
            chasingChargers.Add(other.gameObject);
        }
        if(other.tag == "Tank"){
            chasingTanks.Add(other.gameObject);
        }
        if(other.tag == "boomer"){
            chasingBoomers.Add(other.gameObject);
        }
    }

    void Update()
    {
        delayToUndistract-= Time.deltaTime;

        foreach(GameObject chaserZombie in chasingZombies){
            chaserZombie.GetComponent<ZombieController>().distract(chaserZombie);
        }
        foreach(GameObject chaserSpitter in chasingSpitters){
            chaserSpitter.GetComponent<spitterController>().distract(chaserSpitter);
        }
        foreach(GameObject chaserCharger in chasingChargers){
            chaserCharger.gameObject.GetComponent<ChargerControlScript>().distract(chaserCharger);
        }
        foreach(GameObject chaserTank in chasingTanks){
            chaserTank.gameObject.GetComponent<TankController>().distract(chaserTank);
        }
        foreach(GameObject chaserBoomer in chasingBoomers){
            chaserBoomer.GetComponent<boomerController>().distract(chaserBoomer);
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        if(delayToUndistract <= 0f){
            foreach(GameObject chaserZombie in chasingZombies){
                chaserZombie.GetComponent<ZombieController>().unDistract();
            }
            foreach(GameObject chaserSpitter in chasingSpitters){
                chaserSpitter.GetComponent<spitterController>().unDistract();
            }
            foreach(GameObject chaserCharger in chasingChargers){
                chaserCharger.gameObject.GetComponent<ChargerControlScript>().unDistract();
            }
            foreach(GameObject chaserTank in chasingTanks){
                chaserTank.gameObject.GetComponent<TankController>().unDistract();
            }
            foreach(GameObject chaserBoomer in chasingBoomers){
                chaserBoomer.GetComponent<boomerController>().unDistract();
            }
            Destroy(this.gameObject);
        }
        
    }
}
