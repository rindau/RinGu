using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeating_Background : MonoBehaviour
{

    private BoxCollider2D groundcollider1;
    private float groundHorizontalLenght;

    // Start is called before the first frame update
    private void Awake ()
    {
        groundcollider1 = GetComponent<BoxCollider2D>();
        groundHorizontalLenght = groundcollider1.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (transform.position.y < -groundHorizontalLenght)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
        Vector2 groundOffSet = new Vector2(0, groundHorizontalLenght * 2f);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}
