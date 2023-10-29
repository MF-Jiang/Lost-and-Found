using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance = null;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject TimeOutPanel;
    private Scene scene;
    private bool inTimeOut = false;

    private AudioSource aSource;


    public AudioClip backGroundMusic;
    public AudioClip winAudio;
    public AudioClip loseAudio;


    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        if (backGroundMusic != null)
        {
            aSource.clip = backGroundMusic;
            aSource.Play();
        }
        scene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && scene.name != "Menu" && scene.name != "Setting" && inTimeOut == false)
        {

            TimeOutGame();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && scene.name != "Menu" && scene.name != "Setting" && inTimeOut == true)
        {
            ContinueTimeGame();
            return;
        }

        //检测场景名称是不是Scene1、2、3、4、5
        if (scene.name == "Scene1" || scene.name == "Scene2" || scene.name == "Scene3" || scene.name == "Scene4" || scene.name == "Scene5")
        {
            //检测场景中是否有Player
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                //执行GameOver函数
                GameOver(false);
            }
        }

    }

    public void GameOver(bool playerWin)
    {
        StartCoroutine(DelayGameOver(playerWin));
    }

    IEnumerator DelayGameOver(bool playerWin)
    {
        yield return new WaitForSeconds(0.5f);
        if (playerWin)
        {
            if (winAudio != null)
            {
                aSource.clip = winAudio;
                aSource.Play();
            }
            winPanel.SetActive(true);

        }
        else
        {
            if (loseAudio != null)
            {
                aSource.clip = loseAudio;
                aSource.Play();
            }
            losePanel.SetActive(true);
        }
        Time.timeScale = 0;

    }

    public void LoadNextLevel(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TimeOutGame()
    {

        inTimeOut = true;

        TimeOutPanel.SetActive(true);

        Time.timeScale = 0;


    }

    public void ContinueTimeGame()
    {

        inTimeOut = false;
        TimeOutPanel.SetActive(false);
        Time.timeScale = 1;

    }
}
