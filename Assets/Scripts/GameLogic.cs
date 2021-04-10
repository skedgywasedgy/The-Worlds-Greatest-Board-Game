using Cinemachine;
using System.Collections;
using UnityEngine;

namespace GreatestBoardGame {
    public class GameLogic : MonoBehaviour {
        public Pawn player1Pawn;
        public Die die;
        public CinemachineBrain cinemachineBrain;
        public CinemachineVirtualCamera dieCamera;
        public CinemachineVirtualCamera player1Camera;

        private void Start () {
            StartCoroutine (mainLogic ());
        }

        public void OnFire () {
            if (die.preRoll) {
                die.Roll ();
            }
        }

        private IEnumerator mainLogic () {
            while (true) {
                dieCamera.gameObject.SetActive (true);
                die.StartPreRoll ();
                yield return null;
                yield return new WaitUntil (() => die.still);
                dieCamera.gameObject.SetActive (false);
                player1Camera.gameObject.SetActive (true);
                yield return new WaitForSeconds (0.5f);
                player1Pawn.Advance (die.value);
                yield return new WaitUntil (() => !player1Pawn.moving);
                yield return new WaitForSeconds (1);
                player1Camera.gameObject.SetActive (false);
            }
        }
    }
}