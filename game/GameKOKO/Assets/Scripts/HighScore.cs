﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HighScore : IComparable<HighScore>
{
    public int Score { get; set; }
    public string Name { get; set; }

    public DateTime Date { get; set; }

    public int ID { get; set; }

    public HighScore(int id, int score, string name, DateTime date)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
        this.Date = date;
    }
		
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
