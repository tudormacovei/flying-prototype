using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Rigidbody2D PlayerRigid;
    public GameObject BulletPrefab;

    GameObject clone;
    int bulletSpeed;
    float deltaTime;

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

        deltaTime -= Time.deltaTime;
        clonePosition = PlayerRigid.transform.position;
        if (Input.GetKey(KeyCode.Space) && deltaTime < 0)
        {
            clone = Instantiate(BulletPrefab, PlayerRigid.transform);
            cloneRigid = clone.GetComponent<Rigidbody2D>();
            cloneRigid.AddForce(forwardVector * bulletSpeed);
            deltaTime = 0.2f;
        }
	}

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad + 90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}