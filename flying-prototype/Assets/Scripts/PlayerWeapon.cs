using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Rigidbody2D PlayerRigid;
    public GameObject BulletPrefab;
    public Animator Animator;

    GameObject clone;
    int bulletSpeed;
    float deltaTime;
    System.Random rand = new System.Random();

    // Use this for initialization
    void Start ()
    {
        bulletSpeed = 35;
        deltaTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody2D cloneRigid;
        Vector3 clonePosition;
        Vector2 forwardVector = Vector2FromAngle(PlayerRigid.rotation);
        int randOffset;

        deltaTime -= Time.deltaTime;
        clonePosition = PlayerRigid.transform.position;
        if (Input.GetKey(KeyCode.Space) && deltaTime < 0 && !Animator.GetBool("Death"))
        {
            clone = Instantiate(BulletPrefab, PlayerRigid.transform);
            cloneRigid = clone.GetComponent<Rigidbody2D>();
            randOffset = rand.Next(1, 6);
            cloneRigid.AddForce(forwardVector * (bulletSpeed + randOffset));
            deltaTime = 0.2f;
        }
	}

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad + 90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}