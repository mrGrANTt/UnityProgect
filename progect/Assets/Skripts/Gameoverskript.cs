using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameoverskript : MonoBehaviour
{
    public Text pT;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pT.text = score.ToString();
    }
}
