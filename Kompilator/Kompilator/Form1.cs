using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;

namespace Kompilator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string>() { {"CompilerVersion", FrameForkTextBox.Text } });

            CompilerParameters parameters = new CompilerParameters(new string[] { "mscorlib.dll", "System.Core.dll" }, nameTextBox.Text, true);

            parameters.GenerateExecutable = true;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, codeBox.Text);

            if (results.Errors.HasErrors)
            {
                foreach(CompilerError error in results.Errors.Cast<CompilerError>())
                {
                    stausBox.Text += $"Строка {error.Line}:  {error.ErrorText}";
                }
            }
            else
            {
                stausBox.Text = "Сборка значений";

                Process.Start($"{Application.StartupPath}/{nameTextBox.Text}");
            }
        }
    }
}
