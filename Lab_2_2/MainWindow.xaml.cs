using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Task_String;

namespace Lab_2_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
        }
        //Сохраняет поля в файл
        private void SaveConfig()
        {
            FileStream Fs = File.Open("cfg.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter Writer = new StreamWriter(Fs);
            Writer.WriteLine(TB_Input.Text);
            Writer.Close();
        }
        //Загружает поля из файла
        private void LoadConfig()
        {
            FileStream Fs = File.Open("cfg.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader Reader = new StreamReader(Fs);
            TB_Input.Text = Reader.ReadLine();
            Reader.Close();
        }

        //Высчитывает сумма строкового ряда
        public void BT_Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TB_Input.Text[TB_Input.Text.Length-1] == '+' || TB_Input.Text[TB_Input.Text.Length - 1] == '-')
                {
                    string str = TB_Input.Text;
                    TB_Input.Text = "";
                    for (int i = 0; i < str.Length -1; i++)
                    {
                        TB_Input.Text += str[i];
                    }
                }
                StringRow row = new StringRow(TB_Input.Text);
                L_Sum.Content = $"Сумма: {row.Sum}";
                SaveConfig();
            }
            catch(Exception)
            {
                MessageBox.Show($"Ошибка: Введены неверный формат строки");
                L_Sum.Content = $"Сумма: ???";
            }
        }

        //Переход на следующий элемент при нажатии на Enter
        private void TB_TimeNextContorl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && TB_Input.Text != string.Empty && sender == TB_Input)
            {
                 BT_Result.Focus();
                 BT_Result_Click(null, null);
            }
        }

        //Очищает поля
        private void BT_Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_Input.Text = string.Empty;
            L_Sum.Content = "Сумма: -";
        }

        //Выводит задание
        private void BT_Task_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дан текст, имеющий вид: d1±d2±...±dn, где di — цифры(n > 1). Вычислить записанную в тексте сумму");
        }
        public string Input { get { return TB_Input.Text; } set { TB_Input.Text = value; } }
        public string Sum { get { return (string)L_Sum.Content; } private set { } }
    }
}
