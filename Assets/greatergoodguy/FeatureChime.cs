using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FeatureChime : NetworkBehaviour {

	AudioSource audioSource;

	void Awake() {
		audioSource = transform.GetComponent<AudioSource>();
	}

	void Update() {
		if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space)) {
			Chime();
		}
	}

	public void Chime() {
		Debug.Log("Chime()");
		CmdChime();
	}

	[Command]
	public void CmdChime() {
		Debug.Log("CmdChime()");
		RpcChime();
	}

	[ClientRpc]
	public void RpcChime() {
		Debug.Log("RpcFeint()");

		audioSource.Play();
	}
}
