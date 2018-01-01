using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class ConnectionController : MonoBehaviour {
	public SocketIOComponent socket;

	private void Start () {
		StartCoroutine(ConnectToServer());
		socket.On("Joined", OnJoined);
		socket.On("Moved", OnMoved);
		socket.On("Leaved", OnMoved);
	}

	private void Update () {
	}

	private IEnumerator ConnectToServer() {
		yield return new WaitForSeconds(0.5f);

		Dictionary<string, string> connectionInfo = new Dictionary<string, string>();
		connectionInfo["name"] = "player-1";
		connectionInfo["roomID"] = "oiraga-test-room";

		socket.Emit("Join", new JSONObject(connectionInfo));
	}

	private void OnJoined(SocketIOEvent ev) {
		Debug.Log("Joined: " + ev.data);
	}

	private void OnMoved(SocketIOEvent ev) {
		Debug.Log("Moved: " + ev.data);
	}

	private void OnLeaved(SocketIOEvent ev) {
		Debug.Log("Leaved: " + ev.data);
	}
}
