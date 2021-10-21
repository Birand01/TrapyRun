using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Player;
    private float yOffset = 8.5f;
    private float zOffset = -15.0f;
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y + yOffset, Player.position.z + zOffset);
    }
}
