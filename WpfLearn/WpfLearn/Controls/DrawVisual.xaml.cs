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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfLearn.Models;

namespace WpfLearn.Controls
{
    /// <summary>
    /// DrawVisual.xaml 的交互逻辑
    /// </summary>
    public partial class DrawVisual : Window
    {
        public DrawVisual()
        {
            InitializeComponent();
        }

        //初始化事件
        private void DrawVisual_OnInitialized(object sender, EventArgs e)
        {
            Uri uri = new Uri("images/airport.jpg",UriKind.Relative);
            ImageBrush brush = new ImageBrush();
            
            BitmapImage image = new BitmapImage(uri);
            brush.ImageSource = image;
            LocalCanvas.Background = brush;
            LocalCanvas.Width = image.PixelWidth;
            LocalCanvas.Height = image.PixelHeight;
        }

        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalCanvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            Point pointClicked = e.GetPosition(LocalCanvas);
            if (operation == Operation.Add)
            {
                // LbTip.Content = pointClicked.ToString();
                CustomVisual visual = new CustomVisual();
                DrawImage(visual, pointClicked, false,true);
                LocalCanvas.AddVisual(visual);
            }
            else if (operation == Operation.Delete)
            {
                CustomVisual visual = LocalCanvas.GetVisual(pointClicked);
                if (visual != null)
                {
                    LocalCanvas.DeleteVisual(visual);
                }
            }
            else if (operation == Operation.SelectMove)
            {
                CustomVisual visual = LocalCanvas.GetVisual(pointClicked);
                if (visual == null)
                {
                    if (selectedVisual != null)
                    {
                        DrawImage(selectedVisual, selectedVisual.TopLeftPoint, false);
                        selectedVisual = null;
                    }
                    return;
                }
                //获取左上点
                
                DrawImage(visual,visual.TopLeftPoint,true);

                clickOffset = visual.TopLeftPoint - pointClicked;
                isDragging = true;
                if (selectedVisual != null && selectedVisual != visual)
                {
                    ClearSelection();
                }
                selectedVisual = visual;
            }
            else if (operation == Operation.MultiSelect)
            {
                selectionSquare = new CustomVisual();
                LocalCanvas.AddVisual(selectionSquare);
                selectionSquareTopLeft = pointClicked;
                isMultiSelection = true;
                // Make sure we get the MouseLeftButtonUp event even if the user
                // moves off the Canvas. Otherwise, two selection squares could be drawn at once.
                LocalCanvas.CaptureMouse();
            }
            else if (operation == Operation.GraphMove)
            {
                before = e.GetPosition(this);
                isMoving = true;

                // Make sure we get the MouseLeftButtonUp event even if the user
                // moves off the Canvas. Otherwise, two selection squares could be drawn at once.
                LocalCanvas.CaptureMouse();
            }
            else if (operation == Operation.None)
            {
                if (DateTime.Now.Subtract(FirstClickDownTime).TotalSeconds > 2)
                {
                    isFirst = true;
                }

                if (isFirst)
                {
                    FirstClickDownTime = DateTime.Now;
                }
            }
        }

        private void ClearSelection()
        {
            Point topLeftCorner = new Point(selectedVisual.TopLeftPoint.X, selectedVisual.TopLeftPoint.Y);
            DrawImage(selectedVisual,topLeftCorner,false);
            selectedVisual = null;
        }

        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalCanvas_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private Point before;
        private bool isMoving = false;

        private DateTime FirstClickDownTime = DateTime.Now.AddSeconds(-5);
        private DateTime SecondClickDownTime = DateTime.Now.AddSeconds(-5);
        public bool isFirst = true;
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point pointDraged = e.GetPosition(LocalCanvas)+clickOffset;
                DrawImage(selectedVisual,pointDraged,true);
            }
            else if (isMultiSelection)
            {
                Point pointDragged = e.GetPosition(LocalCanvas);
                DrawSelectionSquare(selectionSquareTopLeft, pointDragged);
            }
            else if (operation == Operation.GraphMove && isMoving)
            {
                    Point pointDraged = e.GetPosition(this);
                    LocalCanvas.Offset = new Point(LocalCanvas.Offset.X - pointDraged.X + before.X,
                        LocalCanvas.Offset.Y - pointDraged.Y + before.Y);
                    before = pointDraged;
            }
        }

        public int i = 0;

        private Brush selectionSquareBrush = Brushes.Transparent;
        private Pen selectionSquarePen = new Pen(Brushes.Black, 2);
        private void DrawSelectionSquare(Point selectionSquareTopLeft, Point pointDragged)
        {
            selectionSquarePen.DashStyle = DashStyles.Dash;

            using (DrawingContext dc = selectionSquare.RenderOpen())
            {
                dc.DrawRectangle(selectionSquareBrush, selectionSquarePen,
                    new Rect(selectionSquareTopLeft, pointDragged));
            }
        }

        /// <summary>
        /// 鼠标左键弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalCanvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            i = 0;
            if (isMoving)
            {

                LocalCanvas.ReleaseMouseCapture();  
            }
            isMoving = false;
            if (isMultiSelection)
            {
                // Display all the squares in this region.
                RectangleGeometry geometry = new RectangleGeometry(new Rect(selectionSquareTopLeft, e.GetPosition(LocalCanvas)));
                List<CustomVisual> visualsInRegion = LocalCanvas.GetVisuals(geometry);
                MessageBox.Show(String.Format("You selected {0} square(s).", visualsInRegion.Count));

                isMultiSelection = false;
                LocalCanvas.DeleteVisual(selectionSquare);
                LocalCanvas.ReleaseMouseCapture();  
            }

            if (operation == Operation.None)
            {
                if (!isFirst)
                {
                    if (DateTime.Now.Subtract(FirstClickDownTime).TotalSeconds < 0.5)
                    {
                        Toast.Show("这是一次双击事件");
                    }
                }
                isFirst = !isFirst;
            }
        }

        /// <summary>
        /// 鼠标右键弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalCanvas_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point pointClicked = e.GetPosition(LocalCanvas);
            CustomVisual visual = LocalCanvas.GetVisual(pointClicked);
            if (visual == null)
            {
                isNeedToShowContextMenu = false;
            }
            else
            {
                isNeedToShowContextMenu = true;
            }

        }


        #region 绘制方法

        private Brush drawingBrush = Brushes.AliceBlue;
        private Brush selectedDrawingBrush = Brushes.LightGoldenrodYellow;
        private Pen drawingPen = new Pen(Brushes.SteelBlue,3);
        private Size squareSize = new Size(30,30);
        #region 拖动相关
        private CustomVisual selectedVisual;
        private bool isDragging = false;
        private Vector clickOffset;
        #endregion
        private Operation operation;

        private bool isMultiSelection = false;
        private Point selectionSquareTopLeft;
        private CustomVisual selectionSquare;

        //draw square
        private void DrawSquare(CustomVisual visual, Point topLeftCorner, bool isSelected)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                Brush brush = drawingBrush;
                if (isSelected)
                {
                    brush = selectedDrawingBrush;
                }
                
                dc.DrawRectangle(brush,drawingPen,new Rect(topLeftCorner,squareSize));
            }
        }


        private void DrawImage(CustomVisual visual, Point topLeftCorner, bool isSelected,bool isAdded =false)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                BitmapImage bitmap = new BitmapImage(new Uri("images/s14.png",UriKind.Relative));
                if (isSelected)
                {
                    bitmap = new BitmapImage(new Uri("images/s32.png", UriKind.Relative));
                }
                if (isAdded)
                {
                    visual.TopLeftPoint = new Point(topLeftCorner.X-5, topLeftCorner.Y-5);
                }
                else
                {
                    visual.TopLeftPoint = new Point(topLeftCorner.X, topLeftCorner.Y);
                }
                dc.DrawImage(bitmap, new Rect(visual.TopLeftPoint, new Size(bitmap.PixelWidth, bitmap.PixelHeight)));
            }
        }

        #endregion

        private void CmdSelectMove_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.SelectMove;
        }

        private void CmdAdd_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.Add;
        }

        private void CmdDelete_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.Delete;
        }


        public CustomVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as CustomVisual;
        }

        private void CmdSelect_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.MultiSelect;
        }

        private void SliderScale_OnValueChanged(object o, RoutedPropertyChangedEventArgs<double> e)
        {
            double d = SliderScale.Value/SliderScale.Maximum;
            LocalCanvas.Scale = d*2;
            if (operation == Operation.SelectMove)
            {
                Toast.Show(LocalCanvas.Width + ":" + LocalCanvas.Height+"      "+LocalCanvas.Offset.X+":"+LocalCanvas.Offset.Y);
            }
        }

        private void CmdNone_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.None;
        }

        private void CmdGraphMove_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.GraphMove;
        }

        private void CmdGraphZoom_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.GraphZoom;
            LocalCanvas.ScaleDirection = 0;
        }

        private void LocalCanvas_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (operation == Operation.GraphZoom)
            {

                if (e.Delta > 0)
                {
                    if (LocalCanvas.Scale > 2 )
                    {
                        return;
                    }

                    LocalCanvas.Scale = LocalCanvas.Scale*(1 + 1/16.0);

                }
                else if(e.Delta <0)
                {
                    if ( LocalCanvas.Scale < 0.5)
                    {
                        return;
                    }

                    LocalCanvas.Scale = LocalCanvas.Scale * (1 - 1 / 16.0);
                }
            }
        }

        private void CmdReset_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.None;
            LocalCanvas.Scale = 1;
            LocalCanvas.Offset = new Point(0,0);
            isMoving = false;
            isMultiSelection = false;
        }

        /// <summary>
        /// 水平缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdHoom_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.GraphZoom;
            LocalCanvas.ScaleDirection = 1;
        }

        /// <summary>
        /// 垂直缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdZoom_OnClick(object sender, RoutedEventArgs e)
        {
            operation = Operation.GraphZoom;
            LocalCanvas.ScaleDirection = 2;
        }

        private bool isNeedToShowContextMenu = false;
        private void LocalCanvas_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (!isNeedToShowContextMenu)
            {
                e.Handled = true;
                return;
            }

            MiDel.Visibility = Visibility.Collapsed;
        }

        private void Expander_OnExpanded(object sender, RoutedEventArgs e)
        {
            if (ToolExpander.IsExpanded)
            {
                ToolExpander.Background = new SolidColorBrush(Color.FromArgb(255, 152, 251, 152));
                Toast.Show("true");
            }
            else
            {
                ToolExpander.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                Toast.Show("false");
            }
        }

        private void ToolExpander_OnCollapsed(object sender, RoutedEventArgs e)
        {
            if (ToolExpander.IsExpanded)
            {
                ToolExpander.Background = new SolidColorBrush(Color.FromArgb(128, 152, 251, 152));
                Toast.Show("true");
            }
            else
            {
                ToolExpander.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                Toast.Show("false");
            }
        }
    }



    public enum Operation
    {
        None,
        Add,
        SelectMove,
        Delete,
        MultiSelect,
        GraphMove,
        GraphZoom
    }
}
