using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRigid;

    private bool rotateCW;
    private bool rotateCCW;
    private bool accelerate;
    private float accelerateTime;
    private int acceleratePower;
    private int rotatePower;

    // Use this for initialization
    void Start ()
    {
        acceleratePower = 480;
        accelerateTime = 0;
        rotatePower = 420;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
	}

    // Used for physics operations
    void FixedUpdate()
    {
        Vector2 forwardVector = Vector2FromAngle(PlayerRigid.rotation);

        BoundaryForce();
        if (accelerate && accelerateTime > 0.2f)
        {
            PlayerRigid.AddForce(forwardVector * acceleratePower * Time.deltaTime, ForceMode2D.Force);
            rotatePower = 100;
        }
        if (rotateCW)
        {
            PlayerRigid.rotation -= rotatePower * Time.deltaTime;
        }
        if (rotateCCW)
        {
            PlayerRigid.rotation += rotatePower * Time.deltaTime;
        }
        SetDrag();
        rotatePower = 420;
    }

    void BoundaryForce()
    {
        Vector2 boundaryVector = PlayerRigid.transform.position * 0.8f;

        boundaryVector.x *= -1;
        boundaryVector.y *= -1;
        if (PlayerRigid.transform.position.x > -4f && PlayerRigid.transform.position.x < 4f)
        {
            boundaryVector.x = 0;
        }
        if (PlayerRigid.transform.position.y > -4f && PlayerRigid.transform.position.y < 4f)
        {
            boundaryVector.y = 0;
        }
        if (PlayerRigid.transform.position.x < -4.5f || PlayerRigid.transform.position.x > 4.5f ||
            PlayerRigid.transform.position.y < -4.5f || PlayerRigid.transform.position.y > 4.5f)
        {
            PlayerRigid.drag = 6f;
            boundaryVector *= 4;
        }
        PlayerRigid.AddForce(boundaryVector);
    }

    void SetDrag()
    {
        PlayerRigid.drag = 0.5f;
        if (PlayerRigid.velocity.magnitude > 1f)
        {
            PlayerRigid.drag = 0.7f;
        }
        if (PlayerRigid.velocity.magnitude > 5f)
        {
            PlayerRigid.drag = 2f;
        }
    }

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad +  90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }

    void GetInput()
    {
        rotateCCW = false;
        rotateCW = false;
        accelerate = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            accelerate = true;
            accelerateTime += Time.deltaTime;
        }
        else
        {
            accelerateTime = 0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
            rotateCW = true;
        if (Input.GetKey(KeyCode.LeftArrow))
            rotateCCW = true;
    }
}
