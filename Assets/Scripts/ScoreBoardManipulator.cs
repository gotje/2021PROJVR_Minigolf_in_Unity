using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManipulator : MonoBehaviour
{
    private static List<GameObject> scores;
    private static List<bool> finishedHole;

    public void Main()
    {
        finishedHole = new List<bool>();
        scores = new List<GameObject>(GameObject.FindGameObjectsWithTag("scoreField"));
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
        for (int dmx = 0; dmx < finishedHole.Count; dmx++)
        {
            if (!(bool)finishedHole[dmx])
            {
                int temporary = int.Parse(scores[counter].GetComponent<Text>().text) + 1;
                scores[counter].GetComponent<Text>().text = "" + temporary;
                break;
            }
            counter++;
        }
    }

}
