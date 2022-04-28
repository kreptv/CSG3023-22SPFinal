/****
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 4/28/2022
 *
 * Description: Controls the ball and sets up the intial game behaviors.
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    [Header("General Settings")]
    public int ballNum;
    public int score;
    public Text ballTxt;
    public Text scoreTxt;
    public GameObject paddle;

    [Header("Ball Settings")]
    public float forceY = 0;
    Vector3 force;
    public float speed;
    bool isInPlay = false;
    public Rigidbody rb;
    public AudioSource audioSource;






    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
      force = new Vector3(0, forceY, 0);
      rb = this.GetComponent<Rigidbody>();
      audioSource = this.GetComponent<AudioSource>();
    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void FixedUpdate()
    {
      ballTxt.text = "Balls : " + ballNum;
      scoreTxt.text = "Score : " + score;

      if (!isInPlay){
        this.transform.position = new Vector3(paddle.transform.position.x, this.transform.position.y, this.transform.position.z);
      } // ! is in play
      if ((Input.GetKey("space")) && (!isInPlay)){
        isInPlay = true;
        Move();
      } // space key pressed; no ball currently moving

    }//end Update()


    private void LateUpdate()
    {
      if (isInPlay){
        rb.velocity = rb.velocity.normalized * speed;
      } // if is in play
    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball
    }//end SetStartingPos()

    void Move(){
    rb.AddForce(force * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
      audioSource.Play(0);
      if (collision.transform.tag == "Brick"){
        score += 100;
      Destroy(collision.gameObject);
      }
    } // onCollision

    void OnTriggerEnter(Collider collision){
      if (collision.transform.tag == "OutBounds"){
        ballNum -= 1;
        if (ballNum > 0){
          Invoke("SetStartingPos", 2);
        } // if
      } // if
    } // onCollision






}
