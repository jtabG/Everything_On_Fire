using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    //dimensions of the game boundary
    public float xMin, xMax, yMin, yMax;

}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Updates with every Unity Physics cycle
    /// 
    /// Note:
    /// In Unity: X Transform is horizontal movement (left and right)
    /// In Unity: Y Transform is vertical movement (up and down)
    /// In Unity: Z Transform does nothing, since this is a 2D project
    /// </summary>
    void FixedUpdate()
    {

        //grab user input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //movement Vector
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //arcadey physics movement!!
        rb.velocity = movement * speed;
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
                Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax), 
                0.0f
            );

        rb.rotation = Quaternion.Euler(270.0f, 0.0f, rb.velocity.x * -tilt);
            
    }

}
