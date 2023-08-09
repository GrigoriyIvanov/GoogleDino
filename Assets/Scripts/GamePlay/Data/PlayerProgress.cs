using System;
using UniRx;
using UnityEditor;

[Serializable]
public class PlayerProgress
{
    public ReactiveProperty<int> Progeress;

    public PlayerProgress(int progeress) =>
         Progeress = new ReactiveProperty<int>(progeress);
}