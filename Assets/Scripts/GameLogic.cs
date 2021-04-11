using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;

namespace GreatestBoardGame {
    public class GameLogic : MonoBehaviour {
        public Pawn player1Pawn;
        public Pawn player2Pawn;
        public Pawn player3Pawn;
        public Pawn player4Pawn;
        public Die die;
        public Die die2;
        public CinemachineBrain cinemachineBrain;
        public CinemachineVirtualCamera dieCamera;
        public CinemachineVirtualCamera player1Camera;
        public CinemachineVirtualCamera player2Camera;
        public CinemachineVirtualCamera player3Camera;
        public CinemachineVirtualCamera player4Camera;

        private int winners = 0;
        private int player1score = 0;
        private int player2score = 0;
        private int player3score = 0;
        private int player4score = 0;

        public TextMeshProUGUI text;

        private void Start () {
            StartCoroutine (mainLogic ());
        }

        public void OnFire () {
            if (die.preRoll) {
                die.Roll ();
                die2.Roll ();
            }
        }

        public int GetScore () {
            switch (winners) {
                case 0:
                    return 10;
                case 1:
                    return 6;
                case 2:
                    return 3;
                default:
                    return 0;
            }
        }

        private void Update () {
            text.text = "King: " + player1score + "\nBurger: " + player2score + "\nHotdog: " + player3score + "\nQueen: " + player4score;
        }

        private IEnumerator mainLogic () {
            while (true) {
                if (!player1Pawn.wonGame) {
                    do {
                        dieCamera.gameObject.SetActive (true);
                        die.StartPreRoll (player1Pawn.currentPath.spaces[player1Pawn.currentSpace].diePos);
                        die2.StartPreRoll (player1Pawn.currentPath.spaces[player1Pawn.currentSpace].diePos);
                        yield return null;
                        yield return new WaitUntil (() => die.still && die2.still);
                        dieCamera.gameObject.SetActive (false);
                        player1Camera.gameObject.SetActive (true);
                        yield return new WaitForSeconds (0.5f);
                        player1Pawn.Advance (die.value + die2.value);
                        yield return new WaitUntil (() => !player1Pawn.moving);
                        yield return new WaitForSeconds (1);
                        player1Camera.gameObject.SetActive (false);

                        int scoreChange = player1Pawn.currentPath.spaces[player1Pawn.currentSpace].score;

                        if (scoreChange > 0) {
                            for (int i = 0; i < scoreChange; i++) {
                                player1score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                        } else if (scoreChange < 0) {
                            for (int i = 0; i < Mathf.Abs (scoreChange); i++) {
                                player1score--;
                                yield return new WaitForSeconds (0.25f);
                            }
                        }

                        if (player1Pawn.wonGame) {
                            scoreChange = GetScore ();
                            for (int i = 0; i < scoreChange; i++) {
                                player1score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                            break;
                        }
                    } while (die.value == die2.value);
                }

                if (!player2Pawn.wonGame) {
                    do {
                        dieCamera.gameObject.SetActive (true);
                        die.StartPreRoll (player2Pawn.currentPath.spaces[player2Pawn.currentSpace].diePos);
                        die2.StartPreRoll (player2Pawn.currentPath.spaces[player2Pawn.currentSpace].diePos);
                        yield return null;
                        yield return new WaitUntil (() => die.still && die2.still);
                        dieCamera.gameObject.SetActive (false);
                        player2Camera.gameObject.SetActive (true);
                        yield return new WaitForSeconds (0.5f);
                        player2Pawn.Advance (die.value + die2.value);
                        yield return new WaitUntil (() => !player2Pawn.moving);
                        yield return new WaitForSeconds (1);
                        player2Camera.gameObject.SetActive (false);

                        int scoreChange = player2Pawn.currentPath.spaces[player2Pawn.currentSpace].score;

                        if (scoreChange > 0) {
                            for (int i = 0; i < scoreChange; i++) {
                                player2score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                        } else if (scoreChange < 0) {
                            for (int i = 0; i < Mathf.Abs (scoreChange); i++) {
                                player2score--;
                                yield return new WaitForSeconds (0.25f);
                            }
                        }

                        if (player2Pawn.wonGame) {
                            scoreChange = GetScore ();
                            for (int i = 0; i < scoreChange; i++) {
                                player2score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                            break;
                        }
                    } while (die.value == die2.value);
                }

                if (!player3Pawn.wonGame) {
                    do {
                        dieCamera.gameObject.SetActive (true);
                        die.StartPreRoll (player3Pawn.currentPath.spaces[player3Pawn.currentSpace].diePos);
                        die2.StartPreRoll (player3Pawn.currentPath.spaces[player3Pawn.currentSpace].diePos);
                        yield return null;
                        yield return new WaitUntil (() => die.still && die2.still);
                        dieCamera.gameObject.SetActive (false);
                        player3Camera.gameObject.SetActive (true);
                        yield return new WaitForSeconds (0.5f);
                        player3Pawn.Advance (die.value + die2.value);
                        yield return new WaitUntil (() => !player3Pawn.moving);
                        yield return new WaitForSeconds (1);
                        player3Camera.gameObject.SetActive (false);

                        int scoreChange = player3Pawn.currentPath.spaces[player3Pawn.currentSpace].score;

                        if (scoreChange > 0) {
                            for (int i = 0; i < scoreChange; i++) {
                                player3score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                        } else if (scoreChange < 0) {
                            for (int i = 0; i < Mathf.Abs (scoreChange); i++) {
                                player3score--;
                                yield return new WaitForSeconds (0.25f);
                            }
                        }

                        if (player3Pawn.wonGame) {
                            scoreChange = GetScore ();
                            for (int i = 0; i < scoreChange; i++) {
                                player3score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                            break;
                        }
                    } while (die.value == die2.value);
                }

                if (!player4Pawn.wonGame) {
                    do {
                        dieCamera.gameObject.SetActive (true);
                        die.StartPreRoll (player4Pawn.currentPath.spaces[player4Pawn.currentSpace].diePos);
                        die2.StartPreRoll (player4Pawn.currentPath.spaces[player4Pawn.currentSpace].diePos);
                        yield return null;
                        yield return new WaitUntil (() => die.still && die2.still);
                        dieCamera.gameObject.SetActive (false);
                        player4Camera.gameObject.SetActive (true);
                        yield return new WaitForSeconds (0.5f);
                        player4Pawn.Advance (die.value + die2.value);
                        yield return new WaitUntil (() => !player4Pawn.moving);
                        yield return new WaitForSeconds (1);
                        player4Camera.gameObject.SetActive (false);

                        int scoreChange = player4Pawn.currentPath.spaces[player4Pawn.currentSpace].score;

                        if (scoreChange > 0) {
                            for (int i = 0; i < scoreChange; i++) {
                                player4score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                        } else if (scoreChange < 0) {
                            for (int i = 0; i < Mathf.Abs (scoreChange); i++) {
                                player4score--;
                                yield return new WaitForSeconds (0.25f);
                            }
                        }

                        if (player4Pawn.wonGame) {
                            scoreChange = GetScore ();
                            for (int i = 0; i < scoreChange; i++) {
                                player4score++;
                                yield return new WaitForSeconds (0.25f);
                            }
                            break;
                        }
                    } while (die.value == die2.value);
                }

                yield return null;

                if (player1Pawn.wonGame && player2Pawn.wonGame && player3Pawn.wonGame && player4Pawn.wonGame) {
                    break;
                }
            }
        }
    }
}