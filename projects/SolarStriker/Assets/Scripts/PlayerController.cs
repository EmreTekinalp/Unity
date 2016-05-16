using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed, tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public Transform leftShotSpawn;
    public Transform rightShotSpawn;
    public float fire_rate;

    private float next_fire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > next_fire)
        {
            next_fire = Time.time + fire_rate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, leftShotSpawn.position, leftShotSpawn.rotation);
            Instantiate(shot, rightShotSpawn.position, rightShotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called before physics
    void FixedUpdate()
    {
        float horizontal_move = Input.GetAxis("Horizontal");
        float vertical_move = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal_move, 0.0f, vertical_move);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
