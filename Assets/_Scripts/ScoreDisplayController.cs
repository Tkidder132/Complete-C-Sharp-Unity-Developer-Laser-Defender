using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        Text scoreDisplay = GetComponent<Text>();
        scoreDisplay.text = "Score: " + ScoreController.score.ToString();
        ScoreController.ResetScore();
	}
}
