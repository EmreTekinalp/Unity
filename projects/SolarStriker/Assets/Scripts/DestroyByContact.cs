using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player;
    public short scoreValue;
    private GameController gamecontroller;

    void Start()
    {
        GameObject gameObjectController = GameObject.FindWithTag("GameController");
        if (gameObjectController != null)
        {
            gamecontroller = gameObjectController.GetComponent<GameController>();
        }
        if (gameObjectController == null)
        {
            Debug.Log("GameController does not exist in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(player, other.transform.position, other.transform.rotation);
            gamecontroller.ShipDestroyed(true);
        }
        gamecontroller.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
