using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Enemy code
public class Enemy : MonoBehaviour
{ 
    // how fast enemy moves
    public float speed;
    // used as player so the enemy has a target to move towards
    public Transform target;
    void Start()
    {
        speed = 2;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}