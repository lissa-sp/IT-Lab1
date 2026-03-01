using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Множество, которое хранит уникальные символы ключа
        private HashSet<char> uniqKeyChar = new HashSet<char>();
        //Строка, содержащая буквы алфавита исходного текста
        private string alph;
        private const int tableSize = 5;
        private int sizeOfAlph;
        //Шифрующая таблица
        private char[,] encodMatrix = new char[5, 5];
        private string clearInitText = "";
        private string modifiedText = "";

        //Обработка ключа
         private string getCorrectKeyPF()
         {
            string key = tbKey.Text.ToUpper();
            
            key = new string(key.Where(c => alph.Contains(c)).ToArray());

            key = key.Replace("J", "I");

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("В ключе нет допустимых букв (A-Z)!",
                               "Ошибка в ключе",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                tbModifiedText.Text = "";
                return ""; 
            }

            return key;
         }

        //Обработка исходного текста(Плейфер)
        private string getCorrectInitialStringPF()
        {
            //Поднимаем регистр 
            string initText = tbInitText.Text.ToUpper();

            //Заменяем все J на I
            initText = initText.Replace("J", "I");

            initText = new string(initText.Where(c => alph.Contains(c)).ToArray());

            if (string.IsNullOrEmpty(initText))
            {
                MessageBox.Show("В исходном тексте нет допустимых букв (A-Z)!",
                               "Ошибка в исходном тексте",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                tbModifiedText.Text = "";
                return "";
            }

            //Разбиваем по парам и анализируем на повторы(проходим один раз по строке)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < initText.Length; i+=2)
            {
                if (i == initText.Length - 1)
                {
                    sb.Append(initText[i]);
                    break;
                }

                char first = initText[i];
                char second = initText[i+1];

                if (first == second)
                {
                    sb.Append(first);
                    sb.Append("X"); //вставляем разделитель
                    i--;
                }
                else
                {
                    sb.Append(first);
                    sb.Append(second);
                }

            }

            //Проверяем на четность, если нечетное - добавляем X в конец
            if (sb.Length % 2 == 1)
                sb.Append("X");
            
            return sb.ToString();
        }

        //Заполнение шифрирующей таблицы
        private void getEncodMatrix(string key)
        {
            uniqKeyChar.Clear();
            int i = 0;
            int j = 0;
            int currCharInKey = 0;

            //Заносим ключ в матрицу 
            while (currCharInKey < key.Length && i < tableSize)
            {
                j = 0;
                while (currCharInKey < key.Length && j < tableSize)
                {
                    if (!uniqKeyChar.Contains(key[currCharInKey]))
                    {
                        encodMatrix[i,j] = key[currCharInKey];
                        uniqKeyChar.Add(key[currCharInKey]);
                        j++;
                    }
                    currCharInKey++;
                }

                if (currCharInKey < key.Length)
                    i++;
            }

            //Дополняем матрицу символами алфавита
            int currCharInAlph = 0;
            if (j >= tableSize)
                i++;

            while (i < tableSize)
            {
                if (j >= tableSize)
                    j = 0;
                while (j < tableSize)
                {
                    if (!uniqKeyChar.Contains(alph[currCharInAlph]))
                    {
                        encodMatrix[i,j] = alph[currCharInAlph];
                        j++;
                    }
                    currCharInAlph++;   
                }
                i++;
            }

        }

        //Класс для позиции символа в таблице
        public class Position
        {
            public int i;
            public int j;

            public Position(int row, int col)
            {
                i = row; 
                j = col;
            }
        }
        //Метод для нахождения позиции буквы в шифрирующей таблице
        private Position getCharPos(char ch)
        {
            int i = 0, j = 0;
            bool isFound = false;
            Position pos = new Position(0,0);

            while (!isFound && i < tableSize)
            {
                j = 0;
                while (!isFound && j < tableSize)
                {
                    if (encodMatrix[i, j] == ch)
                    {
                        isFound = true;
                        pos.i = i;
                        pos.j = j;
                    }
                    j++;    
                }
                i++;
            }
            return pos;
        }

        //Метод для шифра Плейфера(шифрование)
        private string encodePlayFair(string text)
        {
            char [] charsOfText = text.ToCharArray();
            for (int i = 0; i < charsOfText.Length; i+=2)
            {
                //Вычисление позиций в таблице для двух текущих букв
                Position position1 = getCharPos(charsOfText[i]); 
                Position position2 = getCharPos(charsOfText[i + 1]);

                //Используем одно из трех правил в зависимости от положения букв в таблице
                if (position1.i == position2.i) //на одной строке
                {
                    charsOfText[i] = encodMatrix[position1.i, (position1.j + 1) % tableSize];
                    charsOfText[i + 1] = encodMatrix[position2.i, (position2.j + 1) % tableSize];
                }
                else if (position1.j == position2.j)//в одном столбце
                {
                    charsOfText[i] = encodMatrix[(position1.i + 1) % tableSize, position1.j];
                    charsOfText[i + 1] = encodMatrix[(position2.i + 1) % tableSize, position2.j];
                }
                else //прямоугольник
                {
                    charsOfText[i] = encodMatrix[position1.i, position2.j];
                    charsOfText[i + 1] = encodMatrix[position2.i, position1.j];
                }
            }

            return new string(charsOfText);
        }

        //Метод для шифра Плейфера(дешифрование)
        private string decodePlayFair(string text)
        {
            char[] charsOfText = text.ToCharArray();

            for (int i = 0; i < text.Length; i+=2)
            {
                Position position1 = getCharPos(charsOfText[i]);
                Position position2 = getCharPos(charsOfText[i+1]);

                if (position1.i == position2.i) //на одной строке
                {
                    if (position1.j - 1 >= 0)
                        charsOfText[i] = encodMatrix[position1.i, position1.j - 1];
                    else
                        charsOfText[i] = encodMatrix[position1.i, tableSize-1];

                    if (position2.j - 1 >= 0)
                        charsOfText[i + 1] = encodMatrix[position2.i, position2.j - 1];
                    else
                        charsOfText[i + 1] = encodMatrix[position2.i, tableSize-1];

                }
                else if (position1.j == position2.j)//в одном столбце
                {
                    if (position1.i - 1 >= 0)
                        charsOfText[i] = encodMatrix[position1.i - 1, position1.j];
                    else
                        charsOfText[i] = encodMatrix[tableSize-1, position1.j];

                    if (position2.i - 1 >= 0)
                        charsOfText[i + 1] = encodMatrix[position2.i - 1, position2.j];
                    else
                        charsOfText[i + 1] = encodMatrix[tableSize-1, position2.j];
                }
                else //прямоугольник
                {
                    charsOfText[i] = encodMatrix[position1.i, position2.j];
                    charsOfText[i + 1] = encodMatrix[position2.i, position1.j];
                }

            }

            return new string(charsOfText);
        }

        //Обработка исходного текста (Виженер)
        private string getCorrectInitialStringV()
        {
            string initText = tbInitText.Text.ToUpper();

            initText = new string(initText.Where(c => alph.Contains(c)).ToArray());

            if (string.IsNullOrEmpty(initText))
            {
                MessageBox.Show("В исходном тексте нет допустимых букв (A-Я)!",
                               "Ошибка в исходном тексте",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                tbModifiedText.Text = "";
                return "";
            }
            return initText;
        }

        //Формирование прогрессивного ключа
        private string getProgressiveKey(string text)
        {
            string key = tbKey.Text.ToUpper();
            
            key = new string(key.Where(c => alph.Contains(c)).ToArray());

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("В ключе нет допустимых букв (A-Z)!",
                               "Ошибка в ключе",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                tbModifiedText.Text = "";
                return "";
            }

            StringBuilder progrKey = new StringBuilder();
            int offset = 0;
            int indexInKey = 0;
            int indexInAlph;

            for (int i = 0; i < text.Length; i++)
            {
                if (indexInKey == key.Length)
                {
                    offset++;
                    indexInKey = 0;
                }

                indexInAlph = alph.IndexOf(key[indexInKey++]);
                progrKey.Append(alph[(indexInAlph+offset) % sizeOfAlph]);
            }

            return progrKey.ToString();
        }

        //Метод для шифра Виженера(шифрование)
        private string encodeVigener(string text, string progrKey)
        {
            StringBuilder sb = new StringBuilder();
            int index;
            for (int i = 0; i < text.Length;i++)
            {
                index = (alph.IndexOf(progrKey[i]) + alph.IndexOf(text[i])) % sizeOfAlph;
                sb.Append(alph[index]);
            }
            return sb.ToString();
        }

        //Метод для шифра Виженера(дешифрование)
        private string decodeVigener(string text, string progrKey)
        {
            StringBuilder sb = new StringBuilder();
            int index;

            for (int i = 0; i < text.Length; i++)
            {
                index = (alph.IndexOf(text[i]) - alph.IndexOf(progrKey[i]) + sizeOfAlph) % sizeOfAlph;
                sb.Append(alph[index]);
            } 
            return sb.ToString();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            string clearKey;
            if (rbCipherPlayFair.Checked)
            {
                if ((clearKey = getCorrectKeyPF()) != "")
                {
                    getEncodMatrix(clearKey);
                    clearInitText = getCorrectInitialStringPF();
                    if (clearInitText != "")
                    {
                        modifiedText = encodePlayFair(clearInitText);
                        tbModifiedText.Text = modifiedText;
                    }
                }
            }
            else
            {   
                clearInitText = getCorrectInitialStringV();
                if (clearInitText != "")
                {
                    if ((clearKey = getProgressiveKey(clearInitText)) != "")
                        tbModifiedText.Text = encodeVigener(clearInitText, clearKey);
                }
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            string clearKey;
            if (rbCipherPlayFair.Checked)
            {
                if ((clearKey = getCorrectKeyPF()) != "")
                {
                    getEncodMatrix(clearKey);

                    clearInitText = tbInitText.Text.ToUpper();
                    clearInitText = clearInitText.Replace("J", "I");
                    clearInitText = new string(clearInitText.Where(c => alph.Contains(c)).ToArray());

                    modifiedText = decodePlayFair(clearInitText);
                    tbModifiedText.Text = modifiedText;
                }
            }
            else
            {
                clearInitText = getCorrectInitialStringV();
                if (clearInitText != "")
                {
                    if ((clearKey = getProgressiveKey(clearInitText)) != "")
                        tbModifiedText.Text = decodeVigener(clearInitText, clearKey);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbInitText.Text = "";
            tbKey.Text = "";
            tbModifiedText.Text = "";
            clearInitText = "";
            modifiedText = "";
        }

        private void rbVigener_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVigener.Checked)
                lblNameOfCypher.Text = "Шифр Виженера";
        }

        private void rbEnglish_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnglish.Checked)
            {
                if (rbCipherPlayFair.Checked)
                    alph = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
                else if (rbVigener.Checked)
                    alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                sizeOfAlph = 26;
            }
        }

        private void rbCipherPlayFair_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCipherPlayFair.Checked)
                lblNameOfCypher.Text = "Шифр Плейфера";
        }

        private void rbRussian_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRussian.Checked)
            {
                alph = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                sizeOfAlph = 33;
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли данные для сохранения
            if (string.IsNullOrWhiteSpace(tbModifiedText.Text))
            {
                MessageBox.Show("Нет данных для сохранения!",
                               "Предупреждение",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Сохранить преобразованный текст";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "playfairResult.txt";
            saveFileDialog.OverwritePrompt = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, tbModifiedText.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                                   "Ошибка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }
        }

        private void btnReadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Выберите текстовый файл";
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string textFromFile = File.ReadAllText(openFileDialog.FileName);
                    tbInitText.Text = textFromFile;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Ошибка при открытии файла:\n{ex.Message}",
                                   "Ошибка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }

        }
    }
}
