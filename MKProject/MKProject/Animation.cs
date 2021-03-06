using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MKProject
{
    class Animation
    {
        Texture2D texture;
        Texture2D stance;
        Rectangle rectangle;
        Vector2 position;
        Vector2 origin;
        Vector2 velocity;
        int currentFrame;
        int frameHeight;
        int frameWidth;
        int sup;
        float timer;
        float interval = 50;

        public Animation(Texture2D newTexture, Vector2 newPosition, int newFrameHeight, int newFrameWidth, Texture2D newStance, int newSup)
        {
            texture = newTexture;
            position = newPosition;
            frameHeight = newFrameHeight;
            frameWidth = newFrameWidth;
            stance = newStance;
            sup = newSup;
        }

        public void Update(GameTime gameTime, Texture2D newTexture, int newFrameWidth)
        {
            rectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            position = position + velocity;
            texture = newTexture;
            frameWidth = newFrameWidth;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                AnimateRight(gameTime);
                velocity.X = 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                AnimateLeft(gameTime);
                velocity.X = -3;

            }
            else
            {
                Animate(gameTime);
                velocity = Vector2.Zero;
            }

            if (position.X < 32)
            {
                position.X = 32;
            }
            if (position.X > 768)
            {
                position.X = 768;
            }
        }
        public void AnimateRight(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame > 8)
                    currentFrame = 0;
            }
        }

        public void AnimateLeft(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currentFrame--;
                timer = 0;
                if (currentFrame > 8 || currentFrame == 0)
                    currentFrame = 8;
            }
        }

        public void Animate(GameTime gameTime)
        {
            texture = stance;
            frameWidth = sup;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            if (timer >= interval)
            {
                if (currentFrame >= 5)
                {
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                }
                timer = 0;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
