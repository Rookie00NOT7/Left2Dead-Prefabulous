using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : MonoBehaviour
{
  [Header("Shotgun settings")]
  [Range(1, 10)]
  public int pelletCount = 10;
  [Range(5, 100f)]
  public int gunDamage = 25;
  public float fireRate = 0.3f;
  public float weaponRange = 50.0f;
  [Range(1, 15)]
  public int standardShellCount = 10;
  [Range(1, 500)]
  public int standardReserveAmmo = 130;

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
  private int currentReserveAmmo;
  private Vector3[] pelletAngles;
  private WaitForSeconds shotDuration = new WaitForSeconds(0.3f);
  private WaitForSeconds reloadDuration = new WaitForSeconds(1.0f);
  private float nextFire;
  private PlayerAddedBehavior player;

  private void Start() {
      fpsCam = Camera.main;
      gunAudio = GetComponent<AudioSource>();
      animation = GetComponent<Animator>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAddedBehavior>();

      currentShellCount = standardShellCount;
      currentReserveAmmo = standardReserveAmmo;

      pelletAngles = new Vector3[pelletCount];
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
  }

  public void Update() {
      if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire && currentShellCount > 0) {
          --currentShellCount;
          nextFire = Time.time + fireRate;
          StartCoroutine(ShotEffect());

          Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

          RaycastHit[] hits = new RaycastHit[pelletCount];

          bool rage = player.getRageMode();

          for (int i = 0; i < pelletCount; ++i) {
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
                      case "Tank":
                        kill = hits[i].collider.gameObject.GetComponent<TankController>().takeDamage(gunDamage * (rage ? 2 : 1));
                        break;
                      case "charger":
                        kill = hits[i].collider.gameObject.GetComponent<ChargerControlScript>().takeDamage(gunDamage * (rage ? 2 : 1));
                        break;
                      case "boomer":
                        kill = hits[i].collider.gameObject.GetComponent<boomerController>().takeDamage(gunDamage * (rage ? 2 : 1))  ;
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

      } else if (Input.GetKeyDown(KeyCode.R) && currentShellCount < standardShellCount && currentReserveAmmo > 0) {
          int ammoNeeded = standardShellCount - currentShellCount;

          if (ammoNeeded > currentReserveAmmo) {
            currentShellCount += currentReserveAmmo;
            currentReserveAmmo = 0;
          } else {
            currentShellCount = standardShellCount;
            currentReserveAmmo -= (ammoNeeded);
          }

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
          yield return reloadDuration;
          gunAudio.PlayOneShot(pumpSound);
          animation.SetTrigger("ShotgunUp");

  }

  public int GetCurrentShellCount() {
    return currentShellCount;
  }

  public int GetCurrentReserveAmmo() {
    return currentReserveAmmo;
  }
}
