using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }
    //ta funkcja powoduje dzialajacy przycisk po porazce
    public void RestartGame()
    {
            
    //pobiera akutalny poziom 
    Scene scene = SceneManager.GetActiveScene();
    //uruchamia poziom odczytany linijke wyzej
    SceneManager.LoadScene(scene.name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    //ta funkcja powoduje dzialajacy przycisk nastepnego poziomu
    public void GoToNextLevel()
    {

        //pobiera aktualny poziom
        Scene scene = SceneManager.GetActiveScene();
        //usuwa text Level z aktualnej sceny pozostawiajac tylko numer poziomu + zmiana na liczbe 
        int levelNo = int.Parse(scene.name.Replace("Level", ""));
        //uruchomienie nastepnego poziomu czyli dodanie 1 do wczesniej odczytanej liczby

    if(levelNo == 5 )
    {
        SceneManager.LoadScene("End");
    } else {
         SceneManager.LoadScene("Level" + (levelNo + 1).ToString());
    }}
}
