using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private GameObject player;
    private Player playerScript;
    [SerializeField]
    private float time = 1f;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z + 2f);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (playerScript.livesGetter() > 0)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, time * Time.fixedDeltaTime);
        }
    }
}
