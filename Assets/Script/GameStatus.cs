using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float timeSpeed = 1f;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI texto;
    [SerializeField] bool isAutoplayEnabled;
	// Start is called before the first frame update

	private void Awake()
	{
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            //TextMeshProUGUI texto2 = FindObjectOfType<TextMeshProUGUI>();
            //Destroy(texto2);
            gameObject.SetActive(false);
            Destroy(gameObject);
            
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            //DontDestroyOnLoad(texto);
        }
        
	}
	private void Start()
	{
        AttachText();
	}

    public void AttachText()
    {
        texto = FindObjectOfType<TextMeshProUGUI>();
    }
        // Update is called once per frame
        void Update()
    {
        Time.timeScale = timeSpeed;
        texto.text = "Score : " + score;

    }

	public void Terminate()
	{
        Destroy(gameObject);
	}

	public void AddToScore()
    {
        score++;
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
