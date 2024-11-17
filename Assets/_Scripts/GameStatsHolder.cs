using UnityEngine;

// https://docs.unity3d.com/Manual/class-ScriptableObject.html
[CreateAssetMenu(fileName = "GameState", menuName = "GameStats/GameStateHolder", order = 1)]
public class GameStateHolder : ScriptableObject
{
    // Start is called before the first frame update
    public float energy;
    public float reputation;

    // Update is called once per frame
    // void Update() {  }
}
