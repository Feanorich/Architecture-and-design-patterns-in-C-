using System;
using System.Collections.Generic;
using UnityEngine;

public class Equation
{
    public decimal CalculateEquation(string equationString)
    {
        List<Step> _steps = ParceEquation(equationString);

        decimal result = 0;

        int maxPr = Prioritization(_steps);
        if (maxPr > 0)
        {
            result = Calculations(_steps, maxPr);
        }

        return result;
    }

    private bool IsDigit(char ch)
    {
        bool result = false;
        if ((ch == '1') || (ch == '2') || (ch == '3') || (ch == '4') || (ch == '5') || (ch == '6')
                 || (ch == '7') || (ch == '8') || (ch == '9') || (ch == '0'))
        {
            result = true;
        }

        return result;
    }

    private bool IsSign(char ch)
    {
        bool result = false;
        if ((ch == '(') || (ch == ')') || (ch == '+') || (ch == '-') || (ch == '*') || (ch == '/'))
        {
            result = true;
        }

        return result;
    }
    class Step
    {
        public string Symbol = "";
        public int Priority = 0;
        public Step(string _symbol, int _priority = 0)
        {
            Symbol = _symbol;
            Priority = _priority;
        }
    }
    private List<Step> ParceEquation(string equationString)
    {
        List<Step> _steps = new List<Step>();
        string _symbol = "";

        for (int i = 0; i < equationString.Length; i++)
        {
            Debug.Log(equationString[i]);

            if (IsDigit(equationString[i]))
            {
                _symbol += equationString[i];
            }
            else if ((IsSign(equationString[i])) && (i < equationString.Length - 1))
            {
                if (_symbol.Length > 0)
                {
                    _steps.Add(new Step(_symbol));
                }
                _symbol = "";

                _steps.Add(new Step(equationString[i].ToString()));
            }
        }

        if (_symbol.Length > 0)
        {
            _steps.Add(new Step(_symbol));
        }

        DebugSteps(_steps);

        return _steps;
    }

    private int Prioritization(List<Step> _steps)
    {
        int currentPriority = 1;
        int maxPriority = 1;

        void ErrorOccurred()
        {
            Debug.LogError("Что-то со скобками напутали");
            _steps.Clear();
            _steps.Add(new Step("лажа"));
            maxPriority = -1;
        }

        for (int i = 0; i < _steps.Count; i++)
        {
            if (_steps[i].Symbol == "(") currentPriority += 2;
            if (_steps[i].Symbol == ")") currentPriority -= 2;

            if ((_steps[i].Symbol == "+") || (_steps[i].Symbol == "-")) _steps[i].Priority = currentPriority;
            if ((_steps[i].Symbol == "*") || (_steps[i].Symbol == "/")) _steps[i].Priority = currentPriority + 1;

            if (maxPriority < _steps[i].Priority) maxPriority = _steps[i].Priority;

            if (currentPriority < 1)
            {
                ErrorOccurred();
                break;
            }
        }

        if (currentPriority != 1)
        {
            ErrorOccurred();
        }

        DebugSteps(_steps, "приоритеты");

        return maxPriority;
    }

    private decimal Calculations(List<Step> _steps, int maxPr)
    {
        decimal result = 0;
        for (int i = _steps.Count - 1; i >= 0; i--)
        {
            if ((_steps[i].Symbol == "(") || (_steps[i].Symbol == ")")) _steps.RemoveAt(i);
        }
        DebugSteps(_steps, "очистка скобок");

        Debug.Log("считаем " + StepsToString(_steps));

        for (int pr = maxPr; pr >= 1; pr--)
        {
            while (Calculate(ref _steps, pr))
            {

            }
        }
        result = Convert.ToDecimal(_steps[0].Symbol);
        return result;
    }
    private bool Calculate(ref List<Step> _steps, int priority)
    {
        bool result = false;

        for (int i = 0; i < _steps.Count; i++)
        {
            if (_steps[i].Priority == priority)
            {
                string sign = _steps[i].Symbol;
                decimal number1 = 0; decimal number2 = 0; decimal _result = 0;

                if (i == _steps.Count - 1) number2 = 0;
                else number2 = Convert.ToDecimal(_steps[i + 1].Symbol);

                if (i == 0) number1 = 0;
                else number1 = Convert.ToDecimal(_steps[i - 1].Symbol);

                if (sign == "+") _result = number1 + number2;
                if (sign == "-") _result = number1 - number2;
                if (sign == "*") _result = number1 * number2;
                if (sign == "/") _result = number1 / number2;

                Debug.Log($"{number1} {sign} {number2} = {_result} ___({i})");

                _steps[i] = new Step(_result.ToString());
                TryToRemove(ref _steps, i + 1);
                TryToRemove(ref _steps, i - 1);

                Debug.Log("__ " + StepsToString(_steps));
                result = true;
                break;
            }
        }

        return result;
    }
    private bool TryToRemove(ref List<Step> _steps, int _index)
    {
        if ((_steps.Count > _index) && (_index >= 0))
        {
            _steps.RemoveAt(_index);
            return true;
        }

        return false;
    }
    private string StepsToString(List<Step> _steps)
    {
        string result = "";
        for (int i = 0; i < _steps.Count; i++)
        {
            result += _steps[i].Symbol;
        }
        return result;
    }
    private void DebugSteps(List<Step> _steps, string head = "список")
    {
        Debug.Log(head);
        for (int i = 0; i < _steps.Count; i++)
        {
            Debug.Log($"_{_steps[i].Symbol}_{_steps[i].Priority}_");
        }
    }
}
