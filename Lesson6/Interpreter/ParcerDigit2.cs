using UnityEngine;
using UnityEngine.UI;

public class ParcerDigit2 : MonoBehaviour
{
    public Text _text;
    public InputField _input;
    private Equation _equation;
    void Start()
    {
        string equationString = "-3+(10+4*pfkegf5)/15*";

        _equation = new Equation();

        decimal res = _equation.CalculateEquation(equationString);

        Debug.Log($"RESULT {res}");
    }

    public void ChangeText()
    {
        decimal result = _equation.CalculateEquation(_input.text);
        _text.text = result.ToString();
    }
    

}
