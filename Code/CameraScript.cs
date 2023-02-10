using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraScript : MonoBehaviour
{
    // player
    public GameObject player;
    // how far away from player
    private Vector3 offset;
    // rotation for pressing q and e
    private Quaternion rotation;
    // end game position
    private Vector3 endGame;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        offset = transform.position - player.transform.position;
        endGame = new Vector3(-500, 500, -500);
    }
    void LateUpdate()
    {
        if (GameController.lives > 0) {
            transform.position = player.transform.position + offset;
            if(Input.GetKeyDown(KeyCode.E)){
                rotation *= Quaternion.AngleAxis(90, Vector3.up);
            }

            if(Input.GetKeyDown(KeyCode.Q)){
                rotation *= Quaternion.AngleAxis(-90, Vector3.up);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);
        }
        else {
            transform.position = endGame;
        }
    }

}
