using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuyCosmetic : MonoBehaviour
{
    [SerializeField]
    private int cosmeticNum;
    /*
    public enum Cosmetics { Default, Dolphin, Whale, Galleon };
    [SerializeField]
    private Cosmetics _CosmeticSelected = Cosmetics.Default;
    
    public void PurchaseButton()
    {
        
        switch (_CosmeticSelected)
        {
            case Cosmetics.Dolphin:
                var upgrade = CosmeticManager._Instance.GetComponent<DolphinCosmetic>();
                upgrade.BuyCosmetic();
                break;
            case Cosmetics.Whale:
                var upgrade2 = CosmeticManager._Instance.GetComponent<WhaleCosmetic>();
                upgrade2.BuyCosmetic();
                break;
            case Cosmetics.Galleon:
                var upgrade3 = CosmeticManager._Instance.GetComponent<GalleonCosmetic>();
                upgrade3.BuyCosmetic();
                break;

            default:
                break;
        }

    }
    */
    public void PurchaseButton()
    {
        var cosmeticManager = CosmeticManager._Instance;
        if (cosmeticManager.cosmeticArray[cosmeticNum]._HasBought)
        {
            Debug.Log("Equipped");
            for (int i = 0; i < cosmeticManager.cosmeticArray.Length; i++)
            {
                cosmeticManager.cosmeticArray[i]._IsEquipped = false;
            }
            cosmeticManager.cosmeticArray[cosmeticNum]._IsEquipped = true;
            // GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
            DataManager._Instance._PlayerSprite = cosmeticManager.cosmeticArray[cosmeticNum]._CosmeicSprite;
        }
        else if (DataManager._Instance._CoinAmount >= cosmeticManager.cosmeticArray[cosmeticNum]._ShopCost)
        {
            cosmeticManager.cosmeticArray[cosmeticNum]._HasBought = true;
            DataManager._Instance._CoinAmount -= cosmeticManager.cosmeticArray[cosmeticNum]._ShopCost;
            Debug.Log("Bought");

            PurchaseButton();
        }
        //UpdateButtons();
        var buttonScripts = GameObject.FindGameObjectWithTag("CosmeticButtons").GetComponentsInChildren<BuyCosmetic>();
        for (int i = 0; i < buttonScripts.Length; i++)
        {
            buttonScripts[i].UpdateButtons();
        }

    }

    private void UpdateButtons()
    {
        var cosmeticManager = CosmeticManager._Instance;
        if (!cosmeticManager.cosmeticArray[cosmeticNum]._HasBought)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = cosmeticManager.cosmeticArray[cosmeticNum]._ShopCost.ToString();
        }
        if (cosmeticManager.cosmeticArray[cosmeticNum]._HasBought && !cosmeticManager.cosmeticArray[cosmeticNum]._IsEquipped)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        }
        if (cosmeticManager.cosmeticArray[cosmeticNum]._HasBought && cosmeticManager.cosmeticArray[cosmeticNum]._IsEquipped)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateButtons();
    }
    /*
    private void FixedUpdate()
    {
        var cosmeticManager = CosmeticManager._Instance;

        if (!cosmeticManager.cosmeticArray[cosmeticNum]._HasBought)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Buy: " + cosmeticManager.cosmeticArray[cosmeticNum]._ShopCost;

        }
        if (cosmeticManager.cosmeticArray[cosmeticNum]._HasBought)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        }
        if (cosmeticManager.cosmeticArray[cosmeticNum]._HasBought && cosmeticManager.cosmeticArray[cosmeticNum]._IsEquipped)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
        }
    }
    */
}
