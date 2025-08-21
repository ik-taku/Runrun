using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meterText;
    [SerializeField] TextMeshProUGUI gameoverText;
    [SerializeField] TextMeshProUGUI gameoverMeterText;

    private int meter = 0;
    private float time = 0;
    private PlayerController playerController;

    public static UIController instance;

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        meterText.text = "0 m";

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.1f)
        {
            if (!playerController.isGameover)
            {
                meter += 1;
            }
            time = 0;
        }

        meterText.text = meter + " m";
    }

    public void Gameover()
    {
        gameoverText.gameObject.SetActive(true);
        gameoverMeterText.gameObject.SetActive(true);
        gameoverMeterText.text = "Your final distance is ...." + meter + " m";
        Invoke("Restart", 2.0f);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
