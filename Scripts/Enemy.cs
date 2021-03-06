using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

  private Transform enemyHolder;
  public float speed;

  public GameObject shot;
  public Text winText;
  public float fireRate = 0.99f;

  // Use this for initialization
  void Start() {
    InvokeRepeating("MoveEnemy", 0.25f, 0.45f);
    enemyHolder = GetComponent<Transform> ();
  }

  void MoveEnemy() {
    enemyHolder.position += Vector3.right * speed;

    foreach(Transform enemy in enemyHolder) {
      if(enemy.position.x < -6.5 || enemy.position.x > 6.5) {
        speed = -speed;
        enemyHolder.position += Vector3.down * 0.5f; 
        return;
      }

      if(Random.value > fireRate) {
        Instantiate(shot, enemy.position, enemy.rotation);
      }

      if(enemy.position.y <= -4) {
        GameOver.isPlayerDead = true;
        Time.timeScale = 0;
      }
      if(enemyHolder.childCount == 1) {
        CancelInvoke();
        InvokeRepeating("MoveEnemy", 0.1f, 0.25f); // enemies move faster
      }
    } 
  }
}
