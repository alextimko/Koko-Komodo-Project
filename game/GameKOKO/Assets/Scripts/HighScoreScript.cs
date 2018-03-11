using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {
	/// <summary>
	/// Game obhects score,scoreName and rank are created
	/// </summary>
    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;
	/// <summary>
	/// Sets the score.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="score">Score.</param>
	/// <param name="rank">Rank.</param>
    public void SetScore(string name, string score, string rank)
    {
        this.score.GetComponent<Text>().text = score;
        this.scoreName.GetComponent<Text>().text = name;
        this.rank.GetComponent<Text>().text = rank;
    }
}
