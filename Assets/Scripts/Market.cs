using UnityEngine;
using System.Collections;
using WebSocketSharp;
using LitJson;

public class Market : MonoBehaviour {
    public string ip = "192.168.0.101";
    public string port = "8000";
    public string target = "market-display";
    public int marketIndex = 1;

    public Renderer display;

    private WebSocket ws;
    private JsonData jockeyState;

    // Use this for initialization
    IEnumerator Start() {
        ws = new WebSocket("ws://192.168.0.103:8000/marketws/1");

        yield return ws;

        ws.OnMessage += (sender, e) => {
            Debug.Log(e.Data);
        };
        ws.Connect();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
