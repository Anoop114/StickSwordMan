using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform camTarget;
	private Vector3 offset;
	private void Start() {
		offset = camTarget.position - this.transform.position;
	}

	private void Update() {
		if(camTarget != null)
		{
			this.transform.position = camTarget.position - offset;
		}
	}
}
