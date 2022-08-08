using UnityEngine;

namespace BeatRefleMod
{
    public class Loader
    {
        private static readonly GameObject MGameObject = new GameObject();

        public static void Main()
        {
            _Load();
        }

        public static void Init()
        {
            _Load();
        }

        public static void Load()
        {
            _Load();
        }

        private static void _Load()
        {
            // The function that our injector calls inside our target process
            // Here, we add a Component 'Child' to our game object.
            // For example is we had the reference to this component we could use functions like:
            // ... HackMain.GetComponentInParent<type>() to retrieve other components attacked to the same object
            // ... aka 'Sibling Components'
            MGameObject.AddComponent<Mods.FpsOverlay>();
            MGameObject.AddComponent<Mods.JudgeOverlay>();

            // We tell Object (Our universal base class) that we do not want this component to need initializing
            // ... on every scene load. Otherwise the object would be destroyed by the engine when we change scenes,
            // ... This assumes that we would make another instance of this object when we change maps,
            // ... go to the main menu, etc. (Change scenes)
            UnityEngine.Object.DontDestroyOnLoad(MGameObject);
            // Patcher.DoPatching();

        }

        public static void Unload()
        {
            // Destroys the Created object, again called by our injector to "eject" the assembly.
            UnityEngine.Object.Destroy(MGameObject); //Destroys all instances of the object.
        }
    }
}
