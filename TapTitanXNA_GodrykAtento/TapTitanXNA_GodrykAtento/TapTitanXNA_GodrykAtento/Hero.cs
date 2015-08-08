using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_GodrykAtento
{
    public class Hero
    {

        Vector2 playerPosition;
        Vector2 SuppPosition;
        Vector2 BossPosition;
        Texture2D player;
        Texture2D support;
        Texture2D boss;
        ContentManager content;
        Level level;
        Animation idleAnimation;
        Animation idleSupport;
        Animation idleBoss;
        AnimationPlayer spritePlayer;
        AnimationPlayer spriteSupport;
        AnimationPlayer spriteBoss;
        MouseState oldMouseState;
        private Texture2D Attack;
        private Animation Side;
       
        

         public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;

        }
         public void LoadContent()
        {
            boss = content.Load<Texture2D>("IMGS/Tanji");
            support = content.Load<Texture2D>("IMGS/JDial");
            player = content.Load<Texture2D>("IMGS/NekuIdle");
            Attack = content.Load<Texture2D>("IMGS/NekuAtk");

            idleSupport = new Animation(support, 0.1f, true, 3);
            idleAnimation = new Animation(player, 0.1f, true, 6);
            idleBoss = new Animation(boss, 0.1f, true, 6);
            Side = new Animation(Attack, 0.1f, true, 14);


            int positionX = (Level.windowWidth / 2) - (player.Width / 4) -25;
            int positionY = (Level.windowHeight / 2) - (player.Height / 4) -25;
            playerPosition = new Vector2((float)positionX, (float)positionY);

            int SupposX = (Level.windowWidth / 2) - (player.Width / 4)-50;
            int SupposY = (Level.windowHeight / 2) - (player.Height / 4) -50;
            SuppPosition = new Vector2((float)SupposX, (float)SupposY);

            int BossX = (Level.windowWidth / 2) - (player.Width / 4) + 175;
            int BossY = (Level.windowHeight / 2) - (player.Height / 4) +125;
            BossPosition = new Vector2((float)BossX, (float)BossY);
        }

         public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();

            spritePlayer.PlayAnimation(idleAnimation);
            spriteSupport.PlayAnimation(idleSupport);
            spriteBoss.PlayAnimation(idleBoss);
            

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                spritePlayer.PlayAnimation(Side);
                if (spritePlayer.frameReturn == 14)
                {
                    spritePlayer.PlayAnimation(idleAnimation);
                }
            }

        }

         public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
         //   spriteBatch.Draw(player, playerPosition, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);

            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
            spriteSupport.Draw(gameTime, spriteBatch, SuppPosition, SpriteEffects.None);
            spriteBoss.Draw(gameTime, spriteBatch, BossPosition, SpriteEffects.None);
        }

         
    }
}
