using UnityEngine;
using System.Collections;
using Com.Mygame;

public class UserInterface : MonoBehaviour {
    GameSceneController scene;
    QueryGameStatus state;
    UserActions action;

    float width, height;
    float castw(float scale) { return (Screen.width - width) / scale; }
    float casth(float scale) { return (Screen.height - height) / scale; }

    void Start() {
        scene = GameSceneController.GetInstance();
        state = GameSceneController.GetInstance() as QueryGameStatus;
        action = GameSceneController.GetInstance() as UserActions;
    }

    void OnGUI() {
        GUI.skin.button.fontSize = GUI.skin.textArea.fontSize = 20;
        width = Screen.width / 12;
        height = Screen.height / 12;

        if (state.getMessage() != "") {
            if ( GUI.Button(new Rect(castw(2f), casth(6f), width, height), state.getMessage()) ) action.restart();
        }
        else {
            if (GUI.RepeatButton(new Rect(10, 10, 100, 40), "Help")) GUI.TextArea(new Rect(10, 60, 750, 100), scene.getBaseCode().gameRule);
            else if (!state.isMoving()) {
                if (GUI.Button(new Rect(castw(2f), casth(6f), width, height), "开船")) action.moveBoat();
                if (GUI.Button(new Rect(castw(10.5f), casth(4f), width, height), "恶魔上船")) action.devilSOnB();
                if (GUI.Button(new Rect(castw(4.29f), casth(4f), width, height), "牧师上船")) action.priestSOnB();
                if (GUI.Button(new Rect(castw(1.06f), casth(4f), width, height), "恶魔上船")) action.devilEOnB();
                if (GUI.Button(new Rect(castw(1.26f), casth(4f), width, height), "牧师上船")) action.priestEOnB();
                if (GUI.Button(new Rect(castw(2.5f), casth(1.3f), width, height), "左侧下船")) action.offBoatL();
                if (GUI.Button(new Rect(castw(1.6f), casth(1.3f), width, height), "右侧下船")) action.offBoatR();
            }
        }
    }
}
