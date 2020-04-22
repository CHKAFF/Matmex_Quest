<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Data.Common;
using System.Drawing;
=======
﻿using System.Drawing;
>>>>>>> origin/class_Player
=======
﻿using System.Data.Common;
using System.Drawing;
>>>>>>> 034d769b898d3fa97d35cb6181287baf1e481e98

namespace MATMEH_QUEST.Domain
{
    public class Player
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 034d769b898d3fa97d35cb6181287baf1e481e98
        private Point location;
        private int health;
        private Inventory inventory;

        public Player(Point location, int health, Inventory inventory)
        {
            this.location = location;
            this.health = health;
            this.inventory = inventory;
<<<<<<< HEAD
=======
        public Player()
=======
        public Player(Point location, int health)
>>>>>>> origin/class_Player
        {
            this.Health = health;
            state = PlayerState.Alive;
            this.Location = location;
        }
        private enum PlayerState
        {
            Alive,
            Dead
        }
        
        public int Health;
        private PlayerState state;
        public Point Location;

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Dead()
        {
            state = PlayerState.Dead;
>>>>>>> class_Player
=======
>>>>>>> 034d769b898d3fa97d35cb6181287baf1e481e98
        }
    }
}