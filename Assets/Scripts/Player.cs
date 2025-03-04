using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    
    //padding is used here for the main camera viewport as if there is no padding our player sprite is getting clipped at the sides of the screen
    // as the clamping is done from the pivot point of the player.
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    // minBounds & maxBounds are the normalized max and min positions of our viewport(the camera space) relative to the player. 
    Vector2 minBounds;
    Vector2 maxBounds; 

    void Start()
    {
        InitBounds();
    }
    void Update()
    { 
        Move();
    }
    
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        //Storing the Delta Position for our movment which we can then apply to transform.position!
        //Used Vector2 instead of Vector3 because we dont need movemnt along z-axis.
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        //Intializing the newPos as the new boundaries for the player movement which will allow us to edit X & Y component of this new vector
        // and then apply the changes back to the transform.position.
        Vector2 newPos = new Vector2();
        //Here in the Clamp method we need to pass 3 parameters i.e. the value that needs checking ("delta.x/y" that is our player's delta position)
        //and the min & max value that it needsto be checked against (minBounds/maxBounds)
        //*Here padding is added later to prevent the player sprite from clipping at the sides of viewport.*
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    //Unity will automatically recognize this method as part of the Input systems feature which will then get 
    //automatically called on its own without the need to call the fuction manually elsewhere in the program.
    void OnMove(InputValue value) 
    {
       rawInput = value.Get<Vector2>();
       Debug.Log(rawInput);
    }
}
