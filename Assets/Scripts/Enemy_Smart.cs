using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Smart : MonoBehaviour
{
  public GameObject self;
  public GameObject gameController;

  public float moveSpeed = 1F;
  public int moveDirectionTime = 2;
  public float moveTimeStamp;

  public GameObject bullet;

  public int somethingTouchedMe = 0;

  public int gettingTiredTimeCooldown = 4;
  public float gettingTiredTime = 0;

  public float bulletForward = 0.0F;

  public Vector3 bulletTransform = Vector3.zero;

  Vector3 moveDirection = Vector3.zero;
  private void Start()
  {
    // add one to the enemies left counter when the enemy is made
    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();

    controllerScript.enemiesLeft += 1;

  }

  private void OnCollisionEnter(Collision collision)
  {
    // if the collision tag is bullet destroy the enemy and remove one from the enemiesLeft count

    GameControllerScript controllerScript = gameController.GetComponent<GameControllerScript>();

    if (collision.collider.tag == "Bullet")
    {
      controllerScript.enemiesLeft -= 1;
      Destroy(self, 0.0F);

      transform.rotation = Quaternion.Euler(collision.transform.rotation.x, -collision.transform.rotation.y, collision.transform.rotation.x);

      // get the distance of the bullet to the enemey
      // next frame get the bullet to the enemey again then see if moving left made the distance shorter or longer
      // if it was longer keep moving the same way and if it was shorter continue the same way
     
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Bullet")
    {
      somethingTouchedMe += 1;
      gettingTiredTime = Time.time + gettingTiredTimeCooldown;

    }

  } // end OnTriggerEnter

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Bullet")
    {
      somethingTouchedMe -= 1;

    }
  }

  private void Update()
  {
    // when a object enters the collider rotate the enemey to look at the object
    ;



  } // end update
}
