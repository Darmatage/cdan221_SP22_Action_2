using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

    public static bool mutation1enabled = false; // Head lamp
    public static bool mutation2enabled = false; // Shark teeth
    public static bool mutation3enabled = false; // Octopus legs
    public static bool mutation4enabled = false; // RockFish Poison dart / range attack

    public static bool mutation1active = false; 
    public static bool mutation2active = false; 
    public static bool mutation3active = false; 
    public static bool mutation4active = false; 

	public GameObject mutationIcon1;
	public GameObject mutationIcon2;
	public GameObject mutationIcon3;
	public GameObject mutationIcon4;

	//need stamina mechanic for using mutation?
	public static float mutationStamina = 100f;

    public GameObject player;
	public static Animator CurrentPlayerAnimator;
	
    public static int playerHealth = 100;
    public int maxHealth = 100;
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


	void Awake (){
		SetLevel (volumeLevel);
		player = GameObject.FindWithTag("Player");
		
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null){
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
	}
	void Start(){
		mutationIcon1.SetActive(false);
		mutationIcon2.SetActive(false);
		mutationIcon3.SetActive(false);
		mutationIcon4.SetActive(false);
		
		CurrentPlayerAnimator = player.GetComponent<PlayerMove>().p0anim;
		
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
            
		sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
		playerHealth = maxHealth;
		gotMutagens = startMutagens;
            //}
		updateStatsDisplay();
      }
    
	void Update (){
		
		//Power Icons:
		if (mutation1enabled == true){mutationIcon1.SetActive(true);}
		if (mutation2enabled == true){mutationIcon2.SetActive(true);}
		if (mutation3enabled == true){mutationIcon3.SetActive(true);}
		if (mutation4enabled == true){mutationIcon4.SetActive(true);}
		
		//power #1: enable SpriteMask to see in the dark
		if (mutation1active==false){
			player.GetComponentInChildren<SpriteMask>().enabled = false;
		} else {
			player.GetComponentInChildren<SpriteMask>().enabled = true;
		}
		
		//pause menu
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
			if (playerHealth >= maxHealth){playerHealth = maxHealth;}
			if (playerHealth >=0){updateStatsDisplay();}
			if (damage > 0){player.GetComponent<PlayerHurt>().playerHit();}
		}

		sceneName = SceneManager.GetActiveScene().name;
		if ((playerHealth <= 0) && (sceneName != "SceneLose")){
			SceneManager.LoadScene("SceneLose");
		}

		// if (playerHealth >= StartPlayerHealth){
			// playerHealth = StartPlayerHealth;
			// updateStatsDisplay();
		// }
	}

	// public void UpdateHealth(){
              // Text healthTextB = healthText.GetComponent<Text>();
              // healthTextB.text = "Health: " + playerHealth + "\n Max Health: " + maxHealth;
	// }


	public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "Health: " + playerHealth;

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "Mutations: " + gotMutagens;
      }
      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

	IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("SceneLose");
      }
	  
      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void RestartGame() {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            playerHealth = maxHealth;
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
