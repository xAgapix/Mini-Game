using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LevelCompleteScript : MonoBehaviour
{
    
    public EnemyAI[] enem; 
    public GameObject LCPanel;
    public PlayerMovement pl;
    public SpriteRenderer sp;
    public ParticleSystem particle;
    public GameObject FailedLevel;
    BoxCollider2D boxCol;
    public RaceRank rankSys;
    public GameObject cam;
    CameraMovement camMov;
    Vector2 tempVec;
    bool failed;
    public Text winCoin;
    //public Text loseCoin;
    GameObject winner;
    AudioManager audioManager;
    int levelIndex;
    public CoinSerDes csd;
    private CoinData coinData;
    void Awake(){
        
        camMov = cam.GetComponent<CameraMovement>();
    }
    void Start(){
        coinData = csd.LoadCoin() as CoinData;

        levelIndex = PlayerPrefs.GetInt("cl",0);
        failed = false;
        audioManager  = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        
        boxCol = GetComponent<BoxCollider2D>();
        LCPanel.SetActive(false);
        FailedLevel.SetActive(false);
        sp.color = new Color(1f,1f,1f,0.2f);
        Vector3 checkpointScale = transform.localScale;
        var sh = particle.shape;
        sh.scale = checkpointScale;
    }
    void Update(){
        if (failed == true){
            camMov.enabled = false;
            tempVec = winner.transform.position;
        cam.transform.position = tempVec;
        }
    }
    void OnTriggerEnter2D (Collider2D col){
        
        

        if (col.tag == "Player"){

            levelIndex += 1;
            PlayerPrefs.SetInt("cl",levelIndex);
            LCPanel.SetActive(true);
            var poof = Instantiate(particle,transform.position,Quaternion.identity);
            audioManager.PlaySound("Victory");
            pl.enabled = false;
            for (int i = 0; i < enem.Length; i++ ){
                enem[i].enabled = false;
            }
            sp.color = new Color(1f,1f,1f,1f);


            /* COIN SYSTEM */
            winCoin.text = CoinsManagerScript.cc.ToString();
            
            
            
            int currentMoney = coinData.coinAmount;
            Debug.Log(currentMoney);
            
            currentMoney += CoinsManagerScript.cc;
            coinData.coinAmount = currentMoney;
            Debug.Log("SaveCoin Accessed");
            csd.SaveCoin(coinData);
            /* COIN SYSTEM */
        }
        
        if (col.tag == "Enemy"){
        winner = col.gameObject;
        
        failed = true;
                FailedLevel.SetActive(true);
                //loseCoin.text = CoinsManagerScript.cc.ToString();
                for (int i = 0; i < enem.Length; i++ ){
                enem[i].enabled = false;
            }
                pl.enabled = false;
            }
        boxCol.enabled = false;
        rankSys.enabled = false;
    }

}
