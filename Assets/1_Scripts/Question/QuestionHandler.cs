using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionHandler : MonoBehaviour
{
    public TMP_Text quesText;
    public Button[] button;
    public TMP_Text[] tmp;

    public float nextQuestionDelay;
    private int questionIndex;

    [SerializeField] AudioData answerAudio;
    [SerializeField] GameObject wrongIndicator;
    private Animator wrongAnim;
    private HistoryDatabase history;
    private QuestionsDatabase quesData;
    private Question question;
    private List<int> buttonIndex = new List<int>();

    private void Awake()
    {
        quesData = FindObjectOfType<QuestionsDatabase>();
        history = FindObjectOfType<HistoryDatabase>();
        wrongAnim = wrongIndicator.GetComponent<Animator>();
    }

    private void Start()
    {
        Shuffle(quesData.questionsData);
        question = quesData.questionsData[questionIndex];
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
        for (int i = 0; i < 4; i++)
        {
            button[i].onClick.RemoveAllListeners();
        }

        if (questionIndex == quesData.questionsData.Count-1)
        {
            Shuffle(quesData.questionsData);
            questionIndex = 0;
        }

        questionIndex++;
        question = quesData.questionsData[questionIndex];
        quesText.text = question.questionText;
        AssignListener();

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
            button[rand].onClick.AddListener(Fail);
        }

        for (int i = 0; i < 4; i++)
        {
            if (!buttonIndex.Contains(i))
            {
                tmp[i].text = question.ans.ToString();
                button[i].onClick.AddListener(Success);
            }
        }

        buttonIndex.Clear();
    }

    public void Success()
    {
        AudioManager.instance.PlaySFX(answerAudio, "correct");
        history.SavePlayerResult(true);
        StartCoroutine(PrepareNextQuestion());
    }

    public void Fail()
    {
        AudioManager.instance.PlaySFX(answerAudio, "wrong");
        history.SavePlayerResult(false);

        if (!wrongIndicator.activeInHierarchy)
        {
            wrongIndicator.SetActive(true);
            wrongAnim.SetTrigger("play");
        }
        else
        {
            wrongAnim.ResetTrigger("play");
            wrongAnim.SetTrigger("play");
        }
        
    }

    private IEnumerator PrepareNextQuestion()
    {
        yield return new WaitForSeconds(nextQuestionDelay);
        NextQuestion();
    }

    private IEnumerator WrongAnsAnimation()
    {
        yield return new WaitForSeconds(1);
        wrongIndicator.SetActive(false);
    }
}
