using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceInvaders
{
    class PlayerShipFactory : GameObjectFactory
    {

        public PlayerShipFactory(GameSettings gameSettings) : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace ObjectPlace)
        {
           
            GameObject gameObject = new PlayerShip() { Figure = GameSettings.PlayerShip, GameObjectPlace = ObjectPlace, GameObjectType = GameObjectType.PlayerShip };

            return gameObject;
        }

        public GameObject GetGameObject()
        {
            GameObjectPlace place = new GameObjectPlace() { XCoordinate = GameSettings.PlayerShipStartXCoordinate, YCoordinate = GameSettings.PlayerShipStartYCoordinate };
            GameObject gameObject = GetGameObject(place);
            return gameObject;
        }
    }
}
