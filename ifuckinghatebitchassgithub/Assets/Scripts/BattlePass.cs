using UnityEngine;
using TMPro;

public class BattlePass : MonoBehaviour

{
	[Header("SCRIPT MADE BY RATEIX")]
    [Header("DON'T STEAL THIS SCRIPT")]
    [Header("OR YOU'RE A NERD.")]
	
    public TMP_Text levelText;
    public int XPPerLevel = 100;
    public int MaxLevel = 100;

    public Transform[] objectsToEnableAtLevels;

    private int currentLevel = 0;
    private int currentXP = 0;

    private void Start()
    {
        currentXP = PlayerPrefs.GetInt("CurrentXP", 0);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        levelText.text = "Level " + currentLevel.ToString();

        for (int i = 0; i < objectsToEnableAtLevels.Length; i++)
        {
            if (currentLevel >= objectsToEnableAtLevels[i].gameObject.GetComponent<LevelUnlock>().unlockLevel)
            {
                objectsToEnableAtLevels[i].gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Time.time >= PlayerPrefs.GetFloat("LastLevelUpTime", 0) + 1)
        {
            int xpToAdd = Mathf.FloorToInt((Time.time - PlayerPrefs.GetFloat("LastLevelUpTime")) / 1) * XPPerLevel;

            currentXP += xpToAdd;
            PlayerPrefs.SetInt("CurrentXP", currentXP);
            PlayerPrefs.SetFloat("LastLevelUpTime", Time.time);

            UpdateLevel();
        }

        levelText.text = "Level " + currentLevel.ToString();
    }

    private void UpdateLevel()
    {
        int newLevel = Mathf.Clamp(currentXP / XPPerLevel, 0, MaxLevel);
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);

            for (int i = 0; i < objectsToEnableAtLevels.Length; i++)
            {
                if (currentLevel >= objectsToEnableAtLevels[i].gameObject.GetComponent<LevelUnlock>().unlockLevel)
                {
                    objectsToEnableAtLevels[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
