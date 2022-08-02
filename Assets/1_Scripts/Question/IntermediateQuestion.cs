using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Questions/IntermediateQuestion")]
public class IntermediateQuestion : Question
{
    public Operator operator2;
    [Range(0, 10)] public int value3;

    protected override void ConstructAnswer()
    {
        questionText = $"{value1} {OperatorDecider(operator1)} {value2} {OperatorDecider(operator2)} {value3}";
        formula = $"{value1}{MathOperator(operator1)}{value2}{MathOperator(operator2)}{value3}";
        object answer = table.Compute(formula, "");
        ans = Convert.ToDouble(answer);
    }
}
