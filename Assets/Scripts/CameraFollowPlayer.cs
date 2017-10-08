using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
	public Transform Target;
	public float SmoothSpeed = 0.1f;
	public Vector3 Offset = new Vector3(0,0,-2f);

	private void FixedUpdate() {
		var desiredPosition = Target.position + Offset;
		var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
		transform.position = smoothedPosition;
	}
}
