using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum Operator { add, subtract, multiply, divide }

public class QuestionsDatabase : MonoBehaviour
{
    //[Expandable]
    public List<Question> questionsData;
}
