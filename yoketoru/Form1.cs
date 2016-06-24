using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoketoru
{
    public partial class Form1 : Form
    {
        enum SCENES {
        SC_NONE,    //無効
        SC_TITLE,   //タイトル
        SC_GAME,    //ゲーム中
        SC_GAMEOVER,//ゲームオーバー
        SC_CLEAR,   //クリア
       };
        /**現在のシーン*/
        SCENES nowScene = SCENES.SC_NONE;
        /**次のシーン*/
        SCENES nextScene = SCENES.SC_TITLE;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            init();
            update();
            render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /**初期化*/
        private void init()
        {
            // シーンの切り替えが必要か？
            if (nextScene == SCENES.SC_NONE)
                return; // init()を出る
            //シーンの切り替えが必要
            nowScene = nextScene;
            nextScene = SCENES.SC_NONE;
        }

        /**更新処理*/
        private void update()
        {
            switch(nowScene)
            {
                case SCENES.SC_TITLE:
                    if ((Control.MouseButtons & MouseButtons.Left)
                        == MouseButtons.Left){
                        //左クリックされた
                        nextScene = SCENES.SC_GAME;
                    }
                    break;
                case SCENES.SC_GAME:
                    if((Control.MouseButtons & MouseButtons.Left)
                        == MouseButtons.Left){
                        //左クリックされた
                        nextScene = SCENES.SC_GAMEOVER;
                    }
                    if ((Control.MouseButtons & MouseButtons.Right)
                      == MouseButtons.Right)
                    {
                        //右クリックされた
                        nextScene = SCENES.SC_CLEAR;
                    }
                    break;
                case SCENES.SC_GAMEOVER:
                case SCENES.SC_CLEAR:
                    if((Control.MouseButtons & MouseButtons.Left)
                        == MouseButtons.Left)
                    {
                        //左クリックされた
                        nextScene = SCENES.SC_TITLE;
                    }
                    break;
            }
        }

        /**描画*/
        private void render()
        {
            switch(nowScene)
            {
                case SCENES.SC_TITLE:
                    Text = "TITLE";
                    break;
                case SCENES.SC_GAME:
                    Text = "GAME";
                    break;
                case SCENES.SC_GAMEOVER:
                    Text = "GAME_OVER";
                    break;
                case SCENES.SC_CLEAR:
                    Text = "CLEAR";
                    break;    
            }
        }
    }
}
