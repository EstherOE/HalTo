using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

    }
    public static int playerHP = 100;
    public TextMeshProUGUI playerHPText;
    public GameObject bloodOverlay;
    public string sceneLevel;
    public  bool isGameOver;
    void Start()
    {
        isGameOver = false;
        playerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene(sceneLevel);
        }
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        bloodOverlay.SetActive(true);
        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;

        yield return new WaitForSeconds(1);
        bloodOverlay.SetActive(false);
    }

    }
