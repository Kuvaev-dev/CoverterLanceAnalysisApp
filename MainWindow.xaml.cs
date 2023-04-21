using System;
using System.Collections.Generic;
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
using static System.Net.Mime.MediaTypeNames;

namespace CLAA
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LanceDesc.Text = "1 - фурма\n2 - газова фаза\n3 - розплав";
        }

        private void TempShowImage_Loaded(object sender, RoutedEventArgs e)
        {
            DrawingVisual drawingVisual = new();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // рисуем границы таблицы
                Pen pen = new(Brushes.Black, 2);
                for (int i = 0; i <= 9; i++)
                {
                    drawingContext.DrawLine(pen, new Point(i * 50, 0), new Point(i * 50, 500));
                }
                for (int i = 0; i <= 10; i++)
                {
                    drawingContext.DrawLine(pen, new Point(0, i * 50), new Point(450, i * 50));
                }

                // заполняем ячейки таблицы синим цветом
                Brush brush = Brushes.Blue;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        drawingContext.DrawRectangle(brush, null, new Rect(i * 50 + 2, j * 50 + 2, 46, 46));
                    }
                }
            }
            RenderTargetBitmap bmp = new(450, 500, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            TempShowImage.Source = bmp;
        }
    }
}
