using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CV08_cteni_z_webu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Todo
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public bool completed { get; set; }

            // Pìkný výpis pro ListBox
            public override string ToString()
            {
                return $"{id}: {title} (Hotovo: {(completed ? "ano" : "ne")})";
            }
        }

        // Obsluha kliknutí na tlaèítko
        private async void btnDown_Click(object sender, EventArgs e)
        {
            string url = "https://jsonplaceholder.typicode.com/todos";

            try
            {
                // 1. Stáhneme JSON string
                string json = await DownloadJsonAsync(url);

                // 2. Deserializujeme na seznam objektù

                //List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(json);
                
                Todo[] todos = JsonSerializer.Deserialize<Todo[]>(json);

                // 3. Vykreslíme do ListBoxu
                lstBox.Items.Clear();
                foreach (var todo in todos)
                {
                    lstBox.Items.Add(todo); // ToString() se automaticky použije
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: " + ex.Message);
            }
        }

        // Asynchronní metoda pro stažení JSON dat
        private async Task<string> DownloadJsonAsync(string url)
        {
            using HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }
    }
}

