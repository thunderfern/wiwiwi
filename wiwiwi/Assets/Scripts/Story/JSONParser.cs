using System.Collections.Generic;
using UnityEngine;

public class JSONParser {

    public static (List<DialogueScreen>, Goal) parseStory(TextAsset file) {

        string fullText = file.text;
        string[] lines = fullText.Split('\n');

        string currentRead = "";

        List<DialogueScreen> tmplist = new List<DialogueScreen>();
        Goal tmpgoal = new Goal();

        for (int i = 0; i < lines.Length; i++)
        {

            lines[i] = lines[i].Trim();

            if (lines[i].Equals("")) continue;
            if (lines[i].Equals("DIALOGUE")) currentRead = "DIALOGUE";
            else if (lines[i].Equals("GOAL")) currentRead = "GOAL";
            else if (lines[i].Equals("SETUP")) currentRead = "SETUP";
            else if (currentRead.Equals("DIALOGUE"))
            {
                DialogueScreen tmp = new DialogueScreen(lines[i].Trim(), lines[i + 1].Trim(), lines[i + 2].Trim(), lines[i + 3].Trim());
                i += 3;
                tmplist.Add(tmp);
            }
            else if (currentRead.Equals("GOAL"))
            {
                tmpgoal = new Goal(lines[i].Trim(), lines[i + 1].Trim(), lines[i + 2].Trim());
                i += 2;
            }
        }
        
        return (tmplist, tmpgoal);
        
    }
    
}
