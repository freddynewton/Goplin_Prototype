using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FreddyNewton.Utility.SceneManagement
{
    /// <summary>
    /// Singleton Scene Manager.
    /// A centralized script to control clean loading of additive scenes.
    /// With this it should be all encapsulated. 
    /// <see cref="SceneContainer"/> should be located in the Resources folder.
    /// </summary>
    public class SceneManagementController : Singleton<SceneManagementController>
    {
        public SceneContainer StartUpSceneContainer;
        private List<SceneContainer> SceneContainers = new List<SceneContainer>();
        private SceneContainer CurrentSceneContainer;

        /// <summary>
        /// Unloads first all additive loaded Scenes.
        /// Loads based of the title all new Scenes
        /// </summary>
        /// <param name="title">Search parameter to get the right <see cref="SceneContainer"/></param>
        public void LoadScenes(string title)
        {
            var searchedSceneContainer = SceneContainers.Find(scene => scene.Title == title);

            if (searchedSceneContainer == null)
            {
                Debug.LogWarning("SceneContainer " + title + " not found!");
                return;
            }

            UnloadAllScenes();

            foreach (var scene in searchedSceneContainer.Scenes)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }

            CurrentSceneContainer = searchedSceneContainer;
        }

        /// <summary>
        /// Await function
        /// </summary>
        private void Awake()
        {
            this.SceneContainers = Resources.LoadAll<SceneContainer>("Utility/SceneContainers").ToList();
            LoadScenes(StartUpSceneContainer.Title);
        }

        /// <summary>
        /// Unloads all scenes from the <see cref="CurrentSceneContainer"/>
        /// </summary>
        /// <returns>AsyncTaks</returns>
        private void UnloadAllScenes()
        {
            if (CurrentSceneContainer == null) return;

            foreach (var scene in CurrentSceneContainer.Scenes)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }
}
