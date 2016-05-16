using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 25, 60) * Time.deltaTime);	
	}
}
