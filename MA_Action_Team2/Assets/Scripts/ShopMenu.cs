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
      public GameObject item4BuyButton;
      public int item1Cost = 1;
      public int item2Cost = 2;
      public int item3Cost = 4;
      public int item4Cost = 8;
      //public AudioSource KaChingSFX;

      void Start (){
            shopMenuUI.SetActive(false);
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

      void Update (){
            if ((GameHandler.gotMutagens >= item1Cost) && (GameHandler.mutation1active == false)) {
                        item1BuyButton.SetActive(true);}
            else { item1BuyButton.SetActive(false);}

            if ((GameHandler.gotMutagens >= item2Cost) && (GameHandler.mutation2active == false)) {
                        item2BuyButton.SetActive(true);}
            else { item2BuyButton.SetActive(false);}

            if ((GameHandler.gotMutagens >= item3Cost) && (GameHandler.mutation3active == false)) {
                        item3BuyButton.SetActive(true);}
            else { item3BuyButton.SetActive(false);}
			
			if ((GameHandler.gotMutagens >= item4Cost) && (GameHandler.mutation4active == false)) {
                        item4BuyButton.SetActive(true);}
            else { item4BuyButton.SetActive(false);}
			
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
            gameHandler.playerGetMutagens((item1Cost * -1));
            GameHandler.mutation1active = true;
            //KaChingSFX.Play();
			
			GameHandler.mutation2active = false;
			GameHandler.mutation3active = false;
			GameHandler.mutation4active = false;
			
      }

      public void Button_BuyItem2(){
            gameHandler.playerGetMutagens((item2Cost * -1));
            GameHandler.mutation2active = true;
            //KaChingSFX.Play();
			
			GameHandler.mutation1active = false;
			GameHandler.mutation3active = false;
			GameHandler.mutation4active = false;
      }

      public void Button_BuyItem3(){
            gameHandler.playerGetMutagens((item3Cost * -1));
            GameHandler.mutation3active = true;
            //KaChingSFX.Play();
			
			GameHandler.mutation1active = false;
			GameHandler.mutation2active = false;
			GameHandler.mutation4active = false;
      }


      public void Button_BuyItem4(){
            gameHandler.playerGetMutagens((item4Cost * -1));
            GameHandler.mutation4active = true;
            //KaChingSFX.Play();
			
			GameHandler.mutation1active = false;
			GameHandler.mutation2active = false;
			GameHandler.mutation3active = false;
			
      }

}
