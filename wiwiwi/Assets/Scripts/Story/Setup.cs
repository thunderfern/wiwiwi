using UnityEngine;
using System;

public class Setup
{
    string arg1;
    string arg2;
    string arg3;

    public Setup(string a, string b, string c)
    {
        arg1 = a;
        arg2 = b;
        arg3 = c;
    }

    public void setup() {
        if (arg1 == "Position")
        {
            Character curchar = (Character)Enum.Parse(typeof(Character), arg2);
            GameObject charObj = StoryManager.instance().characterObj[(int)curchar];
            if (arg3 == "DiningRoom")
            {
                charObj.transform.position = new Vector3(-18.11f, -13.22f, charObj.transform.position.z);
            }
            else if (arg3 == "DinnerTable")
            {
                StoryManager.instance().characterObj[(int)curchar].SetActive(false);
                StoryManager.instance().sittingObj[(int)curchar].SetActive(true);
            }
            else if (arg3 == "UndoDinnerTable")
            {
                if (curchar == Character.Player)
                {
                    World.instance().mainCharacter.GetComponent<SpriteRenderer>().enabled = true;
                    StoryManager.instance().sittingObj[(int)curchar].SetActive(false);
                }
                else
                {
                    StoryManager.instance().characterObj[(int)curchar].SetActive(true);
                    StoryManager.instance().sittingObj[(int)curchar].SetActive(false);
                }
            }
            else if (arg3 == "KitchenLeft")
            {
                charObj.transform.position = new Vector3(-0.94f, -8.59f, charObj.transform.position.z);
            }
            else if (arg3 == "KitchenMiddle")
            {
                charObj.transform.position = new Vector3(1.45f, -8.67f, charObj.transform.position.z);
            }
            else if (arg3 == "Cave")
            {
                charObj.transform.position = new Vector3(-32.86f, 0.35f, charObj.transform.position.z);
            }
            else if (arg3 == "Forest")
            {
                charObj.transform.position = new Vector3(-19.18f, 0.7f, charObj.transform.position.z);
            }
            else if (arg3 == "Pond")
            {
                charObj.transform.position = new Vector3(24.3f, -0.6f, charObj.transform.position.z);
            }
            else Debug.Log("neglected\n");
        }
        else if (arg1 == "Add")
        {
            if (arg2 == "Collectible")
            {
                Collectible arg3col = (Collectible)Enum.Parse(typeof(Collectible), arg3);
                Inventory.instance().addIngredient(arg3col);
            }
            else Debug.Log("neglected\n");
        }
        else if (arg1 == "Unlock")
        {
            if (arg2 == "Character")
            {
                Character curchar = (Character)Enum.Parse(typeof(Character), arg3);
                GameObject charObj = StoryManager.instance().characterObj[(int)curchar];
                if (curchar != Character.Opossum)
                {
                    charObj.SetActive(true);
                }
                else
                {
                    StoryManager.instance().crate.SetActive(true);
                }
                
            }
            else if (arg2 == "Home")
            {
                Character curchar = (Character)Enum.Parse(typeof(Character), arg3);
                if (curchar == Character.Mole)
                {
                    World.instance().unlockMole = true;
                    StoryManager.instance().moleHome.SetActive(true);
                }
                else if (curchar == Character.Platypus)
                {
                    World.instance().unlockPlatypus = true;
                    StoryManager.instance().platHome.SetActive(true);
                }
                else if (curchar == Character.Opossum)
                {
                    World.instance().unlockOpossum = true;
                    StoryManager.instance().oppHome.SetActive(true);
                }
            }
            else if (arg2 == "Action")
            {
                if (arg3 == "Fish")
                {
                    StoryManager.instance().fishing.SetActive(true);
                }
                else if (arg3 == "Boat")
                {
                    StoryManager.instance().boat.SetActive(true);
                }
                else Debug.Log("neglected\n");
            }
            else Debug.Log("neglected\n");
        }
        else Debug.Log("neglected\n");
    }
}
