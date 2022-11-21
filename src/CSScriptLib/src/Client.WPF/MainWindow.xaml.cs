﻿using CSScriptLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.NET_6_WPF;

namespace Aurora.Devices
{
    public enum ActionCodes
    {
    }

    public enum DeviceKeys
    {
        C,
        CLOSE_BRACKET,
        OPEN_BRACKET
    }

    public class Logger
    {
        public void LogLine(string message)
        {
        }
    }

    public class Global
    {
        public static Logger logger = new Logger();
    }
}

namespace Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Test_Issue_316();
            Test_CodeDom();
            Test_Roslyn();

            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            
            new SecondWindow().Show();
        }

        public void Test_Issue_316()
        {
            dynamic script = CSScript.RoslynEvaluator.LoadFile("rpi_script.cs");
            Console.Out.WriteLine(script);
        }

        public void Test_CodeDom()
        {
            dynamic script = CSScript.CodeDomEvaluator
                                     .LoadMethod(@"public (int, int) func()
                                                   {
                                                       return (0,5);
                                                   }");

            (int, int) result = script.func();
        }

        public void Test_Roslyn()
        {
            dynamic script = CSScript.RoslynEvaluator
                                     .LoadMethod(@"public (int, int) func()
                                                   {
                                                       return (0,5);
                                                   }");

            (int, int) result = script.func();
        }
    }
}