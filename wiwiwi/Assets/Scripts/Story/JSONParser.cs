using System.Collections.Generic;
using UnityEngine;

public class JSONParser {

    public static List<DialogueScreen> parseText(TextAsset file) {
        DialogueScreen tmp = new DialogueScreen("happy", "happy", file.text, "happy");
        DialogueScreen tmp2 = new DialogueScreen("happy", "happy", "eeee", "happy");
        List<DialogueScreen> tmplist = new List<DialogueScreen>{ tmp, tmp2 };
        return tmplist;
        
    }
    
}
