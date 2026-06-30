using UnityEngine;

public static class GameStateDatabase
{
    public static string GetObjective(GameState state)
    {
        switch (state)
        {
            case GameState.Intro:
                return "Mirá la introducción.";

            case GameState.LeaveStudio:
                return "Salí del estudio.";

            case GameState.HaveFun:
                return "Divertí a tus amigos.";

            case GameState.UsePC:
                return "Volvé a la computadora del estudio.";

            case GameState.NeedKey:
                return "Salí del departamento.";

            case GameState.FindKey:
                return "Buscá la llave.";

            case GameState.LeaveApartment:
                return "Salí del departamento.";

            default:
                return "";
        }
    }
}