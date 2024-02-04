using System;

[Serializable]
public struct ScoreItem
{
    public string Name;
    public float Score;
    public ScoreItem(string name, float score)
    {
        Name = name;
        Score = score;
    }
}
