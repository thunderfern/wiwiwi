using System.Collections.Generic;
using UnityEngine;

public class JSONParser {

    public static (List<DialogueScreen>, Goal) parseStory(TextAsset file) {

        string fullText = file.text;
        string[] lines = fullText.Split('\n');

        string currentRead = "";

        List<DialogueScreen> tmplist = new List<DialogueScreen>();
        Goal tmpgoal = new Goal();

        for (int i = 0; i < lines.Length; i++) {
            
            lines[i] = lines[i].Trim();

            if (lines[i].Equals("")) continue;
            if (lines[i].Equals("DIALOGUE")) currentRead = "DIALOGUE";
                else if (lines[i].Equals("GOAL")) currentRead = "GOAL";
                else if (currentRead.Equals("DIALOGUE")) {
                    DialogueScreen tmp = new DialogueScreen(lines[i], lines[i + 1], lines[i + 2], lines[i + 3]);
                    i += 3;
                    tmplist.Add(tmp);
                }
        }
        Debug.Log(tmplist.Count);
        
        return (tmplist, tmpgoal);
        
    }
    
}
