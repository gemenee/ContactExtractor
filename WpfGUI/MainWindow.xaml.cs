using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using TextPreparation;

namespace WpfGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private int ctr = 1000;

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			TextBlock? textBlock = e.Source as TextBlock;
			textBlock.Text = (--ctr).ToString();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string s = null;
			s.Trim();
		}

		private void btnOpenFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
				txtEditor.Text = DocxTextExtractor.ExtractText(openFileDialog.FileName);
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void btnRemoveNonAlphaNum_Click(object sender, RoutedEventArgs e)
		{
			txtEditor.Text = DocxTextExtractor.RemoveNonAlphanumericSymbols(txtEditor.Text);
		}
	}
}