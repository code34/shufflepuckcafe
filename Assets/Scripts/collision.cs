using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collision : MonoBehaviour {

    [SerializeField]
    private float minTranslation = 0.1f;
    private int scoreboard = 0;
    private string preTextScore = "SCORE: ";
    private string scoreTx = "0";
    private int pointsPerBounce = 1;

    [SerializeField]
    private Text scoreGUI;

    [SerializeField]
    public void setScore(int score)
    {
        scoreboard = score;
    }

    string addScore(){
        scoreboard += pointsPerBounce;
        scoreTx = scoreboard.ToString();
        increaseDiff();
        return scoreTx;
    }

    void increaseDiff()
    {
        float timeScaleLimit = 3f;
        float timeScaler = Time.timeScale + 0.03f;
        if (timeScaler > timeScaleLimit)
            timeScaler = timeScaleLimit;
        Time.timeScale = timeScaler;
    }

    void OnGUI() {
        scoreGUI.text = preTextScore + scoreTx;
    }

    // Use this for initialization
    void Start () {
        //transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision){
        var colPos = collision.transform.position;
        var rigid = GetComponent<Rigidbody>();
        if (collision.collider.tag == "paddle")
        {
            ContactPoint contact = collision.contacts[0];
            var contx = contact.point.x;
            var contz = contact.point.z;

            var diffX = (colPos.x - contx) * 5;
            var diffZ = -10;
            var alt = Random.Range(4, 9);

            Debug.Log(diffX);
            rigid.velocity = new Vector3(-diffX, alt, -diffZ);
            addScore();
        }
        if(collision.collider.tag == "ground")
        {
            rigid.position = new Vector3(0, -2, -2);
            rigid.velocity = new Vector3(0, 0, 0);
            rigid.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }
}
