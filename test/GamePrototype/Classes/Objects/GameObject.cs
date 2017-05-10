﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*Workers: Caleb, Tom
 * DisasterPiece Games
 * GameObject Class
 */

namespace GamePrototype.Classes.Objects
{
    class GameObject
    {
        private Boolean enabled;
        private Texture2D sprite;
        private Rectangle positionRect;
        private Rectangle drawRect;
        private Boolean drawMatchesCol;
        private Boolean collides;
        private float drawDepth;
        private Boolean fixedDepth;
        //private enum Direction { North, South, East, West };
        //Direction dir;
        Point pos;
        // holds  name of texture; will be used later in Game1.LoadContent()
        string spriteName;
        // temporary string for the name of an object. Displays on screen when the player interacts with it
        string name;
        public GameObject()
        {
            sprite = null;
            positionRect = new Rectangle();
            drawDepth = .3f;
            fixedDepth = false;
        }

        public GameObject(Texture2D txtr, Rectangle psRct)
        {
            sprite = txtr;
            pos = psRct.Location;
            positionRect = psRct;
            enabled = true;
            collides = true;
            drawMatchesCol = true;
            drawDepth = .3f;
            fixedDepth = false;
        }
        // Caleb - temporary constructor. It is like the above constructor, but with a string param for interacting with objects for the Milestone 2
        public GameObject(Texture2D txtr, Rectangle psRct, string nm)
        {
            sprite = txtr;
            pos = psRct.Location;
            positionRect = psRct;
            enabled = true;
            collides = true;
            name = nm;
            drawMatchesCol = true;
            drawDepth = .3f;
            fixedDepth = false;
        }
        public GameObject(Texture2D txtr, Rectangle psRct, Boolean cl)
        {
            sprite = txtr;
            pos = psRct.Location;
            positionRect = psRct;
            enabled = true;
            collides = cl;
            drawMatchesCol = true;
            drawDepth = .3f;
            fixedDepth = false;
        }

        public GameObject(Texture2D txtr, Rectangle psRct, Rectangle clRct)
        {
            sprite = txtr;
            drawRect = psRct;
            positionRect = new Rectangle(psRct.X + clRct.X, psRct.Y + clRct.Y, clRct.Width, clRct.Height);
            enabled = true;
            collides = true;
            drawMatchesCol = false;
            drawDepth = .3f;
            fixedDepth = false;
        }
        public GameObject(Texture2D txtr, Rectangle psRct, Boolean cl, String nm)
        {
            sprite = txtr;
            pos = psRct.Location;
            positionRect = psRct;
            enabled = true;
            collides = cl;
            name = nm;
            drawMatchesCol = true;
            drawDepth = .3f;
            fixedDepth = false;
        }
        public GameObject(Texture2D txtr, Point posParam)
        {
            sprite = txtr;
            pos = posParam;
            positionRect = new Rectangle(pos.X, pos.Y, sprite.Width, sprite.Height);
            enabled = true;
            collides = true;
            drawMatchesCol = true;
            drawDepth = .3f;
            fixedDepth = false;
        }
        // Caleb - GameObject constructor with boolean "enabled"
        public GameObject(bool isEnabled, string txtrName, Point posParam)
        {
            enabled = isEnabled;
            spriteName = txtrName;
            pos = posParam;
            collides = true;
            drawDepth = .3f;
            fixedDepth = false;
            //positionRect = new Rectangle(posParam.X, posParam.Y, sprite.Width, sprite.Height); // removed because sprite is null at this point
        }

        // TODO: Update function, might not do much for base objects/furniture but needs to be overridden by special cases
        // for cosmetic changes like the blacklight lamp, this method should check if blacklight mode is on and switch the sprite (we'll get there)
        public virtual void Update(GameTime gameTime)
        {

        }
        // TODO: LoadContent method, would be useful to load sprites after a GameObject is created
        public virtual void LoadContent(Texture2D spr)
        {
            sprite = spr;
            positionRect = new Rectangle(pos.X, pos.Y, sprite.Width, sprite.Height);
        }

        //TODO: Needs accessor properties for Sprite and Position
        public Boolean Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        public Boolean FixedDepth
        {
            get { return fixedDepth; }
            set { fixedDepth = value; }
        }
        public Texture2D Sprite
        {
            get { return sprite; }
        }
        public float Depth
        {
            get { return drawDepth; }
            set { drawDepth = value; }
        }
        // Position properties
        public virtual int X
        {
            get { return positionRect.X; }
            set { positionRect.X = value; }
        }

        public virtual int Y
        {
            get { return positionRect.Y; }
            set { positionRect.Y = value; }
        }

        public Rectangle GlobalBounds
        {
            get { return positionRect; }
        }
        // Origin property - will help with proximity checks for interactable objects, returns the global position of the sprite's center
        public Vector2 SpriteOrigin
        {
            get
            {
                    return new Vector2(positionRect.X + positionRect.Width / 2, positionRect.Y + positionRect.Height / 2);
            }
        }

        // property for sprite name; Game1.LoadContent will get this, pass it to Content.Load, then will pass the sprite to this.LoadContent
        public string SpriteName
        {
            get
            {
                return spriteName;
            }
        }
        // TODO: Kat - Draw method taking in a SpriteBatch param, just like how it was handled in HW2
        public virtual void Draw(SpriteBatch sprtBtch)
        {
            // draws the object
            // TODO: Reinstate original Draw()
            if (Enabled)
            {
                if (!drawMatchesCol)
                {
                    sprtBtch.Draw(sprite, Game1.FormatDraw(drawRect), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, drawDepth);
                }
                else
                {
                    sprtBtch.Draw(sprite, Game1.FormatDraw(positionRect), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, drawDepth);
                }

            }


        }

        // test - visual identification for interactable objects
        public virtual void Draw(SpriteBatch sprtBtch, Color color)
        {
            // draws the object
            // TODO: Reinstate original Draw()
            if (Enabled)
            {
                if (!drawMatchesCol)
                {
                    sprtBtch.Draw(sprite, Game1.FormatDraw(drawRect), null, color, 0f, Vector2.Zero, SpriteEffects.None, drawDepth);
                }
                else
                {
                    sprtBtch.Draw(sprite, Game1.FormatDraw(positionRect), null, color, 0f, Vector2.Zero, SpriteEffects.None, drawDepth);
                }
            }
        }
        public Boolean Tangible // Accessor property to tell if the object should collide or not
        {
            get { return collides; }
            set { collides = value; }
        }
        // property for temporary name property
        public string Name
        {
            get
            {
                return name;
            }
        }
        // TODO: Caleb - I will try and handle collisions with these methods
        // Called when the rectangles are intersecting
        public void Collide(Player player)
        {
            // the difference between the centers of the player and GameObject; turn it into a unit vector
            //Vector2 centerToCenter;
            //centerToCenter = (this.positionRect.Center - playerRect.Center).ToVector2();
            Rectangle playerRect = player.positionRect;
            // if Player is above and to the right of object
            if (playerRect.Y > this.positionRect.Y && playerRect.X > this.positionRect.X)
            {
                player.KeepPlayerFromGoingUp();
                player.KeepPlayerFromGoingRight();
            }
            // if player is above and to the left of object
            if (playerRect.Y > this.positionRect.Y && playerRect.X < this.positionRect.X)
            {
                player.KeepPlayerFromGoingUp();
                player.KeepPlayerFromGoingLeft();
            }
            // if player is below and to the left of object
            if (playerRect.Y < this.positionRect.Y && playerRect.X < this.positionRect.X)
            {
                player.KeepPlayerFromGoingDown();
                player.KeepPlayerFromGoingLeft();
            }
            // if player is below and to the right of object
            if (playerRect.Y < this.positionRect.Y && playerRect.X > this.positionRect.X)
            {
                player.KeepPlayerFromGoingUp();
                player.KeepPlayerFromGoingLeft();
            }
        }

    }
}