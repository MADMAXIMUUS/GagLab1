using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GagLab1_WF
{
    public partial class Form1 : Form
    {
        public readonly Form2 F2;
        public readonly Form3 F3;
        public int Capacity;

        public Form1()
        {
            InitializeComponent();
            F2 = new Form2();
            F3 = new Form3();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            SetUp.On(this);
            timer1.Interval = rand.Next(100000, 1000000);
            /*timer1.Interval = rand.Next(1000, 10000);*/
            timer1.Start();
        }

        public void ResNumberInput()
        {
            try
            {
                Model.Resources = new string[Capacity];
                for (int i = 0; i < Model.Resources.Length; i++)
                    Model.Resources[i] = "Free";
                File.WriteAllLines(SetUp.Path, Model.Resources);
                SetUp.GenTable(Model.Resources, this);
                toolStripStatusLabel1.Text = "";
            }
            catch (IOException)
            {
                toolStripStatusLabel1.Text = @"Ошибка при записи в файл!";
                PathInput();
            }
            catch
            {
                toolStripStatusLabel1.Text = @"Было введено неверное число!";
                ResNumberInput();
            }
        }

        public void PathInput()
        {
            try
            {
                SetUp.Path = F2.PathInput.Text;
                if (File.Exists(SetUp.Path)) SetUp.GetModel(this);
                else SetUp.ClearModel(this);
                toolStripStatusLabel1.Text = "";
            }
            catch
            {
                toolStripStatusLabel1.Text = @"Файл не удаё тся создать или он не доступен!";
                PathInput();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "Free")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = "Busy";
                        dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Red;
                        Model.Occupy(e.RowIndex.ToString());
                    }
                    else if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "Busy")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = "Free";
                        dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Green;
                        Model.Free(e.RowIndex.ToString());
                    }
                }
            }
            catch (ResIsBroken ee)
            {
                toolStripStatusLabel1.Text = @"Ресурс в ячейке " + ee.Message + @" сломан.";
            }
            catch (AllResIsBusy)
            {
                timer1.Stop();
                MessageBox.Show(@"Все ресурсы заняты, ваш запрос отменен");
            }
            catch (ResIsChanged ee)
            {
                dataGridView1.Rows[Convert.ToInt32(ee.Message)].Cells[1].Value = "Busy";
                dataGridView1.Rows[Convert.ToInt32(ee.Message)].Cells[1].Style.BackColor = Color.Red;
                toolStripStatusLabel1.Text = $@"Сломанный ресурс был заменен на {ee.Message} ячейку.";
            }
            catch (ResIsBusy ee)
            {
                toolStripStatusLabel1.Text = $@"Ячейка {ee.Message} занята.";
            }
            catch (ResIsFree ee)
            {
                toolStripStatusLabel1.Text = $@"Ячейка {ee.Message} свободна.";
            }
            catch (ResIdInvalid)
            {
                toolStripStatusLabel1.Text = @"Неправильный номер ячейки!";
            }
            catch (ArgumentOutOfRangeException) { }

            File.WriteAllLines(SetUp.Path, Model.Resources);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            timer1.Interval = rand.Next(100000, 1000000);
            /*timer1.Interval = rand.Next(1000, 10000);*/
            int id = rand.Next(0, Model.Resources.Length);
            try
            {
                dataGridView1.Rows[id].Cells[1].Value = "Broken";
                dataGridView1.Rows[id].Cells[1].Style.BackColor = Color.Orange;
                Model.Broke(id.ToString(), this);
            }
            catch (ResIsBroken ee)
            {
                toolStripStatusLabel1.Text = $@"Ресурс в ячейке {ee.Message} сломан.";
            }
            catch (AllResIsBusy ee )
            {
                Model.Refuse(ee.Message, this);
                timer1.Stop();
                MessageBox.Show(@"Все ресурсы заняты, ваш запрос отменен");
            }
            catch (ResIsChanged ee)
            {
                dataGridView1.Rows[Convert.ToInt32(ee.Message)].Cells[1].Value = "Busy";
                dataGridView1.Rows[Convert.ToInt32(ee.Message)].Cells[1].Style.BackColor = Color.Red;
                toolStripStatusLabel1.Text = $@"Сломанный ресурс был заменен на {ee.Message} ячейку.";
            }
            catch (ResIsBusy ee)
            {
                toolStripStatusLabel1.Text = $@"Ячейка {ee.Message} занята.";
            }
            catch (ResIsFree ee)
            {
                toolStripStatusLabel1.Text = $@"Ячейка {ee.Message} свободна.";
            }
            catch (ResIdInvalid)
            {
                toolStripStatusLabel1.Text = @"Неправильный номер ячейки!";
            }
            catch (ArgumentOutOfRangeException) { }

            File.WriteAllLines(SetUp.Path, Model.Resources);
        }
    }

    class ResIdInvalid : Exception { }

    class ResIsBusy : Exception
    {
        public ResIsBusy(string mes) : base(mes) { }
    }

    class ResIsFree : Exception
    {
        public ResIsFree(string mes) : base(mes) { }
    }

    class ResIsBroken : Exception
    {
        public ResIsBroken(string mes) : base(mes) { }
    }

    class AllResIsBusy : Exception { }

    class ResIsChanged : Exception
    {
        public ResIsChanged(string mes) : base(mes) { }
    }


    static class SetUp
    {
        public static string Path;

        static MessageBoxButtons buttons = MessageBoxButtons.YesNo;

        private static void AskPath(Form1 f1)
        {
            if (f1.F2.ShowDialog() == DialogResult.OK)
            {
                Path = f1.F2.PathInput.Text;
                f1.PathInput();
            }
            else AskPath(f1);
        }

        public static void ClearModel(Form1 form)
        {
            if (form.F3.ShowDialog() == DialogResult.OK)
            {
                form.Capacity = Convert.ToInt32(form.F3.ResNumberInput.Text);
                form.ResNumberInput();
            }
            else ClearModel(form);
        }

        public static void GetModel(Form1 form)
        {
            if (MessageBox.Show(@"Обновить файл?", "", buttons) == DialogResult.Yes)
                ClearModel(form);
            else
            {
                Model.Resources = File.ReadAllLines(Path);
                GenTable(Model.Resources, form);
            }
        }

        public static void On(Form1 form)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\Resmod00"))
                {
                    if (MessageBox.Show(@"Использовать стандартный файл Resmod00?", "", buttons) == DialogResult.Yes)
                    {
                        Path = Directory.GetCurrentDirectory() + @"\Resmod00";
                        GetModel(form);
                    }
                    else AskPath(form);
                }
                else
                {
                    if (MessageBox.Show(@"Создать стандартный файл?", "", buttons) == DialogResult.Yes)
                    {
                        Path = Directory.GetCurrentDirectory() + @"\Resmod00";
                        ClearModel(form);
                    }
                    else AskPath(form);
                }
            }
            catch (IOException)
            {
                form.toolStripStatusLabel1.Text = @"Файл не открылся.";
            }
            catch (Exception)
            {
                form.toolStripStatusLabel1.Text = @"Ошибка ввода-вывода.";
            }
        }

        public static void GenTable(string[] vModel, Form1 form)
        {
            for (int i = 0; i < vModel.Length; i++)
            {
                object[] row = {$"{i + 1}", vModel[i]};
                form.dataGridView1.Rows.Add(row);
                if (vModel[i] == "Free")
                    form.dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Green;
                else if (vModel[i] == "Busy")
                    form.dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                else
                    form.dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Orange;
            }
        }
    }

    static class Model
    {
        public static string[] Resources;

        public static void Occupy(string cn)
        {
            if ((Convert.ToInt16(cn) > Resources.Length) | (Convert.ToInt16(cn) < 0)) throw new ResIdInvalid();
            Resources[Convert.ToInt16(cn)] = "Busy";
            throw new ResIsBusy((Convert.ToInt32(cn) + 1).ToString());
        }

        public static void Free(string cn)
        {
            if ((Convert.ToInt16(cn) > Resources.Length) | (Convert.ToInt16(cn) < 0)) throw new ResIdInvalid();
            Resources[Convert.ToInt16(cn)] = "Free";
            throw new ResIsFree((Convert.ToInt32(cn) + 1).ToString());
        }

        public static void Broke(string cn, Form1 form)
        {
            Resources[Convert.ToInt16(cn)] = "Broken";
            if (Resources[Convert.ToInt16(cn)] == "Busy")
                Change(cn, form);
            else 
                Refuse(cn, form);
            throw new ResIsBroken((Convert.ToInt32(cn) + 1).ToString());
        }

        public static void Refuse(string cn, Form1 form1)
        {
            Resources[Convert.ToInt16(cn)] = "Free";
            form1.dataGridView1.Rows[Convert.ToInt32(cn)].Cells[1].Value = "Free";
            form1.dataGridView1.Rows[Convert.ToInt32(cn)].Cells[1].Style.BackColor = Color.Green;
            form1.toolStripStatusLabel1.Text = $@"Ресурс в ячейке {Convert.ToInt32(cn) - 1} восстановлен.";
        }

        private static void Change(string cn, Form1 form1)
        {
            for (int i = 0; i < Resources.Length; i++)
            {
                if (i != Convert.ToInt32(cn)-1 && Resources[i] != "Busy" && Resources[i] != "Broken")
                {
                    Resources[i] = "Busy";
                    Refuse(cn,form1);
                    throw new ResIsChanged((i + 1).ToString());
                }
            }

            Refuse(cn,form1);
            throw new AllResIsBusy();
        }
    }
}