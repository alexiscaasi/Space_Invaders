using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
    }

    void FixedUpdate() {
        bullet.position += Vector3.up * -speed;

        if(bullet.position.y <= -6) {
            Destroy(bullet.gameObject);
        }
    }

    void OnTriggerEnter20(Collider2D other) {
        if(other.tag == "Player") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }
        else if(other.tag == "Base") {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth> ();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
}
