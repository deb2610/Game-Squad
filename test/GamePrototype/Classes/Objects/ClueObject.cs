﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
/*Workers: Caleb, Tom
 * DisasterPiece Games
 * ClueObject Class
 */
namespace GamePrototype.Classes.Objects
{
    class ClueObject : Interactable
    {
        Boolean onetimeUse;
        Clue givenClue;
        Clue requiredClue;

        /*public ClueObject(Texture2D txtr, Rectangle psRct, Clue clGvn) : base(txtr, psRct)
        {
            givenClue = clGvn;
            onetimeUse = false;
        }*/
        // Caleb - temporary constructor for demoing interaction for milestone 2
        public ClueObject(Texture2D txtr, Rectangle psRct, Clue clGvn, Boolean oneTime) : base(txtr, psRct)
        {
            givenClue = clGvn;
            onetimeUse = oneTime;
        }
        // same as above but with requiredClue
        public ClueObject(Texture2D txtr, Rectangle psRct, Clue clGvn, Boolean oneTime, Clue rqClue) : base(txtr, psRct)
        {
            givenClue = clGvn;
            onetimeUse = oneTime;
            requiredClue = rqClue;
        }
        public ClueObject(Texture2D txtr, Rectangle psRct, Clue clGvn, Boolean collision, Boolean oneTime) : base(txtr, psRct, collision)
        {
            givenClue = clGvn;
            onetimeUse = oneTime;
        }

        // Constructor overload for objects whose hitbox is sized differently from the sprite
        public ClueObject(Texture2D txtr, Rectangle psRct, Rectangle clRct, Clue clGvn, Boolean oneTime) : base(txtr, psRct, clRct)
        {
            givenClue = clGvn;
            onetimeUse = oneTime;
        }
        // Caleb - Another temporary constructor for interaction
        /*public ClueObject(Texture2D txtr, Rectangle psRct, Clue clGvn, Boolean collision, string nm, Boolean oneTime) : base(txtr, psRct, collision, nm)
        {
            givenClue = clGvn;
            onetimeUse = oneTime;
        }*/

        // TODO: Interaction method
        public override void Interact(Player user)
        {
            // INTERACTION FUNCTIONS HERE
            // if there is a required clue
            if (requiredClue != null)
            {
                if (Enabled && Clue.Inventory.Contains(requiredClue))
                {
                    Console.WriteLine(givenClue.ToString());
                    Clue.Inventory.Add(givenClue);
                }
                else
                {
                    Console.WriteLine("You don't have the required clue");
                }
            }
            // if there isn't a required clue
            else
            {
                if (Enabled)
                {
                    Console.WriteLine(givenClue.ToString());
                    Clue.Inventory.Add(givenClue);
                }
                if (onetimeUse)
                {
                    Enabled = false;
                }
            }
        }
    }
}
