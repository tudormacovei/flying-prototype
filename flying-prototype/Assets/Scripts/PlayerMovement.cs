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
        AccelerationPower = 480;
        RotationPower = 420;
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

        BoundaryForce();
        if (accelerate)
        {
            PlayerObj.AddForce(forwardVector * AccelerationPower * Time.deltaTime, ForceMode2D.Force);
            RotationPower = 100;
        }
        if (rotateCW)
        {
            PlayerObj.rotation += RotationPower * Time.deltaTime;
            // Debug.Log(RotationPower);
        }
        if (rotateCCW)
        {
            PlayerObj.rotation -= RotationPower * Time.deltaTime;
        }
        SetDrag();
        RotationPower = 420;
    }

    void BoundaryForce()
    {
        Vector2 boundaryVector = PlayerObj.transform.position;

        boundaryVector.x *= -1;
        boundaryVector.y *= -1;
        if (PlayerObj.transform.position.x < -5f || PlayerObj.transform.position.x > 5f ||
            PlayerObj.transform.position.y < -4.2f || PlayerObj.transform.position.y > 4.2f)
        {
            PlayerObj.AddForce(boundaryVector * 2);
        }
        if (PlayerObj.transform.position.x < -6f || PlayerObj.transform.position.x > 6f ||
            PlayerObj.transform.position.y < -4.6f || PlayerObj.transform.position.y > 4.6f)
        {
            PlayerObj.drag = 4f;
            PlayerObj.AddForce(boundaryVector * 6);
        }
    }

    void SetDrag()
    {
        PlayerObj.drag = 0.5f;
        if (PlayerObj.velocity.magnitude > 1f)
        {
            PlayerObj.drag = 0.7f;
        }
        if (PlayerObj.velocity.magnitude > 5f)
        {
            PlayerObj.drag = 2f;
        }
        // Debug.Log("Speed: " + PlayerObj.velocity.magnitude);
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
