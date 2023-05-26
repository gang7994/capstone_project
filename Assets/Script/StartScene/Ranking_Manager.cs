using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

[System.Serializable]
public class RankingData
{
    public List<RankingEntry> ranking;
}

[System.Serializable]
public class RankingEntry
{
    public int survivalDays;
    public int monstersKilled;
}


public class Ranking_Manager : MonoBehaviour
{
    public GameObject ranking_content_1, ranking_content_2, ranking_content_3;
    public TextAsset jsonFile;

    void Start()
    {
        string jsonText = jsonFile.text;
        RankingData rankingData = JsonUtility.FromJson<RankingData>(jsonText);

        PrintTopRankings(rankingData.ranking, 3);
    }

    void PrintTopRankings(List<RankingEntry> ranking, int count)
    {
        ranking.Sort((a, b) =>
        {
            if (a.survivalDays != b.survivalDays)
                return b.survivalDays.CompareTo(a.survivalDays);
            else
                return b.monstersKilled.CompareTo(a.monstersKilled);
        });

        for (int i = 0; i < count && i < ranking.Count; i++)
        {
            RankingEntry entry = ranking[i];
            if(i==0) {
                if(entry.survivalDays !=0) ranking_content_1.GetComponent<Text>().text = entry.survivalDays + "   |   " + entry.monstersKilled;
                else ranking_content_1.GetComponent<Text>().text = "";
            }
            else if(i==1) {
                if(entry.survivalDays !=0) ranking_content_2.GetComponent<Text>().text = entry.survivalDays + "   |   " + entry.monstersKilled;
                else ranking_content_2.GetComponent<Text>().text = "";
            }
            else if(i==2) {
                if(entry.survivalDays !=0) ranking_content_3.GetComponent<Text>().text = entry.survivalDays + "   |   " + entry.monstersKilled;
                else ranking_content_3.GetComponent<Text>().text = "";
            }
        }
    }

    
}
