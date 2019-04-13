using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Target;

    private System.Random rand;
    private Vector2 forwardVector;
    private int randValue;
    private float rotationSpeed;
    private float _accelerationPower;

    // Use this for initialization
    void Start ()
    {
        // Randomize the speed of enemies spawned at different times
        rand = new System.Random();
        randValue = rand.Next(1, 10);
        Speed += randValue * 0.1f;
        rotationSpeed = 5;
        // Randomize this, speed is unused
        _accelerationPower = 20;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 vectorToTarget = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        // transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        forwardVector = Vector2FromAngle(angle);
        gameObject.GetComponent<Rigidbody2D>().AddForce(forwardVector * _accelerationPower * Time.deltaTime, ForceMode2D.Force);
    }

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad + 90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
