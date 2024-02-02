using System;
using System.Collections.Generic;

[Serializable]
public class ScoreData
{
    public List<ScoreItem> Scores;

    public ScoreData()
    { 
        Scores = new List<ScoreItem>();
    }
}
