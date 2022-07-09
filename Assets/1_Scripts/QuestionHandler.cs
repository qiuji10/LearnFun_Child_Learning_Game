using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionHandler : MonoBehaviour
{
    public TMP_Text quesText;
    public Button[] buttons;
    public TMP_Text[] tmp;

    public float nextQuestionDelay;
    private int questionIndex;

    private QuestionsDatabase quesData;
    private Question question;
    private List<int> buttonIndex = new List<int>();

    private void Awake()
    {
        quesData = FindObjectOfType<QuestionsDatabase>();
    }

    private void Start()
    {
        Shuffle(quesData.easyQuestions);
        question = quesData.easyQuestions[questionIndex];
        quesText.text = question.questionText;
        AssignListener();
    }

    public void Shuffle(List<Question> ques)
    {
        var count = ques.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ques[i];
            ques[i] = ques[r];
            ques[r] = tmp;
        }
    }

    public void NextQuestion()
    {
        Debug.Log(questionIndex + "\n" + quesData.easyQuestions.Count);
        if (questionIndex == quesData.easyQuestions.Count)
        {
            Shuffle(quesData.easyQuestions);
            questionIndex = 0;
        }
        else
        {
            questionIndex++;
            question = quesData.easyQuestions[questionIndex];
            quesText.text = question.questionText;
            AssignListener();
        }

    }

    public void AssignListener()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, 4);
            
            while (buttonIndex.Contains(rand))
            {
                rand = Random.Range(0, 4);
            }

            buttonIndex.Add(rand);
            tmp[rand].text = question.falseAns[i];
            buttons[rand].onClick.AddListener(Fail);
        }

        for (int i = 0; i < 4; i++)
        {
            if (!buttonIndex.Contains(i))
            {
                tmp[i].text = question.ans.ToString();
                buttons[i].onClick.AddListener(Success);
            }
        }

        buttonIndex.Clear();
    }

    public void Success()
    {
        Debug.Log("Success");
        StartCoroutine(PrepareNextQuestion());
    }

    public void Fail()
    {
        Debug.Log("Fail");
    }

    private IEnumerator PrepareNextQuestion()
    {
        yield return new WaitForSeconds(nextQuestionDelay);
        NextQuestion();
    }
}
