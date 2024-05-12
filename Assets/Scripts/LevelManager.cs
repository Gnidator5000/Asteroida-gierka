using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    
    Transform player;
    //odleg³oœc od koñca poziomu
    public float levelExitDistance = 100;
    //punkt koñca poziomu
    public Vector3 exitPosition;
    public GameObject exitPrefab;
    //zmienna - flaga - oznaczaj¹ca ukoñczenie poziomu
    public bool levelComplete = false;
    //taka sama zmienna tylko jeœli przegramy
    public bool levelFailed = false;
    // Start is called before the first frame update
    void Start()
    {
        //znajdz gracza
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //wylosuj pozycjê na kole o œrednicy 100 jednostek
        Vector2 spawnCircle = Random.insideUnitCircle; //losowa pozycja x,y wewn¹trz ko³a o r=1
        //chcemy tylko pozycjê na okrêgu, a nie wewn¹trz ko³a
        spawnCircle = spawnCircle.normalized; //pozycje x,y w odleg³oœci 1 od œrodka
        spawnCircle *= levelExitDistance; //pozycja x,y w odleg³oœci 100 od œrodka
        //konwertujemy do Vector3
        //podstawiamy: x=x, y=0, z=y
        exitPosition = new Vector3(spawnCircle.x, 0, spawnCircle.y);
        Instantiate(exitPrefab, exitPosition, Quaternion.identity);

        //wystartuj czas
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //funkcja jest uruchamiana kiedy dany poziom (level) jest zakoñczony sukcesem 
    public void OnSuccess()
    {
        //zatrzymaj fizykê gry
        Time.timeScale = 0f;
        //ustaw flagê - poziom zakoñczony
        levelComplete = true;
        //zatrzymaj ambientowa muzyczke
        Camera.main.transform.Find("AmbientMusic").GetComponent<AudioSource>().Stop();
        //odegraj dŸwiêk koñca poziomu
        Camera.main.transform.Find("LevelCompleteSound").GetComponent<AudioSource>().Play();
    }
    //funkcja jest uruchamiana kiedy dany poziom (level) jest zakoñczony pora¿k¹
    public void OnFailure()
    {
        //zatrzymaj fizyke
        Time.timeScale = 0f;
        //ustaw flage, ze nie udalo sie ukonczyc poziomu
        levelFailed = true;
        //zatrzymaj ambientowa muzyczke
        Camera.main.transform.Find("AmbientMusic").GetComponent<AudioSource>().Stop();
        //odgrywmay dzwiek przegranej
        Camera.main.transform.Find("GameOverSound").GetComponent<AudioSource>().Play();

    }
}  
