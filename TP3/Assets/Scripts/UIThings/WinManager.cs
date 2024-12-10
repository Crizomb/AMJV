using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventBus.WinEvent.AddListener(OnWin);
    }

    void OnWin(float time)
    {
        uiCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(true);
        int minute = (int)time / 60;
        int secondes = (int)time % 60;
        scoreText.text = $"Time : {minute} min {secondes}s";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
