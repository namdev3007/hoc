using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkinShop : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Image[] imageBnt;
    public Image previewImage;
    public GameObject[] lockIcons;

    public GameObject bntBuySkin;
    public GameObject notification;

    private bool isSkinPurchased = false;

    void Start()
    {
        // Loop through each button image
        for (int i = 0; i < imageBnt.Length; i++)
        {
            int characterIndex = i ; // Capture the index in a local variable for the event listener

            // Check if the index is within the character database length
            if (characterIndex < characterDB.CharacterCount)
            {
                // Get the character from the database
                Character character = characterDB.GetCharacter(characterIndex);

                // Check if the character has a sprite assigned
                if (character.characterSprite != null)
                {
                    // Set the sprite to the button image
                    imageBnt[characterIndex].sprite = character.characterSprite;

                    // Add a click event listener to the button image
                    imageBnt[characterIndex].GetComponent<Button>().onClick.AddListener(() => OnCharacterButtonClicked(characterIndex));

                    // Check if the character is unlocked, if unlocked, disable the lock icon
                    if (character.unlocked)
                    {
                        if (lockIcons != null && lockIcons.Length > characterIndex && lockIcons[characterIndex] != null)
                        {
                            lockIcons[characterIndex].SetActive(false);
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 5 && i < characterDB.CharacterCount; i++)
        {
            if (characterDB.characters[i].unlocked)
            {
                // If any of the first 5 characters is unlocked, set isSkinPurchased to true
                isSkinPurchased = true;
                break;
            }
        }

        // If skin is purchased, deactivate the buy skin button
        if (isSkinPurchased)
        {
            bntBuySkin.SetActive(false);
        }

    }

    // Method to handle character button click
    private void OnCharacterButtonClicked(int characterIndex)
    {
        // Get the character from the database
        Character selectedCharacter = characterDB.GetCharacter(characterIndex);

        // Set the sprite of the preview image to the selected character's sprite
        previewImage.sprite = selectedCharacter.characterSprite;
    }

    public void OnBuyPremiumSkinClicked()
    {
        // Loop through the first 5 characters in the database
        for (int i = 0; i < 5 && i < characterDB.CharacterCount; i++)
        {
            // Mark the character as unlocked
            characterDB.characters[i].unlocked = true;

            // Update the button image for the unlocked character
            if (lockIcons != null && lockIcons.Length > i && lockIcons[i] != null)
            {
                lockIcons[i].SetActive(false);
            }
        }
        NotificationManager.instance.ActivateNotificationTrigger();
        // Set isSkinPurchased to true after purchasing
        isSkinPurchased = true;

        // Deactivate the buy skin button
        bntBuySkin.SetActive(false);

        StartCoroutine(TurnOffButtonAfterDelay());
    }

    private IEnumerator TurnOffButtonAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Đợi 3 giây

        notification.SetActive(false);
    }

}
