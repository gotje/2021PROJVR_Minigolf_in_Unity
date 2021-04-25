using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManipulator : MonoBehaviour
{
    private static ArrayList scores;
    private static ArrayList finishedHole;

    public void Main()
    {
        Text[] allText = GameObject.Find("Score Board Panel").GetComponentsInChildren<Text>();
        foreach(Text textField in allText)
        {
            if(textField.tag == "scoreField")
            {
                scores.Add(textField);
            }
            Debug.Log(textField.tag);
        }
        for (int dmx = 0; dmx < scores.Count; dmx++)
        {
            finishedHole.Add(false);
        }
    }

    public static void FinishedHole()
    {
        int counter = 0;
        foreach(bool holeStatus in finishedHole)
        {
            if (!holeStatus){
                finishedHole[counter] = true;
                break;
            }
            counter++;
        }
    }

    public static void increaseScore()
    {
        int counter = 0;
        Debug.Log(scores);
        for (int dmx = 0; dmx < finishedHole.Count; dmx++)
        {
            if (!(bool)finishedHole[dmx])
            {
                ((GameObject)scores[counter]).GetComponent<Text>().text = ((GameObject)scores[counter]).GetComponent<Text>().text + 1;
                break;
            }
            counter++;
        }
    }

}
