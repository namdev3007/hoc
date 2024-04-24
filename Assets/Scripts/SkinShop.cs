using UnityEngine;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    public CoinsManager coinsManager;
    public CharacterDatabase characterDatabase;

    public Image[] imageSkin;
    public Image previewSkin;

    private int selectedSkinIndex = 0;
    private int coinCost = 20000;

    private void Awake()
    {
        coinsManager = GameObject.FindFirstObjectByType<CoinsManager>();
        characterDatabase = GameObject.FindFirstObjectByType<CharacterDatabase>();
    }

    private void Start()
    {
        UpdatePreviewSkin();
    }

    private void UpdatePreviewSkin()
    {
        Character character = characterDatabase.GetCharacter(selectedSkinIndex);
        previewSkin.sprite = character.characterSprite;
    }


    public void SelectSkin(int index)
    {
        selectedSkinIndex = index;
        UpdatePreviewSkin();
    }

    public void BuySkin()
    {
        if (coinsManager.coinCount >= coinCost)
        {
            coinsManager.SpendCoins(coinCost);
            Character character = characterDatabase.GetCharacter(selectedSkinIndex);
            character.unlocked = true;
        }
    }
}
