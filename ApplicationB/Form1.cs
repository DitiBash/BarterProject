using Repository_DL.DBModels;

namespace ApplicationB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void loudData()
        {//===================
            dataGridView1.DataSource = new Services_BL.UsersServices().GetAll();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loudData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Services_BL.UsersServices().AddNew(new UsersTbl() { NameUser = textBox1.Text, Password = textBox2.Text });
            loudData();
        }
    }
}