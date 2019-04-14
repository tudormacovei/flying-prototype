using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Target;

    private System.Random rand;
    private Vector2 accelerateVector;
    private int randInt;
    private float rotateSpeed;
    private float acceleratePower;

    // Use this for initialization
    void Start ()
    {
        // Randomize the acceleration of enemies spawned at different times
        rand = new System.Random();
        randInt = rand.Next(1, 10);
        acceleratePower = 15 + randInt;
        rotateSpeed = 5;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 vectorToTarget;
        float angle;
        Quaternion q;

        vectorToTarget = Target.transform.position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
        accelerateVector = Vector2FromAngle(angle);
        gameObject.GetComponent<Rigidbody2D>().AddForce(accelerateVector * acceleratePower * Time.deltaTime, ForceMode2D.Force);
    }

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad + 90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
