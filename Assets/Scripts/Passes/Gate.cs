using UnityEngine.SceneManagement;

public class Gate : Pass
{
    public string nextLevelName;

    public override void Interact()
    {
        base.Interact();
        SceneManager.LoadScene(nextLevelName);
    }
}