using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    // rigidbody of player
    private Rigidbody rb;
    // speed of player
    public float speed = 10;
    // jump amount of player 
    public float jump = 10;
    // hole 1 spawn
    private Vector3 hole1s;
    // hole 2 spawn
    private Vector3 hole2s;
    // hole 3 spawn 
    private Vector3 hole3s;
    // hole 3 exit 1
    private Vector3 hole3tps1;
    // hole 3 exit 2
    private Vector3 hole3tps2;
    // hole 3 exit 3
    private Vector3 hole3tps3;
    // hole 3 exit 4
    private Vector3 hole3tps4;
    // hole 4 spawn 
    private Vector3 hole4s;
    // cage wall 1 on hole 4
    private GameObject cageH4W1;
    // cage wall 2 on hole 4
    private GameObject cageH4W2;
    // cage wall 3 on hole 4
    private GameObject cageH4W3;
    // cage wall 4 on hole 4
    private GameObject cageH4W4;
    // hole 4 death spawn
    private Vector3 hole4ds;
    // hole 5 spawn 
    private Vector3 hole5s;
    // hole 6 spawn
    private Vector3 hole6s;
    // hole 7 spawn
    private Vector3 hole7s;
    // hole 8 spawn
    private Vector3 hole8s;
    // hole 8 level 2 spawn
    private Vector3 hole8l2;
    // hole 8 level 3 spawn
    private Vector3 hole8l3;
    // hole 9 spawn
    private Vector3 hole9s;
    // pickup explosion sound
    private AudioSource pickupS;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hole1s = new Vector3(43, 4, 8);
        hole2s = new Vector3(198, 2, -3);
        hole3s = new Vector3(191, 33, 92);
        hole3tps1 = new Vector3(175, 12, 98);
        hole3tps2 = new Vector3(181, 12, 92);
        hole3tps3 = new Vector3(175, 12, 86);
        hole3tps4 = new Vector3(170, 12, 92);
        hole4s = new Vector3(85, 33, 129);
        hole4ds = new Vector3(85, 3, 129);
        cageH4W1 = GameObject.FindWithTag("CageH4W1");
        cageH4W2 = GameObject.FindWithTag("CageH4W2");
        cageH4W3 = GameObject.FindWithTag("CageH4W3");
        cageH4W4 = GameObject.FindWithTag("CageH4W4");
        hole5s = new Vector3(31, 2, 120);
        hole6s = new Vector3(73, 17, 179);
        hole7s = new Vector3(206, 3, 169);
        hole8s = new Vector3(302, 5, 64);
        hole8l2 = new Vector3(275, 5, 85);
        hole8l3 = new Vector3(250, 5, 85);
        hole9s = new Vector3(297, 3, 168);
        pickupS = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // apply forces to rigidbody from inputs
        float moveHorizontal = Input.GetAxis("Vertical");
        float moveVertical = Input.GetAxis("Horizontal");
        moveHorizontal = -moveHorizontal;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void LateUpdate(){

        if(Input.GetKey(KeyCode.Space)) {
            transform.position += transform.up * jump * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.R)) {
            GameController.lives = 5;
            GameController.score = 0;
            transform.position = hole1s;
        }
    }

    void OnTriggerEnter(Collider other) {
        // pickup collision 
        if(other.gameObject.tag == "Pickup") {
            Destroy(other.gameObject);
            GameController.score += 100;
            pickupS.Play();
        }
        // hole 1 collision
        if(other.gameObject.tag == "Hole1") {
            transform.position = hole2s;
            GameController.score += 100;
        }
        // hole 2 collision
        if(other.gameObject.tag == "Hole2") {
            transform.position = hole3s;
            GameController.score += 100;
        }
        // hole 2 secret collision
        if(other.gameObject.tag == "Hole2secret") {
            transform.position = hole3s;
            GameController.score += 150;
        }
        // hole 3 collision
        if(other.gameObject.tag == "Hole3") {
            transform.position = hole4s;
            GameController.score += 100;
            Destroy(cageH4W1);
            Destroy(cageH4W2);
            Destroy(cageH4W3);
            Destroy(cageH4W4);
        }
        // hole 3 teleport with random exit 
        if(other.gameObject.tag == "Hole3tp") {
            double val = Random.value;
            if (val < .25) {
                transform.position = hole3tps1;
            }
            else if (val < .50) {
                transform.position = hole3tps2;
            }
            else if (val < .75) {
                transform.position = hole3tps3;
            }
            else {
                transform.position = hole3tps4;
            }
        }
        // hole 4 collision
        if(other.gameObject.tag == "Hole4") {
            transform.position = hole5s;
            GameController.score += 100;
        }
        // hole 4 death collision
        if(other.gameObject.tag == "DeathH4") {
            transform.position = hole4ds;
            GameController.lives -= 1;
        }
        // hole 4 enemy collision
        if(other.gameObject.tag == "EnemyH4") {
            transform.position = hole4s;
            GameController.lives -= 1;
        }
        // hole 5 collision
        if(other.gameObject.tag == "Hole5") {
            transform.position = hole6s;
            GameController.score += 100;
        }
        // hole 5 death collision
        if(other.gameObject.tag == "DeathH5") {
            transform.position = hole5s;
            GameController.lives -= 1;
        }
        // hole 6 collision
        if(other.gameObject.tag == "Hole6") {
            transform.position = hole7s;
            GameController.score += 100;
        }
        // hole 6 death collision
        if(other.gameObject.tag == "DeathH6") {
            transform.position = hole6s;
            GameController.lives -= 1;
        }
        // hole 7 collision
        if(other.gameObject.tag == "Hole7") {
            transform.position = hole8s;
            GameController.score += 100;
        }
        // hole 7 death collision
        if(other.gameObject.tag == "DeathH7") {
            transform.position =  hole7s;
            GameController.lives -= 1;
        }
        // hole 8 cheat teleport collision 
        if(other.gameObject.tag == "Hole8c") {
            transform.position = hole8l3;
        }
        // hole 8 fake teleport 1 collision 
        if(other.gameObject.tag == "Hole8ftp1") {
            transform.position = hole8s;
        }
        // hole 8 fake teleport 2 collision
        if(other.gameObject.tag == "Hole8ftp2") {
            transform.position = hole8l2;
        }
        // hole 8 collision
        if(other.gameObject.tag == "Hole8") {
            transform.position = hole9s;
            GameController.score += 100;
        }
        // hole 8 death collision
        if(other.gameObject.tag == "DeathH8") { 
            transform.position = hole8s;
            GameController.lives -= 1;
        }
        // hole 9 bad hole collision
        if(other.gameObject.tag == "Hole9_1") {
            GameController.score += 50;
            transform.position = hole9s;
        }
        // hole 9 regular hole collision
        if(other.gameObject.tag == "Hole9_2") {
            GameController.score += 100;
            transform.position = hole9s;
        }
        // hole 9 best hole collision 
        if(other.gameObject.tag == "Hole9_3") {
            GameController.score += 150;
            transform.position = hole9s;
        }
        // hole 9 death collision
        if(other.gameObject.tag == "DeathH9") {
            transform.position = hole9s;
            GameController.lives -= 1;
        }
    }
}