using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeBombBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;
    private float thrust = 15.0f;
    private float time = 4f;
    public GameObject explosion;
    private List<GameObject> targets = new List<GameObject>();
    private List<GameObject> spitters = new List<GameObject>();
    private List<GameObject> chargers = new List<GameObject>();
    private List<GameObject> tanks = new List<GameObject>();
    private List<GameObject> boomers = new List<GameObject>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rb.AddForce(cam.transform.forward * thrust, ForceMode.Impulse);
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("target");
        for(int i = 0; i < allTargets.Length; i++)
        {
            if (Vector3.Distance(allTargets[i].transform.position, transform.position) < 50f)
                targets.Add(allTargets[i]);
        }
        GameObject[] allSpitters = GameObject.FindGameObjectsWithTag("spitter");
        for (int i = 0; i < allSpitters.Length; i++)
        {
            if (Vector3.Distance(allSpitters[i].transform.position, transform.position) < 50f)
                spitters.Add(allSpitters[i]);
        }
        GameObject[] allChargers = GameObject.FindGameObjectsWithTag("charger");
        for (int i = 0; i < allChargers.Length; i++)
        {
            if (Vector3.Distance(allChargers[i].transform.position, transform.position) < 50f)
                chargers.Add(allChargers[i]);
        }
        GameObject[] allTanks = GameObject.FindGameObjectsWithTag("Tank");
        for (int i = 0; i < allTanks.Length; i++)
        {
            if (Vector3.Distance(allTanks[i].transform.position, transform.position) < 50f)
                tanks.Add(allTanks[i]);
        }
        GameObject[] allBoomers = GameObject.FindGameObjectsWithTag("boomer");
        for (int i = 0; i < allBoomers.Length; i++)
        {
            if (Vector3.Distance(allBoomers[i].transform.position, transform.position) < 50f)
                boomers.Add(allBoomers[i]);
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].GetComponent<ZombieController>().distract(this.gameObject);
        }
        for (int i = 0; i < spitters.Count; i++)
        {
            spitters[i].GetComponent<spitterController>().distract(this.gameObject);
        }
        for (int i = 0; i < chargers.Count; i++)
        {
            chargers[i].GetComponent<ChargerControlScript>().distract(this.gameObject);
        }
        for (int i = 0; i < tanks.Count; i++)
        {
            tanks[i].GetComponent<TankController>().distract(this.gameObject);
        }
        for (int i = 0; i < boomers.Count; i++)
        {
            boomers[i].GetComponent<boomerController>().distract(this.gameObject);
        }
        if (time <= 0f)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].GetComponent<ZombieController>().unDistract();
            }
            for (int i = 0; i < spitters.Count; i++)
            {
                spitters[i].GetComponent<spitterController>().unDistract();
            }
            for (int i = 0; i < chargers.Count; i++)
            {
                chargers[i].GetComponent<ChargerControlScript>().unDistract();
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].GetComponent<TankController>().unDistract();
            }
            for (int i = 0; i < boomers.Count; i++)
            {
                boomers[i].GetComponent<boomerController>().unDistract();
            }
            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);
            GameObject effect = Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), spawnRotation);
            effect.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
        }
    }
}
