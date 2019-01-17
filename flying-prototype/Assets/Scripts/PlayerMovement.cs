using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerObj;

    private bool _rotateCW;
    private bool _rotateCCW;
    private bool _accelerate;
    private float _accelerateTime;
    private int _accelerationPower;
    private int _rotationPower;

    // Use this for initialization
    void Start ()
    {
        _accelerationPower = 480;
        _accelerateTime = 0;
        _rotationPower = 420;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
	}

    // Used for physics operations
    void FixedUpdate()
    {
        Vector2 forwardVector = Vector2FromAngle(PlayerObj.rotation );

        BoundaryForce();
        if (_accelerate && _accelerateTime > 0.2f)
        {
            PlayerObj.AddForce(forwardVector * _accelerationPower * Time.deltaTime, ForceMode2D.Force);
            _rotationPower = 100;
        }
        if (_rotateCW)
        {
            PlayerObj.rotation += _rotationPower * Time.deltaTime;
            // Debug.Log(RotationPower);
        }
        if (_rotateCCW)
        {
            PlayerObj.rotation -= _rotationPower * Time.deltaTime;
        }
        SetDrag();
        _rotationPower = 420;
    }

    void BoundaryForce()
    {
        Vector2 boundaryVector = PlayerObj.transform.position * 0.8f;

        boundaryVector.x *= -1;
        boundaryVector.y *= -1;
        if (PlayerObj.transform.position.x > -4f && PlayerObj.transform.position.x < 4f)
        {
            boundaryVector.x = 0;
        }
        if (PlayerObj.transform.position.y > -4f && PlayerObj.transform.position.y < 4f)
        {
            boundaryVector.y = 0;
        }
        if (PlayerObj.transform.position.x < -4.5f || PlayerObj.transform.position.x > 4.5f ||
            PlayerObj.transform.position.y < -4.5f || PlayerObj.transform.position.y > 4.5f)
        {
            PlayerObj.drag = 6f;
            boundaryVector *= 4;
        }
        PlayerObj.AddForce(boundaryVector);
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
        a = a * Mathf.Deg2Rad +  90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }

    void GetInput()
    {
        _rotateCCW = false;
        _rotateCW = false;
        _accelerate = false;
        
        Debug.Log(_accelerateTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _accelerate = true;
            _accelerateTime += Time.deltaTime;
        }
        else
        {
            _accelerateTime = 0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
            _rotateCW = true;
        if (Input.GetKey(KeyCode.LeftArrow))
            _rotateCCW = true;
    }
}
