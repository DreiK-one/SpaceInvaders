using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceInvaders
{
    class AlienShipFactory : GameObjectFactory
    {
        public AlienShipFactory (GameSettings gameSettings) : base(gameSettings)
        {

        }
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject alienShip = new AlienShip() { Figure = GameSettings.AlienShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.AlienShip };

            return alienShip;
        }

        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();
            int startX = GameSettings.SwarmStartXCoordinate;
            int startY = GameSettings.SwarmStartYCoordinate;

            for (int y = 0; y < GameSettings.NumberOfSwarmRow; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfSwarmColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject alienShip = GetGameObject(objectPlace);
                    swarm.Add(alienShip);
                }
            }

            return swarm;
        }
    }
}
