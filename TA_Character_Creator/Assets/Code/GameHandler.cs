using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour
{
    //public GameObject textGameObject;

        //void Start () { UpdateScore (); }

        void Update(){         //delete this quit functionality when a Pause Menu is added
                if (Input.GetKey("escape")){
                        QuitGame();
                }
        }

        //void UpdateScore () {
        //        Text scoreTemp = textGameObject.GetComponent<Text>();
        //        scoreTemp.text = "Score: " + score; }

        public void StartGame(){
                SceneManager.LoadScene("MainScene");
        }

        public void SkinScene(){
                SceneManager.LoadScene("MainScene");
        }

        public void HairScene(){
                SceneManager.LoadScene("HairScene");
        }

        public void FinishScene(){
                SceneManager.LoadScene("FinishScene");
        }

        public void ShirtScene(){
                SceneManager.LoadScene("ShirtScene");
        }

        public void EyeScene(){
                SceneManager.LoadScene("EyeScene");
        }

        public void AccessoryScene(){
                SceneManager.LoadScene("AccessoryScene");
        }

        public void RestartGame(){
                SceneManager.LoadScene("MainScene");
        }

        public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}
