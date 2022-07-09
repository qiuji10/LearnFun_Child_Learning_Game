using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operator { add, subtract, multiply, divide }

public class QuestionsDatabase : MonoBehaviour
{
    public List<Question> easyQuestions;
    public List<Question> hardQuestions;
}
