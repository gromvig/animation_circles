using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public partial class Form1 : Form
    {
        private Painter p;
        private Database db;
        Point click;
        private int id = 0;
        public Form1()
        {
            InitializeComponent();
            p = new Painter(mainPanel.CreateGraphics());
            p.Start();
            db = new Database("localhost", "postgres", "", "db_circles", true);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            {


                List<(int rectangleId, int score)> scores = db.GetScores();

                StringBuilder sb = new StringBuilder();

                foreach (var score in scores)
                {
                    sb.AppendLine($"Rectangle ID: {score.rectangleId}, Score: {score.score}");
                }

                textBox1.Text = sb.ToString();




            }
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.MainGraphics = mainPanel.CreateGraphics();
            }
        }

        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;
            id++;
            p.AddNew(click.X, click.Y, id, db);
        }


    }
}