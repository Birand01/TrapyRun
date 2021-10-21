using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed = 9.0f;
    public GameObject player;
    private Animator playerAnim;
    public TextMeshProUGUI lostText;
    private float yOffset = -2.5f;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.GetComponent<PlayerMovement>().isGameActive==true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }

        if(transform.position.y<yOffset)
        {
            Destroy(gameObject);
        }

       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("FinalGround"))
        {
            player.GetComponent<PlayerMovement>().isGameActive =false;
            lostText.gameObject.SetActive(true);
            playerAnim.SetFloat("Speed_f", 0.0f);
        }
    }
}
