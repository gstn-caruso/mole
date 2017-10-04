using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {
	public Transform player;

	void FixedUpdate() {
		Vector3 finalPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
		transform.position = finalPosition;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
	}
}
