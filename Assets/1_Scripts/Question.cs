using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

[CreateAssetMenu(menuName = "Questions/Question")]
public class Question : ScriptableObject
{
    [Header("Default")]
    public string questionText;
    [ValidateInput("LessThan3DecimalPlaces")]
    public double ans;
    public string[] falseAns = new string[3];

    protected string operatorStr;
    protected string formula;

    [Header("Formula")]
    [Range(0, 10)] public int value1;
    public Operator operator1;
    [Range(0, 10)] public int value2;
    protected System.Data.DataTable table = new System.Data.DataTable();

    protected virtual void ConstructAnswer()
    {
        questionText = $"{value1} {OperatorDecider(operator1)} {value2}";
        formula = $"{value1}{MathOperator(operator1)}{value2}";
        object answer = table.Compute(formula, "");
        ans = Convert.ToDouble(answer);
    }

    private bool LessThan3DecimalPlaces()
    {
        double value = ans * 1000;
        //Debug.Log("value: " + value +"\n(float)value" + (float)value + "\nMathf.Floor((float)value: " + Mathf.Floor((float)value));
        return (float)value == Mathf.Floor((float)value);
    }

    [Button]
    public void Constructor()
    {
        ConstructAnswer();
    }

    public string OperatorDecider(Operator operatorDecider)
    {
        switch (operatorDecider)
        {
            case Operator.add:
                operatorStr = "+";
                break;

            case Operator.subtract:
                operatorStr = "-";
                break;

            case Operator.multiply:
                operatorStr = "x";
                break;

            case Operator.divide:
                operatorStr = "ÅÄ";
                break;
        };

        return operatorStr;
    }

    public string MathOperator(Operator operatorDecider)
    {
        switch (operatorDecider)
        {
            case Operator.add:
                operatorStr = "+";
                break;

            case Operator.subtract:
                operatorStr = "-";
                break;

            case Operator.multiply:
                operatorStr = "*";
                break;

            case Operator.divide:
                operatorStr = "/";
                break;
        };

        return operatorStr;
    }
}
