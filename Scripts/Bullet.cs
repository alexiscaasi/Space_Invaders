using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  private Transform bullet;
  public float speed;

  // Use this for initialization
  void Start() {
    bullet = GetComponent<Transform> ();
  }

  void FixedUpdate() {
    bullet.position += Vector3.up * speed;

    if(bullet.position.y >= 6) {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    // if(other.tag == "Enemy") {
    //   Destroy(other.gameObject);
    //   Destroy(gameObject);
    //   Score.playerScore += 10;
    // }
    if(other.tag == "FirstEnemy") {
      Destroy(other.gameObject);
      Destroy(gameObject);
      Score.playerScore += 10;
    }
    if(other.tag == "SecondEnemy") {
      Destroy(other.gameObject);
      Destroy(gameObject);
      Score.playerScore += 20;
    }
    if(other.tag == "ThirdEnemy") {
      Destroy(other.gameObject);
      Destroy(gameObject);
      Score.playerScore += 30;
    }
    if(other.tag == "FourthEnemy") {
      Destroy(other.gameObject);
      Destroy(gameObject);
      Score.playerScore += 40;
    }
    else if(other.tag == "Base") {
      Destroy(gameObject);
    }
  }
}
