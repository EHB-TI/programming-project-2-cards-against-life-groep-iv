using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsJson
{
    // Start is called before the first frame update
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public List<Answer> answers = new List<Answer>();
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
    [System.Serializable]
    public class PG13
    {
        public List<Answer> answers { get; set; }
        public List<Question> questions { get; set; }
    }
    [System.Serializable]
    public class Root
    {
        public PG13 PG13 { get; set; }
    }
}