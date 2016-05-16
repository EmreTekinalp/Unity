using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player_control : MonoBehaviour {

    public float speed;
    public Text count_text;
    public Text win_text;

    private Rigidbody rb;
    private short count;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        win_text.text = "";
    }

    // Fixed Update is called before physics applied
    void FixedUpdate ()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count ++;
            SetCountText();
            if (count >= 12)
            {
                win_text.text = "YOU WIN!";
            }
        }
    }

    void SetCountText()
    {
        count_text.text = "Count: " + count;
    }
}
