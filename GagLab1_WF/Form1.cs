using System;
using System.IO;
using System.Windows.Forms;

namespace GagLab1_WF
{
    public partial class Form1 : Form
    {
        public Form2 f2; 
        public Form3 f3; 
        public int Capacity;

        public Form1()
        {
            InitializeComponent();
            f2 = new Form2();
            f3 = new Form3();
        } ///////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUp.On(this);
        }

        // //////// processing the number of resources specified by the user //////////////
        public void ResNumberInput()
        {
            try
            {
                Model.vRes_s = new string[Capacity]; //initializing of resource set model
                for (int i = 0; i < Model.vRes_s.Length; i++)
                    Model.vRes_s[i] = "Free"; //all resources are marked free
                File.WriteAllLines(SetUp.Path, Model.vRes_s); //model saving is checked
                SetUp.GenTable(Model.vRes_s, this); //creation of buttons 
                toolStripStatusLabel1.Text = "";
            }
            catch (IOException)
            {
                toolStripStatusLabel1.Text = "Ошибка при записи в файл!";
                PathInput();
            }
            catch
            {
                toolStripStatusLabel1.Text = "Было введено неверное число!";
                ResNumberInput();
            }
        }

        // ////////// processing the file name specified by the user //////////////////
        private void PathInput()
        {
            try
            {
                SetUp.Path = f2.PathInput.Text;
                if (File.Exists(SetUp.Path)) SetUp.GetModel(this);
                else SetUp.ClearModel(this);
                toolStripStatusLabel1.Text = "";
            }
            catch
            {
                toolStripStatusLabel1.Text = "Файл не удаётся создать или он не доступен!";
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
                        Model.Occupy(e.RowIndex.ToString());
                    }
                    else if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "Busy")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = "Free";
                        Model.Free(e.RowIndex.ToString());
                    }
                }
            }
            catch (ResIsBusy ee)
            {
                toolStripStatusLabel1.Text = "Ячейка " + ee.Message + " занята.";
            }
            catch (ResIsFree ee)
            {
                toolStripStatusLabel1.Text = "Ячейка " + ee.Message + " свободна.";
            }
            catch (ResIsBroken ee)
            {
                toolStripStatusLabel1.Text = "Ячейка " + ee.Message + " со сломанным ресурсом.";
            }
            catch (ResIdInvalid)
            {
                toolStripStatusLabel1.Text = "Неправильный номер ячейки!";
            }

            File.WriteAllLines(SetUp.Path, Model.vRes_s);
        }
    }

    // ////////////////////////////////////////////////////////////////////////////////////////
    class ResIdInvalid : Exception
    {
    }

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
    class ResIsRefused : Exception
    {
        public ResIsRefused(string mes) : base(mes) { }
    }
    

//**************************************************************************************
    static class SetUp //setup of the application *****************
//**************************************************************************************
    {
        public static string Path; //путь к файлу, сохраняющему модель

        static MessageBoxButtons buttons = MessageBoxButtons.YesNo;

        ////////////////////////////////////////////////////////////////////////////////////////
        private static void AskPath(Form2 f2) //textBox for path input becomes visible
        {
            if (f2.ShowDialog() == DialogResult.OK)
                Path = f2.PathInput.Text;
            else AskPath(f2);
        } /////////////////////////////////////////////////////////////////////////////////////////

        public static void ClearModel(Form1 form) //textBox for number of resources becomes visible
        {
            if (form.f3.ShowDialog() == DialogResult.OK)
            {
                form.Capacity = Convert.ToInt32(form.f3.ResNumberInput.Text);
                form.ResNumberInput();
            }
            else ClearModel(form);
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        public static void GetModel(Form1 form)
        {
            if (MessageBox.Show("Обновить файл?", "", buttons) == DialogResult.Yes)
                ClearModel(form); //the model gets initiated
            else
            {
                Model.vRes_s = File.ReadAllLines(Path);
                GenTable(Model.vRes_s, form); //the model is restored from a file
            }
        }

        // /////////////////// Entry point of the application //////////////////
        public static void On(Form1 form)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\Resmod00"))
                {
                    if (MessageBox.Show("Использовать стандартный файл Resmod00?", "", buttons) == DialogResult.Yes)
                    {
                        Path = Directory.GetCurrentDirectory() + @"\Resmod00";
                        GetModel(form);
                    }
                    else AskPath(form.f2); // inquire path by the user
                }
                else
                {
                    if (MessageBox.Show("Создать стандартный файл?", "", buttons) == DialogResult.Yes)
                    {
                        Path = Directory.GetCurrentDirectory() + @"\Resmod00";
                        ClearModel(form); //initiate the model
                    }
                    else AskPath(form.f2); // inquire path by the user
                }
            }
            catch (IOException)
            {
                form.toolStripStatusLabel1.Text = "Файл не открылся.";
            }
            catch (Exception)
            {
                form.toolStripStatusLabel1.Text = "Ошибка ввода-вывода.";
            }
        } ////////////////////////////////////////////////////////////////////////////////////////

        public static void GenTable(string[] vModel, Form1 form)
        {
            for (int i = 0; i < vModel.Length; i++)
            {
                string[] row = {$"{i}", vModel[i]};
                form.dataGridView1.Rows.Add(row);
            }
        }
    }

//**************************************************************************************
    static class Model //model implementation  **************************
//**************************************************************************************
    {
        public static string[] vRes_s; //Модель набора ресурсов /////////////////////////////////////////////////////////////////////////////////////

        public static void Occupy(string cn)
        {
            if ((Convert.ToInt16(cn) > vRes_s.Length) | (Convert.ToInt16(cn) < 0)) throw new ResIdInvalid();
            vRes_s[Convert.ToInt16(cn) - 1] = "Busy";
            throw new ResIsBusy(cn);
        }

        public static void Free(string cn)
        {
            if ((Convert.ToInt16(cn) > vRes_s.Length) | (Convert.ToInt16(cn) < 0)) throw new ResIdInvalid();
            vRes_s[Convert.ToInt16(cn) - 1] = "Free";
            throw new ResIsFree(cn);
        }

        public static void Broke(string cn)
        {
            vRes_s[Convert.ToInt16(cn) - 1] = "Broken";
            throw new ResIsBroken(cn);
        }

        public static void Refuse(string cn)
        {
            vRes_s[Convert.ToInt16(cn) - 1] = "Free";
            throw new ResIsRefused(cn);
        }
    }
}