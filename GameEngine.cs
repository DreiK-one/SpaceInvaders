using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceInvaders
{
    class GameEngine
    {
        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private Scene _scene;

        private SceneRender _sceneRender;

        private GameSettings _gameSettings;

        private GameEngine()
        {

        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        } 

        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public void Run()
        {
            int SwarmMoveCounter = 0;
            int playerMissileCounter = 0;

            do
            {
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

                _sceneRender.ClearScreen();

                if (SwarmMoveCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    SwarmMoveCounter = 0;
                }
                SwarmMoveCounter+=5;

                if (playerMissileCounter == _gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }
                playerMissileCounter+=5;


            } while (_isNotOver);

            Console.BackgroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOver();
        }

        public void CalculateMovePlayerShipLeft()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                alienShip.GameObjectPlace.YCoordinate++;

                if (alienShip.GameObjectPlace.YCoordinate == _scene.playerShip.GameObjectPlace.YCoordinate)
                {
                    _isNotOver = false;
                }
                
            }
        }

        public void Shot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);
            GameObject missile = missileFactory.GetGameObject(_scene.playerShip.GameObjectPlace);

            _scene.playerShipMissile.Add(missile);
            Console.Beep(100, 200);
        }

        public void CalculateMissileMove()
        {
            if (_scene.playerShipMissile.Count == 0)
            {
                return;
            }


            for (int x = 0; x< _scene.playerShipMissile.Count; x++)
            {
                GameObject missile = _scene.playerShipMissile[x];

                if (missile.GameObjectPlace.YCoordinate == 1)
                {
                    _scene.playerShipMissile.RemoveAt(x);
                }


                missile.GameObjectPlace.YCoordinate--;

                for (int i = 0; i < _scene.swarm.Count; i++)
                {
                    GameObject alianShip = _scene.swarm[i];

                    if (missile.GameObjectPlace.Equals(alianShip.GameObjectPlace))
                    {
                        _scene.swarm.RemoveAt(i);
                        _scene.playerShipMissile.RemoveAt(x);
                        Console.Beep(200, 200);
                        break;
                    }
                }
            }
        }
    }
}
