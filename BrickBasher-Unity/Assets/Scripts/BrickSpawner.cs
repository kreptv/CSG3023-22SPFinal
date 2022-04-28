/****
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 *
 * Last Edited by: Haley Kelly
 * Last Edited: 4/28/2022
 *
 * Description: Spawns bircks
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{

    public GameObject brickPrefab;
    public float paddingBetweenBricks = 0.25f;
    private Vector2 brickPadding = new Vector2(0,0);


    // Start is called before the first frame update
    void Start()
    {

       //brick padding is the width/height of the brick plus the padding between
       brickPadding.x = brickPrefab.transform.localScale.x + paddingBetweenBricks;
       brickPadding.y = brickPrefab.transform.localScale.y + paddingBetweenBricks;


        for (int y=0; y < 7; y++)
        {
            for(int x=0; x < 7; x++)
            {
                Vector3 pos = new Vector3(x * brickPadding.x , y * brickPadding.y, 0); // to space bricks equally

                GameObject brickGo = Instantiate(brickPrefab); // instantiate bricks in a 7 x 7 block

                brickGo.transform.parent = transform;
                brickGo.transform.localPosition = pos; // set transform position to pos determined by brickPadding

            }//end for(int x=0; x < 9; x++)
        }//end for (int y=0; y < 9; y++)
    }

}
