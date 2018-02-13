using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColiderDetection : MonoBehaviour
{
  public GameObject self;

  public bool bulletCollided = false;

  private void Start()
  {
    Destroy(self, 10.0F);

  }
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.tag != "Player")
    {
      if (collision.collider.tag != "Bullet")
      {
        bulletCollided = true;
        Destroy(self, 0.0F);

      }

    }
  }
}
