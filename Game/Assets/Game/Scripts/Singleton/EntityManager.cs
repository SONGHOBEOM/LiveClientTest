using UnityEngine;

public class EntityManager : Singleton<EntityManager>
{
    public PlayerController PlayerController { get; private set; }

    public void SetPlayerController(PlayerController playerController) => PlayerController = playerController;
}
