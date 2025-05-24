using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;

    // Update is called once per frame
    void Update()
    {
        //Move Forward
        //transform.Translate(1, 0);

        //Same as...
        //transform.Translate(Vector2.right);

        //Move forward 20meters/second if speed is set to 20
        //transform.Translate(Vector2.right * Time.deltaTime * speed);

        //Get Input - Do this in Update()
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move player side to side with horizontal Input
        //transform.Translate(Vector2.right * turnSpeed * Time.deltaTime* horizontalInput);

        //Move forward with vertical Input
        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        //Rotate player with horizontal Input
        //transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * horizontalInput);
        if(verticalInput < 0)
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
        }
    }
}
