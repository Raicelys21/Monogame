using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MKProject
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Song song;
        private Texture2D background;
        Animation player;
        Animation1 player1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            player = new Animation(Content.Load<Texture2D>("forward1"), new Vector2(100, 400), 140, 73, Content.Load<Texture2D>("stance1"), 80);
            player1 = new Animation1(Content.Load<Texture2D>("forward2"), new Vector2(600, 400), 140, 77, Content.Load<Texture2D>("stance2"), 83);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("bakground");
            song = Content.Load<Song>("music");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            player.Update(gameTime, Content.Load<Texture2D>("forward1"), 73);
            player1.Update(gameTime, Content.Load<Texture2D>("forward2"), 77);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0, 0, 899, 489), Color.White);
            player.Draw(_spriteBatch);
            player1.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}