using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
  
    public Button startButton;
    public Button retryButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI catchText;
    public TextMeshProUGUI winText;
    private Animator playerAnim;
    public static Vector3 gravity;
    public bool isGameActive = false;
    private float touchPosX;
    float moveSpeed = 9.0f;
    
    private float yOffset = -5.0f;

    private float delay = 1.5f;
    private bool steppedOn = false;
    private float timer = 0f;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
      
    }


    private void Movement()
    {
        if (isGameActive == true)
        {
            touchPosX += Input.GetAxis("Mouse X") * 5.0f * Time.fixedDeltaTime;
            transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            playerAnim.SetFloat("Speed_f", 1.0f);
        }

      if (transform.position.y < yOffset)
        {
            StartCoroutine(GameOverCo());

        }


    }

 /*   private void IsSteppedOn()
    {
        if(steppedOn)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
              

                GameObject.FindGameObjectWithTag("Ground").GetComponent<Rigidbody>().useGravity = true;
                GameObject.FindGameObjectWithTag("Ground").GetComponent<Rigidbody>().isKinematic = false;
            }
        }
      
    }*/




    public void startGame()
    {
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        catchText.gameObject.SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   

    IEnumerator GameOverCo()
    {
        gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        isGameActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerAnim.SetFloat("Speed_f", 0.0f);

    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(isGameActive==true)
            {
                Color randomlySelectedColor = getRandomColor();
                collision.gameObject.GetComponent<Renderer>().material.color = randomlySelectedColor;
                //  collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
                /* float yPos = collision.gameObject.transform.position.y;
                 yPos = -1.5f;
                 collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, yPos, collision.gameObject.transform.position.z); */


                collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collision.gameObject.GetComponent<Rigidbody>().useGravity = true;



            }
            
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            isGameActive = false;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            catchText.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
            
        }

        if(collision.gameObject.CompareTag("FinalGround"))
        {
            isGameActive = false;
            playerAnim.SetFloat("Speed_f", 0.0f);
            winText.gameObject.SetActive(true);
        }
    }
  

    private Color getRandomColor()
    {
        return new Color
        (
            r: UnityEngine.Random.Range(0f, 1f),
            g: UnityEngine.Random.Range(0f, 1f),
            b: UnityEngine.Random.Range(0f, 1f) );     
    }


   

}
