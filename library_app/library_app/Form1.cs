using System.Data.OleDb;
namespace library_app

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\vlobi\OneDrive\Документы\GitHub\library_app\Library_DB.accdb";

            // создание объекта подключения
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                // открытие подключения
                connection.Open();

                // выполнение запроса на выборку данных
                OleDbCommand command = new OleDbCommand("SELECT * FROM Login", connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // обработка результатов запроса
                    int id = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    // и т.д.
                }
            }
            catch (OleDbException ex)
            {
                // обработка ошибок подключения или выполнения запроса
            }
            finally
            {
                // закрытие подключения
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}