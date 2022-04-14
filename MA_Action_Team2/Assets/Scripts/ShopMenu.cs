using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Audio;

public class ShopMenu : MonoBehaviour{

      public GameHandler gameHandler;
      public static bool ShopisOpen = false;
      public GameObject shopMenuUI;
      public GameObject buttonOpenShop;
      public GameObject item1BuyButton;
      public GameObject item2BuyButton;
      public GameObject item3BuyButton;
      public int item1Cost = 5;
      public int item2Cost = 6;
      public int item3Cost = 2;
      public static bool gotitem1 = false;
      public static bool gotitem2 = false;
      public static bool gotitem3 = false;
      //public AudioSource KaChingSFX;

      void Start (){
            shopMenuUI.SetActive(false);
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

      void Update (){
            if ((GameHandler.gotTokens >= item1Cost) && (GameHandler.gotitem1 == false)) {
                        item1BuyButton.SetActive(true);}
            else { item1BuyButton.SetActive(false);}

            if ((GameHandler.gotTokens >= item2Cost) && (GameHandler.gotitem2 == false)) {
                        item2BuyButton.SetActive(true);}
            else { item2BuyButton.SetActive(false);}

            if ((GameHandler.gotTokens >= item3Cost) && (GameHandler.gotitem3 == false)) {
                        item3BuyButton.SetActive(true);}
            else { item3BuyButton.SetActive(false);}
      }

      //Button Functions:
      public void Button_OpenShop(){
           shopMenuUI.SetActive(true);
           buttonOpenShop.SetActive(false);
           ShopisOpen = true;
           Time.timeScale = 0f;
      }

      public void Button_CloseShop() {
           shopMenuUI.SetActive(false);
           buttonOpenShop.SetActive(true);
           ShopisOpen = false;
           Time.timeScale = 1f;
      }

      public void Button_BuyItem1(){
            gameHandler.playerGetTokens((item1Cost * -5));
            GameHandler.gotitem1 = true;
            //KaChingSFX.Play();
      }

      public void Button_BuyItem2(){
            gameHandler.playerGetTokens((item2Cost * -6));
            GameHandler.gotitem2 = true;
            //KaChingSFX.Play();
      }

      public void Button_BuyItem3(){
            gameHandler.playerGetTokens((item3Cost * -2));
            GameHandler.gotitem3 = true;
            //KaChingSFX.Play();
      }


}
