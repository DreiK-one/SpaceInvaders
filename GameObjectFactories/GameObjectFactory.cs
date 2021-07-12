using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceInvaders
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }

        public abstract GameObject GetGameObject(GameObjectPlace ObjectPlace);

        public GameObjectFactory (GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }

    }
}
