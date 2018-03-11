using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HighScore : IComparable<HighScore>
{
	/// <summary>
	/// Gets or sets the score.
	/// </summary>
	/// <value>The score.</value>
    public int Score { get; set; }
    public string Name { get; set; }

    public DateTime Date { get; set; }

    public int ID { get; set; }
	/// <summary>
	/// High score constractor
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="score">Score.</param>
	/// <param name="name">Name.</param>
	/// <param name="date">Date.</param>
    public HighScore(int id, int score, string name, DateTime date)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
        this.Date = date;
    }
		/// <summary>
		/// Compares the score.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="other">Other.</param>
    public int CompareTo(HighScore other)
    {
        //first > second return -1
        //first < second return 1
        //first == second return 0

        if (other.Score < this.Score) //If the other score is less than this
        {
            return -1;
        }
        else if (other.Score > this.Score) //If the other score is larger than this
        {
            return 1;
        }
        else if (other.Date < this.Date) //If the scores are equal then we need to check the date
        {
            return -1;
        }
        else if (other.Date > this.Date)
        {
            return 1; 
        }

        //we will return 0 if the scores and dates are identical. 
        return 0;
    }
}
