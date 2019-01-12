using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerObj;

    private bool rotateCW;
    private bool rotateCCW;
    private bool accelerate;

    public int AccelerationPower { get; set; }
    public int RotationPower { get; set; }

    // Use this for initialization
    void Start ()
    {
        AccelerationPower = 500;
        RotationPower = 400;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
	}

    // Used for physics operations
    void FixedUpdate()
    {
        Vector2 forwardVector = Vector2FromAngle(PlayerObj.rotation);

        if (accelerate && PlayerObj.velocity.magnitude < 5)
        {
            PlayerObj.AddForce(forwardVector * AccelerationPower * Time.deltaTime, ForceMode2D.Force);
            RotationPower = 100;
        }
        if (rotateCW)
        {
            PlayerObj.rotation += RotationPower * Time.deltaTime;
            Debug.Log(RotationPower);
        }
        if (rotateCCW)
        {
            PlayerObj.rotation -= RotationPower * Time.deltaTime;
        }
        RotationPower = 400;
    }

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }

    void GetInput()
    {
        rotateCCW = false;
        rotateCW = false;
        accelerate = false;

        if (Input.GetKey(KeyCode.UpArrow))
            accelerate = true;
        if (Input.GetKey(KeyCode.RightArrow))
            rotateCW = true;
        if (Input.GetKey(KeyCode.LeftArrow))
            rotateCCW = true;
    }
}
