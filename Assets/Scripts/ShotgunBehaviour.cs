using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : MonoBehaviour
{
  [Header("Shotgun settings")]
  [Range(1, 5)]
  public int pelletCount = 5;
  [Range(5, 100f)]
  public int gunDamage = 5;
  public float fireRate = 1.0f; // Same length as shooting animation
  public float weaponRange = 50.0f;
  [Range(1, 8)]
  public int standardShellCount = 8;

  [Header("Shotgun sound clips")]  
  public AudioClip shotSound;
  public AudioClip shellLoadingSound;
  public AudioClip pumpSound;

  [Header("Muzzle Settings")]
  public Transform muzzleEnd;
  public GameObject muzzleFlash;
  private Camera fpsCam;
  private AudioSource gunAudio;
  private Animator animation;
  private int currentShellCount;

  private Vector3[] pelletAngles = new Vector3[5];

  private WaitForSeconds shotDuration = new WaitForSeconds(1f);
  private float nextFire;
  private PlayerAddedBehavior player;

  private void Start() {
      fpsCam = Camera.main;
      gunAudio = GetComponent<AudioSource>();
      animation = GetComponent<Animator>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAddedBehavior>();

      currentShellCount = standardShellCount;

      pelletAngles[0] = new Vector3(0.0f, 0.0f, 0.0f); // Forward
      pelletAngles[1] = new Vector3(-0.2f, 0.0f, 0.0f); // Left
      pelletAngles[2] = new Vector3(0.2f, 0.0f, 0.0f); // Right
      pelletAngles[3] = new Vector3(0.0f, 0.2f, 0.0f); // Up
      pelletAngles[4] = new Vector3(0.0f, -0.2f, 0.0f); // Down
  }

  public void Update() {
      if (Input.GetButtonDown("Fire1") && Time.time > nextFire && currentShellCount > 0) {
          --currentShellCount;
          nextFire = Time.time + fireRate;
          StartCoroutine(ShotEffect());

          Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

          RaycastHit[] hits = new RaycastHit[5];

          bool rage = player.getRageMode();

          for (int i = 0; i < 5; ++i) {
              if (Physics.Raycast(rayOrigin, fpsCam.transform.forward + pelletAngles[i], out hits[i], weaponRange)) {
                  string tag = hits[i].transform.tag;

                  bool kill = false;

                  switch (tag) {
                      case "target":
                        kill = hits[i].collider.gameObject.GetComponent<ZombieController>().takeDamage(gunDamage * (rage ? 2 : 1));
                        break;
                      case "spitter":
                        kill = hits[i].collider.gameObject.GetComponent<spitterController>().takeDamage(gunDamage * (rage ? 2 : 1));
                        break;
                      default:
                        break;
                  }

                  if (kill) {
                      player.killPlus();
                      player.rage(tag);
                  }
              }
          }

      } else if (Input.GetKeyDown(KeyCode.R) && currentShellCount < 8) {
          currentShellCount = 8;
          StartCoroutine(ReloadEffect());
      }
  }

  public IEnumerator ShotEffect() {
      gunAudio.PlayOneShot(shotSound);
      Instantiate(muzzleFlash, muzzleEnd.position, muzzleEnd.rotation).GetComponent<ParticleSystem>().Play();
      animation.SetTrigger("Shoot");

      yield return shotDuration;
  }

  public IEnumerator ReloadEffect() {
          animation.SetTrigger("Reload");
          gunAudio.PlayOneShot(shellLoadingSound);
          yield return shotDuration;
          gunAudio.PlayOneShot(pumpSound);
          animation.SetTrigger("ShotgunUp");

  }
}
