using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Display : MonoBehaviour {
    public string ip = "192.168.0.102";
    public string port = "8000";
    public string target = "central-display";

    [Serializable]
    public class PostData
    {
        public int teamIndex;
        public int turnIndex;
    }
    // Use this for initialization
    IEnumerator Start () {
        PostData postData = new PostData();
        postData.teamIndex = 1;
        postData.turnIndex = 1;

        string postJson = JsonUtility.ToJson(postData);
        byte[] postForm = Encoding.UTF8.GetBytes(postJson.ToCharArray());
        Hashtable hash = new Hashtable();
        hash.Add("Content-Type", "text/json");
        hash.Add("Content-Length", postForm.Length);

        Dictionary<string, string> header = new Dictionary<string, string>();
        header.Add("Content-Type", "text/json");
        header.Add("Content-Length", "postForm.Length");
        Debug.Log(postJson);

        WWW www = new WWW(appendUrl(), postForm, header);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("request Fail");
        }
        else
        {
            Debug.Log("request success");
            Debug.Log("returned data" + www.text);
        }
        print(www.text);
    }
	
	// Update is called once per frame
	void Update () {
	  
	}

    public string appendUrl()
    {
        string appended = ip + ":" + port + "/" + target;
        return appended;
    }

    //public WWW GET(string url)
    //{
    //    WWW www = new WWW(url);
    //    StartCoroutine(WaitForRequest(www));
    //    return www;
    //}

    //public WWW POST(string url, Dictionary<string, string> post)
    //{
    //    WWWForm form = new WWWForm();
    //    foreach (KeyValuePair<String, String> post_arg in post)
    //    {
    //        form.AddField(post_arg.Key, post_arg.Value);
    //    }
    //    WWW www = new WWW(url, form);

    //    StartCoroutine(WaitForRequest(www));
    //    return www;
    //}

    //private IEnumerator WaitForRequest(WWW www)
    //{
    //    yield return www;

    //    // check for errors
    //    if (www.error == null)
    //    {
    //        Debug.Log("WWW Ok!: " + www.text);
    //    } else {
    //        Debug.Log("WWW Error: "+ www.error);
    //    }    
    //}

}
