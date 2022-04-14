using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

  public static int playerStat;

         public static bool GameisPaused = false;
         public GameObject pauseMenuUI;
         public AudioMixer mixer;
         public static float volumeLevel = 1.0f;
         private Slider sliderVolumeCtrl;
         private GameObject player;
         public static int playerHealth = 100;
         public int StartPlayerHealth = 100;
         public GameObject healthText;
         public static int gotTokens = 0;
         public GameObject tokensText;
         public bool isDefending = false;
         public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;
        private string sceneName;

        void Awake (){
                        SetLevel (volumeLevel);
                        GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                        if (sliderTemp != null){
                                sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                                sliderVolumeCtrl.value = volumeLevel;
                        }
                      }
      void Start(){
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
            player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            //}
            updateStatsDisplay();
      }
      void Update (){
                      if (Input.GetKeyDown(KeyCode.Escape)){
                              if (GameisPaused){
                                      Resume();
                              }
                              else{
                                      Pause();
                              }
                      }
              }

    void Pause(){
     pauseMenuUI.SetActive(true);
     Time.timeScale = 0f;
     GameisPaused = true;
       }

       public void Resume(){
               pauseMenuUI.SetActive(false);
               Time.timeScale = 1f;
               GameisPaused = false;
       }

       public void SetLevel (float sliderValue){
               mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
               volumeLevel = sliderValue;
       }
      public void playerGetTokens(int newTokens){
            gotTokens += newTokens;
            updateStatsDisplay();
      }

      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage;
                  if (playerHealth >=0){
                        updateStatsDisplay();
                  }
                  player.GetComponent<PlayerHurt>().playerHit();
            }

           if (playerHealth >= StartPlayerHealth){
                  playerHealth = StartPlayerHealth;
            }
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth;

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "GOLD: " + gotTokens;
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void RestartGame() {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            playerHealth = StartPlayerHealth;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}
