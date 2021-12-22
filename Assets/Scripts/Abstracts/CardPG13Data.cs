using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardPG13Data
{
    public int success { get; set; }
    public PG13 PG13 { get; set; }
}

[System.Serializable]
public class PG13
{
    public List<Answer> answers { get; set; }
    public List<Question> questions { get; set; }
}

[System.Serializable]
public class Answer
{
    public int id { get; set; }
    public string answer { get; set; }
}
[System.Serializable]
public class Question
{
    public int id { get; set; }
    public string question { get; set; }
}






