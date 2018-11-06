using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Fantastic7
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gs;
        Room rm;
        Texture2D plainText;
        const int WIDTH = 1280;
        const int HEIGHT = 720;
        SpriteFont mfont;


        enum GameState
        {
            mainMenu,
            running,
            paused
        };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.IsFullScreen = false;
            graphics.PreferMultiSampling = false;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gs = GameState.mainMenu;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            plainText = new Texture2D(GraphicsDevice, 1, 1);
            plainText.SetData(new[] { Color.White });
            rm = new Room(Color.Gray, Color.LightGray, plainText);
            /*try
            {*/
                mfont = Content.Load<SpriteFont>("File");
            /*
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }*/
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            switch(gs)
            {
                case GameState.mainMenu:
                    //Poll inputs
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();
                    if (Keyboard.GetState().IsKeyDown(Keys.G)) gs = GameState.running;
                    //End inputs 
             
                    break;
                case GameState.running:
                    //Poll inputs
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape)) gs = GameState.paused;
                    //End inputs
                    break;
                case GameState.paused:
                    //Poll inputs
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter)) gs = GameState.mainMenu;
                    if (Keyboard.GetState().IsKeyDown(Keys.U)) gs = GameState.running;
                    if (Keyboard.GetState().IsKeyDown(Keys.F)) graphics.IsFullScreen = false; 
                    //End inputs
                    break;
                default: break;
            }
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            switch (gs)
            {
                case GameState.mainMenu:
                    spriteBatch.Draw(plainText, new Rectangle(0, 0, WIDTH, HEIGHT), Color.SandyBrown);
                    spriteBatch.DrawString(mfont, "Main Menu", new Vector2(50, 100), Color.SaddleBrown);
                    break;
                case GameState.paused:
                    spriteBatch.Draw(plainText, new Rectangle(WIDTH / 4, HEIGHT / 8, WIDTH / 2, HEIGHT / 2), Color.SandyBrown);
                    spriteBatch.DrawString(mfont, "Main Menu", new Vector2(WIDTH / 4 + 50, HEIGHT / 8 + 100), Color.SaddleBrown);
                    break;
                case GameState.running:

                    //spriteBatch.Draw(plainText, new Rectangle(0, 0, 1000, 1000),Color.Gray);
                    //spriteBatch.Draw(plainText, new Rectangle(150, 50, 800, 75), Color.Chocolate);
                    rm.Draw(spriteBatch, 1f);
                    break;
                default: break;
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
