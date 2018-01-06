using UnityEngine;
using System.Collections;

public class movePaddle : MonoBehaviour {

    [SerializeField]
    private float speed =0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
            float trans_Y = Input.GetAxis("Mouse Y") * speed;
            float trans_X = Input.GetAxis("Mouse X") * speed;
            trans_Y = trans_Y * Time.deltaTime;
            trans_X = trans_X * Time.deltaTime;
            transform.Translate(trans_X, trans_Y, 0);
    }
}
