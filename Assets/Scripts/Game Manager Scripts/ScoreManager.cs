using UnityEngine;
using TMPro;                         // or UnityEngine.UI if you use a built‑in Text
using System.Collections;
using UnityEngine.SceneManagement;  

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;   // singleton reference
    public int Score { get; private set; }

    [Header("UI")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] CanvasGroup flashGroup;     // a CanvasGroup that holds the “Point Scored!” text
    [SerializeField] float flashTime = 5f;

    void Awake()
    {
        // make this object survive scene changes
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else                  
        {
            Destroy(gameObject); 
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => UpdateUI();
    public void AddPoint()
    {
        Score++;
        UpdateUI();
        StartCoroutine(FlashRoutine());
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    // Try to re-link UI in the new scene
        scoreText = FindObjectOfType<TextMeshProUGUI>(); // Or use tags/names if multiple texts
        flashGroup = GameObject.Find("FlashGroup")?.GetComponent<CanvasGroup>();

    UpdateUI();
    }
    /* --- helpers --- */
    void UpdateUI() => scoreText.text = $"Cheese: {Score}";

    IEnumerator FlashRoutine()
    {
        flashGroup.alpha = 1;            // fully visible
        yield return new WaitForSeconds(flashTime);
        flashGroup.alpha = 0;            // hide again
    }
}
