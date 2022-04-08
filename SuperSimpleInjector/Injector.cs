using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;
/*
 By:Avi
Just a simple project i made for fun.
 */
namespace SuperSimpleInjector
{
    public partial class Injector : Form
    {
        public Injector()
        {
            InitializeComponent();
            loadDrives();
            loadProcess();
            readStoreFile();
            readStoreexe();
        }
        private string pickedDrivesrc, currentDirsrc, Processname, DLLpath, DLLname;
        private void readStoreFile()
        { 
            string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (Directory.Exists(Appdata + "\\Avi"))
            {
                if (File.Exists(Appdata + "\\Avi\\Avipath.txt"))
                    foreach (string line in System.IO.File.ReadLines(Appdata + "\\Avi\\Avipath.txt"))
                    {
                        HistoryPaths.Items.Add(line);
                    }
            }
            else
            {
                Directory.CreateDirectory(Appdata + "\\Avi");
                File.Create(Appdata + "\\Avi\\Avipath.txt");
            }
        }
        private void readStoreexe()
        {
            string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (Directory.Exists(Appdata + "\\Avi"))
            {
                if (File.Exists(Appdata + "\\Avi\\Aviexe.txt"))
                    foreach (string line in System.IO.File.ReadLines(Appdata + "\\Avi\\Aviexe.txt"))
                    {
                        checkedListBox1.Items.Insert(0, line);
                    }
            }
            else
            {
                Directory.CreateDirectory(Appdata + "\\Avi");
                File.Create(Appdata + "\\Avi\\Aviexe.txt");
            }
        }
        private void setPathForDir()
        {
            try
            {
                if (pickedDrivesrc != null)
                    textBoxForInputPath.Text = pickedDrivesrc;
                else
                    textBoxForInputPath.Text = "Path not picked";
      
            }
            catch (Exception ex)
            {
                //Log("ik but i wont fix it now. :)");
            }


        }
        private void loadDrives()
        {
            try
            {

                srcFilePathToDLLbox.Items.Clear();
                foreach (var drive in DriveInfo.GetDrives())
                    srcFilePathToDLLbox.Items.Add(drive);
            }
            catch (Exception e)
            {

            }
        }
        private void loadDirectorySrc()
        {
            try
            {
                // Get information about the source directory
                var dir = new DirectoryInfo(pickedDrivesrc);
                // Cache directories before we start copying
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo subDir in dirs)
                    srcFilePathToDLLbox.Items.Add(subDir.FullName);
                currentDirsrc = pickedDrivesrc;
                setPathForDir();
                loadFile();
            }
            catch(Exception e)
            {

            }
        }
        private bool loadFile()
        {
            try
            {
                // Get information about the source directory
                var dir = new DirectoryInfo(pickedDrivesrc);
                // Cache directories before we start copying
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (FileInfo file in dir.GetFiles())
                {
                    //If files of the .dll
                    if (file.Extension == ".dll")
                    {
                        if(!srcFilePathToDLLbox.Items.Contains(file.Name))
                             srcFilePathToDLLbox.Items.Add(file.Name);
                        DLLpath = file.FullName;
                        DLLname = file.Name;
                        return true;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }
        private void loadProcess()
        {
            try
            {
                Process[] processCollection = Process.GetProcesses();
                foreach (Process p in processCollection)
                {
                    boxOfEXE.Items.Add(p.ProcessName);
                }
            }
            catch (Exception e)
            {

            }
        }
        private void Injector_Load(object sender, EventArgs e)
        {
            
        }

        private void srcFilePathToDLLbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (loadFile())
                {
                    labelForDLL.Text = "Selected DLL: " + DLLname;
                    return;
                }
                pickedDrivesrc = srcFilePathToDLLbox.GetItemText(srcFilePathToDLLbox.SelectedItem);
                srcFilePathToDLLbox.Items.Clear();
                loadDirectorySrc();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Processname = checkedListBox1.GetItemText(checkedListBox1.SelectedItem);
            labelForEXE.Text = "Selected Process: " + Processname;

        }

        private void boxOfEXE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Processname = boxOfEXE.GetItemText(boxOfEXE.SelectedItem);
                labelForEXE.Text = "Selected Process: " + Processname;
            }
            catch (Exception ex)
            {

            }
        }

        private void HistoryPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pickedDrivesrc = HistoryPaths.GetItemText(HistoryPaths.SelectedItem);
                srcFilePathToDLLbox.Items.Clear();
                loadDirectorySrc();
            }
            catch (Exception ex)
            {
                //Log(ex.Message);
            }
        }

      
        private void textBoxForInputPath_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void textBoxForInputPath_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(textBoxForInputPath.Text))
                {
                    pickedDrivesrc = textBoxForInputPath.Text;
                    srcFilePathToDLLbox.Items.Clear();
                    loadDirectorySrc();

                }
                else
                    MessageBox.Show("File path not found: " + textBoxForInputPath.Text);
            }
        }
        private void InjectButton_Click(object sender, EventArgs e)
        {
            //stores file path in txt
            if(!string.IsNullOrEmpty(pickedDrivesrc))
                System.IO.File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) 
                    + "\\Avi\\Avipath.txt", pickedDrivesrc + "\r\n");
            if (!string.IsNullOrEmpty(Processname))
                System.IO.File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                    + "\\Avi\\Aviexe.txt", Processname + "\r\n");

            if(new Injection().InjectDll(Processname, DLLpath))
                MessageBox.Show("DLL injected into " + Processname);
            else
                MessageBox.Show("DLL failed to inject into " + Processname);

        }

        private void quitButton_Click(object sender, EventArgs e)//Act as the back button when looking for DLL
        {
            if (pickedDrivesrc != null)
            {
                srcFilePathToDLLbox.Items.Clear();
                if (pickedDrivesrc.Contains(@"\"))
                {
                    string removeString = currentDirsrc.Split('\\').Last();
                    pickedDrivesrc = pickedDrivesrc.Replace(@"\" + removeString, "");
                    loadDirectorySrc();
                }
                else
                {
                    loadDrives();
                    pickedDrivesrc = null;
                }
            }
            else
                MessageBox.Show("Pick a Directory.");
        }
    }
}
