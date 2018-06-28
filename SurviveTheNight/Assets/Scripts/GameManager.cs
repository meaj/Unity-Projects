using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {
    private bool isPaused;
    private int levelNum;
    private int playerLives;
    private int playerAmmo;
    private int currentWeapon;
    private int killCount;
    public GameObject userInteface;
    public GameObject pauseMenu;
    public GameObject headsUpDisplay;
    public GameObject gameOverMenu;
    private Text killComp, ammoComp, levelComp, healthComp;
    private GameObject FPSController;
    public bool [] weapon;
    public GameObject hgObject, uzObj, akObj;
    private Animation hgAnim, uzAnim, akAnim;
    private Image hgImg, uzImg, akImg;
    private bool hasStart = false;

    // Use this for initialization
    void Start() {
        isPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        levelNum = 1;
        playerLives = 3;
        playerAmmo = 10;
        killCount = 0;
        currentWeapon = 1;
        weapon = new bool[3] {true, false, false};
    }

    public void Setup() {
        //levelComp = GameObject.Find("Level").GetComponent<Text>();
        healthComp = GameObject.Find("Health").GetComponent<Text>();
        killComp = GameObject.Find("Remaining").GetComponent<Text>();
        ammoComp = GameObject.Find("Ammo").GetComponent<Text>();

        FPSController = GameObject.FindGameObjectWithTag("Player");

        hgImg = GameObject.Find("weapon1").GetComponent<Image>();
        uzImg = GameObject.Find("weapon2").GetComponent<Image>();
        akImg = GameObject.Find("weapon3").GetComponent<Image>();

        hgAnim = hgObject.GetComponent<Animation>();
        uzAnim = hgObject.GetComponent<Animation>();
        akAnim = hgObject.GetComponent<Animation>();

        hgAnim.Stop();
        uzAnim.Stop();
        akAnim.Stop();

        uzImg.gameObject.SetActive(false);
        akImg.gameObject.SetActive(false);


        //levelComp.text = "Level: Dead";
        ammoComp.text = "Ammo: " + playerAmmo.ToString();
        killComp.text = string.Format("{0}" + "{1}", levelNum.ToString() + " : ", killCount.ToString());
        healthComp.text = "HP: " + playerLives.ToString();

        if (hasStart == false)
            hasStart = true;
        if (isPaused == true)
            isPaused = false;
        print("Game Started!");
        AddAmmo(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void playShot(int idx) {
        if (idx == 1)
            hgAnim.Play();
        else if (idx == 2)
            uzAnim.Play();
        else if (idx == 3)
            akAnim.Play();
        
    }

    // Update is called once per frame
    // TODO: Check for pause button press
    // TODO: Check level number for win condition
    // TODO: Check life number for loose condition
    // TODO: Check '1','2',or'3' button press for weapon choice and display if picked up
    void Update() {
        if (hasStart == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
                PauseGame();

            if (killCount == 0)
            {
                levelNum += 1;
                //killCount = 10 + (levelNum-1) * 5;
            }

            if (weapon[0] == true)
                hgImg.gameObject.SetActive(true);
            else
                hgImg.gameObject.SetActive(false);

            if (weapon[1] == true)
                uzImg.gameObject.SetActive(true);
            else
                uzImg.gameObject.SetActive(false);

            if (weapon[2] == true)
                akImg.gameObject.SetActive(true);
            else
                akImg.gameObject.SetActive(false);

            if (Input.GetKeyUp(KeyCode.Alpha1) && weapon[0] == true)
            {
                print("Weapon 1 selected");
                currentWeapon = 1;
                uzObj.SetActive(false);
                hgObject.SetActive(true);
                akObj.SetActive(false);

            }
            if (Input.GetKeyUp(KeyCode.Alpha2) && weapon[1] == true)
            {
                print("Weapon 2 selected");
                currentWeapon = 2;
                uzObj.SetActive(true);
                hgObject.SetActive(false);
                akObj.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Alpha3) && weapon[2] == true)
            {
                print("Weapon 3 selected");
                currentWeapon = 3;
                uzObj.SetActive(false);
                hgObject.SetActive(false);
                akObj.SetActive(true);
            }

            //levelComp.text = "Level: Dead";
            ammoComp.text = "Ammo: " + playerAmmo.ToString();
            killComp.text = string.Format("{0}" + "{1}", levelNum.ToString() + " : ", killCount.ToString());
            healthComp.text = "HP: " + playerLives.ToString();

            if (playerLives < 0)
            {
                //show game over screen
                if (isPaused == false)
                    isPaused = true;
                gameOverMenu.SetActive(true);
                headsUpDisplay.SetActive(false);
            }
        }
    }

    public int GetDamage() {
        return currentWeapon;
    }

    public void AddKillCount(int i) {
        killCount += i;
    }

    public void AddKill() {
        killCount--;
    }

    public int GetKills() {
        return killCount;
    }

    // returns the value of isPaused
    public bool GetPaused() {
        return isPaused;
    }

    // pauses game if unpaused
    public void PauseGame() {
        if (isPaused == false)
            isPaused = true;
        print("Game Paused!");
        pauseMenu.SetActive(true);
        headsUpDisplay.SetActive(false);
        FPSController.GetComponent<CharacterController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //FPSController.GetComponent<MouseLook>().XSensitivity = 0;
        //FPSController.GetComponent<MouseLook>().YSensitivity = 0;
    }

    // resumes game if paused
    public void ResumeGame() {
        if (hasStart == false)
            hasStart = true;
        if (isPaused == true)
            isPaused = false;
        print("Game Resumed!");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FPSController.GetComponent<CharacterController>().enabled = true;
        //FPSController.GetComponent<MouseLook>().XSensitivity = 1;
        //FPSController.GetComponent<MouseLook>().YSensitivity = 1;
        AddAmmo(1);
    }

    // returns the current level
    public int GetLevel() {
        return levelNum;
    }

    // changes level to input
    public void UpdateLevel(int l) {
        levelNum = l;
    }

    // increases level by one
    public void IncreaseLevel() {
        levelNum++;
    }

    // returns the number of player lives
    public int GetLives()
    {
        return playerLives;
    }

    // decrease lives by i    
    public void TakeLife(int i) {
        playerLives-=i;
    }

    // incresase lives by i
    public void GiveLife(int i) {
        playerLives+=i;
    }

    public void AddAmmo(int i) {
        playerAmmo += i;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UseAmmo() {
        if(playerAmmo>=1)
            playerAmmo--;
    }

    public int GetAmmo() {
        return playerAmmo;
    }
}
