using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bileHit : MonoBehaviour
{
    private Transform[] summonPlaces;
    public GameObject zombie;
    private GameObject blurr;
    System.Random random;
    public AudioClip hitClip;
    double coolTime = 4.0f;
    int x;
    bool playerHit = false;
    bool[] spawnAtTime = {false,false,false,false}; 

    public void setSummonPlace(Transform[] places){
        summonPlaces = places;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player"){
            AudioSource audio = collisionInfo.gameObject.GetComponent<AudioSource>();
            audio.PlayOneShot(hitClip);
            playerHit = true;
            random = new System.Random();
            blurr = GameObject.FindGameObjectWithTag("boomerHit");
            blurr.GetComponent<Animator>().SetTrigger("blur");
        }
        if (collisionInfo.gameObject.tag == "Floor" && !playerHit){
            Destroy(this.gameObject);
        }
        
            
    }
    void Update(){
        if(Math.Round(coolTime) == 1 || Math.Round(coolTime) == 2 || Math.Round(coolTime) == 3 || Math.Round(coolTime) == 4){
            int i = (int) Math.Round(coolTime);
            print("Time = "+ coolTime );
            if(!spawnAtTime[i-1]&& playerHit){
                x = random.Next(0,summonPlaces.Length);
                spawn();
                spawnAtTime[i-1] = true;
            }
        }

        if(coolTime<=-1){
            blurr.GetComponent<Animator>().SetTrigger("unBlur");
            Destroy(this.gameObject);
        }
        if(playerHit){
            coolTime-=Time.deltaTime;
        }
    }
    void spawn(){
        GameObject zombie1 = Instantiate(zombie, new Vector3(summonPlaces[x].transform.position.x, 1f, summonPlaces[x].transform.position.z),  Quaternion.Euler(-90, 0, 0));
        zombie1.gameObject.GetComponent<ZombieController>().setSeen();

        GameObject zombie2 = Instantiate(zombie, new Vector3(summonPlaces[x].transform.position.x+2f, 1f, summonPlaces[x].transform.position.z),  Quaternion.Euler(-90, 0, 0));
        zombie2.gameObject.GetComponent<ZombieController>().setSeen();

        GameObject zombie3 = Instantiate(zombie, new Vector3(summonPlaces[x].transform.position.x, 1f, summonPlaces[x].transform.position.z+2f),  Quaternion.Euler(-90, 0, 0));
        zombie3.gameObject.GetComponent<ZombieController>().setSeen();

        GameObject zombie4 = Instantiate(zombie, new Vector3(summonPlaces[x].transform.position.x+2f, 1f, summonPlaces[x].transform.position.z+2f),  Quaternion.Euler(-90, 0, 0));
        zombie4.gameObject.GetComponent<ZombieController>().setSeen();
                    
                    
    }
   
}
