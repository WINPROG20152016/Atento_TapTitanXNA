using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_GodrykAtento
{
    public class Level
    {
        public static int windowWidth = 400;
        public static int windowHeight = 500;

        #region Properties
        ContentManager content;
        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;

        SpriteFont damageStringfont;
        int damageNumber = 0;

        Button slash1Button;
        #endregion

        public Level(ContentManager content)
        {
            this.content = content;
            hero = new Hero(content, this);
        }
        
         public void LoadContent()
        {
            background = content.Load<Texture2D>("IMGS/Hachiko");
            damageStringfont = content.Load<SpriteFont>("Font");

            slash1Button = new Button(content, "IMGS/Slash", new Vector2(300,300));
            hero.LoadContent();


        }

         public void Update(GameTime gameTime)
         {
             mouseState = Mouse.GetState();
             mouseX = mouseState.X;
             mouseY = mouseState.Y;
             prev_mpressed = mpressed;
             mpressed = mouseState.LeftButton == ButtonState.Pressed;
             hero.Update(gameTime);

             oldMouseState = mouseState;
             if (slash1Button.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
             {
                 damageNumber += 1;
             }

         }

         public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, null, Color.White);
            hero.Draw(gameTime, spriteBatch);
            slash1Button.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(damageStringfont, damageNumber + "!!", Vector2.Zero, Color.White);


        }

    }
}
