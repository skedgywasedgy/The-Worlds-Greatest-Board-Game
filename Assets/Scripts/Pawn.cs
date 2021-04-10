using System.Collections;
using UnityEngine;

namespace GreatestBoardGame {
    public class Pawn : MonoBehaviour {
        public Path currentPath;
        public int currentSpace;

        public bool moving = false;

        public void Advance (int spaces) {
            moving = true;
            StartCoroutine (AdvanceRoutine (spaces));
        }

        private IEnumerator AdvanceRoutine (int spaces) {
            Vector3 pos;
            Space oldSpace;
            Space newSpace;
            for (int s = 0; s < spaces; s++) {
                oldSpace = currentPath.spaces[currentSpace];
                newSpace = currentPath.spaces[++currentSpace];
                
                for (float f = 0; f <= 1; f += Time.deltaTime * 2.5f) {
                    pos = Vector3.Lerp (oldSpace.transform.position, newSpace.transform.position, f);
                    pos.y += (oldSpace.transform.position - newSpace.transform.position).magnitude * Mathf.Sin (f * Mathf.PI) * 0.3f;
                    transform.position = pos;
                    transform.eulerAngles = Quaternion.LookRotation (newSpace.transform.position - oldSpace.transform.position).eulerAngles.y * Vector3.up;
                    yield return null;
                }

                transform.position = newSpace.transform.position;
            }
            moving = false;
        }

        private void Start () {
            Application.targetFrameRate = 60;
        }
    }
}