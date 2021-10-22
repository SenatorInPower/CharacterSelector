using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class CharacterSelector
{
    private const string Path = "Assets/Prefabs/References/Char";

    private static string pathHiro;

    private GameObject hiro;

    private bool first = true;

    private AsyncOperationHandle<GameObject> hiroHendler;






    public void LoadHiro()
    {
        if (first || hiroHendler.IsDone)
        {
            int rendonHiro = UnityEngine.Random.Range(0, 15);

            pathHiro = $"{Path + rendonHiro }";

            ReleaseHiro();

            hiroHendler = Addressables.InstantiateAsync(pathHiro);

            hiroHendler.Completed += HiroCriation;
            first = false;
        }
    }

    private void HiroCriation(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        hiro = obj.Result;

    }
    void ReleaseHiro()
    {
        if (hiro)
        {
            //  Addressables.Release(hiro);
            Addressables.Release(hiroHendler);
        }

    }
    public void LoadScen()
    {
        ReleaseHiro();

        SceneManager.LoadScene("Game");
        SceneManager.sceneLoaded += delegate { InstHiro(); };


    }
    void InstHiro()
    {
        Addressables.InstantiateAsync(pathHiro);
    }

}
