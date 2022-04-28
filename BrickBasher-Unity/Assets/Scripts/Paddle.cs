/****
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 4/28/2022
 *
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle


    // Update is called once per frame
    void FixedUpdate()
    {
      // if player is moving left or right; use Input.GetAxis
      float axis = Input.GetAxis("Horizontal") * speed;
      axis *= Time.deltaTime;
      transform.Translate(axis, 0, 0);


    }//end Update()
}
