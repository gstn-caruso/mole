using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {
	public Transform Player;

	private void FixedUpdate() {
		var finalPosition = new Vector3(Player.position.x, transform.position.y, transform.position.z);
		transform.position = finalPosition;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
	}
}
