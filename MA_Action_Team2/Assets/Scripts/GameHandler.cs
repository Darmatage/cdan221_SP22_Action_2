using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

    public static bool mutation1enabled = false; // Head lamp
    public static bool mutation2enabled = false; // Octopus legs
    public static bool mutation3enabled = false; // Shark teeth
    public static bool mutation4enabled = false; // Poison dart / range attack

    public static bool mutation1active = false; // Head lamp
    public static bool mutation2active = false; // Octopus legs
    public static bool mutation3active = false; // Shark teeth
    public static bool mutation4active = false; // Poison dart / range attack

	//need stamina mechanic for using mutation?
	public static float mutationStamina = 100f;

    private GameObject player;
	
    public static int playerHealth = 100;
    public int StartPlayerHealth = 100;
    public GameObject healthText;
	public static int gotMutagens = 0;
	public int startMutagens = 100;
    public GameObject tokensText;
    public bool isDefending = false;
    public static bool stairCaseUnlocked = false;
    //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;
	private string sceneName;

	//Pause Menus
	public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;
    
	
	//TakeDamage
	 public static int MaxHealth = 100;
     public static int CurrentHealth = 100;

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
				  gotMutagens = startMutagens;
            //}
            updateStatsDisplay();
      }
    
	void Update (){
		
		if (mutation1active==false){
			player.GetComponentInChildren<SpriteMask>().enabled = false;
		} else {
			player.GetComponentInChildren<SpriteMask>().enabled = true;
		}
		
		
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

	public void playerGetMutagens(int newMutes){
		gotMutagens += newMutes;
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
			updateStatsDisplay();
		}
	}

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "Health: " + playerHealth;

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "Mutagens: " + gotMutagens;
      }
      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
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
	  
	   public void TakeDamage(int damage){
              CurrentHealth -= damage;
              UpdateHealth();
              sceneName = SceneManager.GetActiveScene().name;
              if (CurrentHealth >= MaxHealth){CurrentHealth = MaxHealth;}
              if ((CurrentHealth <= 0) && (sceneName != "EndLose")){
                     SceneManager.LoadScene("EndLose");
              }
       }

       public void UpdateHealth(){
              Text healthTextB = healthText.GetComponent<Text>();
              healthTextB.text = "Current Health: " + CurrentHealth + "\n Max Health: " + MaxHealth;
       }
}
