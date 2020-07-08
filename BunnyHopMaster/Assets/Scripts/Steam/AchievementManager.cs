using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AchievementManager : MonoBehaviour
{
    List<Achievement> achievementList;
    [SerializeField]
    private UnityEngine.UI.Image uiImage;
    public static AchievementManager Instance { get; private set; }

    private void Awake()
    {
        #region Singleton pattern garbage
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (AchievementManager.Instance == null)
        {
            AchievementManager.Instance = this;
        }
        else if (AchievementManager.Instance == this)
        {
            Destroy(AchievementManager.Instance.gameObject);
            AchievementManager.Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        Steamworks.SteamUserStats.OnAchievementProgress += AchievementChanged;

        Task.Run(PopulateAchievements);
    }

    private async void PopulateAchievements()
    {
        foreach(Steamworks.Data.Achievement ach in Steamworks.SteamUserStats.Achievements)
        {
            Achievement a = new Achievement();

            a.title = ach.Name;
            a.description = ach.Description;
            a.state = ach.State;

            Steamworks.Data.Image? img = await ach.GetIconAsync();
            if (img != null)
            {
                Steamworks.Data.Image unwrappedImage = img.Value;

                Texture2D icon = new Texture2D((int)unwrappedImage.Width, (int)unwrappedImage.Height, TextureFormat.RGB24, false);
                icon.SetPixelData<byte>(unwrappedImage.Data, 0);

                Sprite sprite = Sprite.Create(icon, Rect.zero, new Vector2(.5f, .5f));

                a.icon = sprite;
                uiImage.sprite = sprite;

            } else
            {
                Debug.LogError("Did not retrieve achievement image from Steam!");
            }


        }
    }

    private void AchievementChanged(Steamworks.Data.Achievement ach, int currentProgress, int progress)
    {
        if (ach.State)
        {
            Debug.Log($"{ach.Name} WAS UNLOCKED!");
        }
    }
}
