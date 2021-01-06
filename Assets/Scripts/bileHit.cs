using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bileHit : MonoBehaviour
{
    public GameObject summonPlace1;
    public GameObject summonPlace2;
    public GameObject zombie;
    public Image blurr;
    private Animator anim;
    System.Random random;
    int x;
    bool[] spawnAtTime = {false,false,false,false}; 

    void OnCollisionEnter(Collision collisionInfo)
    {
        
        // zombie.gameObject.GetComponent<Animator>().SetTrigger("playerSeen");
        if (collisionInfo.gameObject.tag == "Player"){
            double coolTime = 4.0f;
            // blurr = GameObject.Find("boomerHitEffect").GetComponent<Image>();
            blurr.gameObject.SetActive(true);
            anim = blurr.gameObject.GetComponent<Animator>();
            anim.SetTrigger("blur");
            random = new System.Random();
            while(coolTime>0){
                if(Math.Round(coolTime) == 1 || Math.Round(coolTime) == 2 || Math.Round(coolTime) == 3 || Math.Round(coolTime) == 4){
                    int i = (int) Math.Round(coolTime);
                    if(!spawnAtTime[i-1]){
                        x = random.Next(1,3);
                        spawn();
                    }
                    spawnAtTime[i-1] = true;
                }
                coolTime-=Time.deltaTime;
            }
           
            if(coolTime<=0.0)
                blurr.gameObject.SetActive(false);
            // anim.SetTrigger("unBlur");
            
           
            Destroy(this.gameObject);
        }
    }
void spawn(){
     if(x == 1){
                    GameObject zombie1 = Instantiate(zombie, new Vector3(summonPlace1.transform.position.x, 1f, summonPlace1.transform.position.z),  Quaternion.Euler(-90, 0, 0));
                    zombie1.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie1.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie1.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie1.gameObject.GetComponent<ZombieController>().setSeen();

                    GameObject zombie2 = Instantiate(zombie, new Vector3(summonPlace1.transform.position.x+2f, 1f, summonPlace1.transform.position.z),  Quaternion.Euler(-90, 0, 0));
                    zombie2.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie2.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie2.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie2.gameObject.GetComponent<ZombieController>().setSeen();

                    GameObject zombie3 = Instantiate(zombie, new Vector3(summonPlace1.transform.position.x, 1f, summonPlace1.transform.position.z+2f),  Quaternion.Euler(-90, 0, 0));
                    zombie3.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie3.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie3.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie3.gameObject.GetComponent<ZombieController>().setSeen();

                    GameObject zombie4 = Instantiate(zombie, new Vector3(summonPlace1.transform.position.x+2f, 1f, summonPlace1.transform.position.z+2f),  Quaternion.Euler(-90, 0, 0));
                    zombie4.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie4.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie4.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie4.gameObject.GetComponent<ZombieController>().setSeen();
                }
                if(x == 2 ){
                    GameObject zombie1 = Instantiate(zombie, new Vector3(summonPlace2.transform.position.x, 1f, summonPlace2.transform.position.z),  Quaternion.Euler(-90, 0, 0));
                    zombie1.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie1.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie1.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie1.gameObject.GetComponent<ZombieController>().setSeen();

                    GameObject zombie2 = Instantiate(zombie, new Vector3(summonPlace2.transform.position.x+2f, 1f, summonPlace2.transform.position.z),  Quaternion.Euler(-90, 0, 0));
                    zombie2.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie2.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie2.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie2.gameObject.GetComponent<ZombieController>().setSeen();

                    GameObject zombie3 = Instantiate(zombie, new Vector3(summonPlace2.transform.position.x, 1f, summonPlace2.transform.position.z+2f),  Quaternion.Euler(-90, 0, 0));
                    zombie3.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie3.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie3.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie3.gameObject.GetComponent<ZombieController>().setSeen();

                    GameObject zombie4 = Instantiate(zombie, new Vector3(summonPlace2.transform.position.x+2f, 1f, summonPlace2.transform.position.z+2f),  Quaternion.Euler(-90, 0, 0));
                    zombie4.gameObject.GetComponent<ZombieController>().setAnim(zombie.gameObject.GetComponent<Animator>());
                    zombie4.gameObject.GetComponent<ZombieController>().setAgent(zombie.gameObject.GetComponent<NavMeshAgent>());
                    zombie4.gameObject.GetComponent<ZombieController>().setAudio(zombie.gameObject.GetComponent<AudioSource>());
                    zombie4.gameObject.GetComponent<ZombieController>().setSeen();
                }
}
   
}
