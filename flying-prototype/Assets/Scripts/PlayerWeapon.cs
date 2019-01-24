using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Rigidbody2D PlayerRigid;
    public GameObject BulletPrefab;

    GameObject _clone;
    int _bulletSpeed;
    float _deltaTime;

    // Use this for initialization
    void Start ()
    {
        _bulletSpeed = 35;
        _deltaTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody2D _cloneRigid;
        Vector3 _clonePosition;
        Vector2 forwardVector = Vector2FromAngle(PlayerRigid.rotation);

        _deltaTime -= Time.deltaTime;
        _clonePosition = PlayerRigid.transform.position;
        if (Input.GetKey(KeyCode.Space) && _deltaTime < 0)
        {
            _clone = Instantiate(BulletPrefab, PlayerRigid.transform);
            _cloneRigid = _clone.GetComponent<Rigidbody2D>();
            _cloneRigid.AddForce(forwardVector * _bulletSpeed);
            _deltaTime = 0.2f;
        }
	}

    Vector2 Vector2FromAngle(float a)
    {
        a = a * Mathf.Deg2Rad + 90 * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}