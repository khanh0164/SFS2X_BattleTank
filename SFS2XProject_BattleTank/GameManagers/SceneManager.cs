﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SFS2XProject_BattleTank.Bases;
using System.Collections.Generic;

namespace SFS2XProject_BattleTank.GameManagers
{
    public class SceneManager
    {
        private List<Scene> _allScenes;
        private ContentManager _contents;
        private Scene _activeScene;
        private Scene _preScene;
        private bool _isStarted;

        public SceneManager(ContentManager contents)
        {
            _allScenes = new List<Scene>();
            _contents = contents;
            _activeScene = null;
            _preScene = null;
            _isStarted = false;
        }

        public bool Init()
        {
            // add scenes
            _isStarted = true;
            if (_activeScene == null)
            {
                return false;
            }
            if (!_activeScene.INIT)
            {
                _activeScene.Init();
            }
            return _activeScene.INIT;
        }
        public void Add(Scene newScene)
        {
            if (newScene != null)
            {
                _allScenes.Add(newScene);
            }
        }
        public void Remove(Scene scene)
        {
            if (scene != null)
            {
                _allScenes.Remove(scene);
            }
        }
        public bool GotoScene(string name)
        {
            if (_isStarted)
                foreach (Scene s in _allScenes)
                {
                    if (s.NAME == name)
                    {
                        if (_activeScene != null)
                        {
                            _preScene = _activeScene;
                            _activeScene.Shutdown();
                        }
                        _activeScene = s;
                        return _activeScene.Init();
                    }
                }
            return false;
        }
        public bool BackToPreviousScene()
        {
            return GotoScene(_preScene.NAME);
        }
        public void Update(float deltaTime)
        {
            if (_isStarted)
                if (_activeScene != null)
                {
                     _activeScene.Update(deltaTime);
                }
        }
        public void Draw(SpriteBatch sp)
        {
            if (_isStarted)
                if (_activeScene != null)
                    _activeScene.Draw(sp);
        }
    }
}
